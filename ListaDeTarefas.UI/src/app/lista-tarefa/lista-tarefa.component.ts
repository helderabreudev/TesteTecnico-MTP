import { Component, OnInit } from '@angular/core';
import { TarefaService } from '../service/tarefa.service';

interface Tarefa {
  id: number;
  mensagem: string;
  concluida: boolean;
}

@Component({
  selector: 'app-lista-tarefa',
  templateUrl: './lista-tarefa.component.html',
  styleUrls: ['./lista-tarefa.component.css']
})

export class TarefasComponent implements OnInit {
  tarefas: Tarefa[] = [];
  novaTarefa: string = '';

  constructor(private tarefaService: TarefaService) { }

  ngOnInit(): void {
    this.getTarefas();
  }

  getTarefas(): void {
    this.tarefaService.getTarefas().subscribe(response => {
        this.tarefas = response.resultado;
    });
  }

  addTarefa(): void {
    if (this.novaTarefa.trim()) {
      this.tarefaService.addTarefa(this.novaTarefa).subscribe(() => {
        this.getTarefas();
        this.novaTarefa = '';
      });
    }
  }

  concluirTarefa(id: number): void {
    this.tarefaService.updateTarefa(id).subscribe(() => {
      const tarefa = this.tarefas.find(t => t.id === id);
      if (tarefa) {
        tarefa.concluida = true;
      }
    });
  }

  deleteTarefa(id: number): void {
    this.tarefaService.deleteTarefa(id).subscribe(() => {
      this.tarefas = this.tarefas.filter(t => t.id !== id);
    });
  }
}