import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Tarefa {
  id: number;
  mensagem: string;
  concluida: boolean;
}

interface ApiResponse {
  mensagem: string;
  sucesso: boolean;
  resultado: Tarefa[];
}

@Injectable({
  providedIn: 'root'
})

export class TarefaService {
  private apiUrl = 'https://localhost:7159/api/tarefas'

  constructor(private http: HttpClient) { }

  getTarefas(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${this.apiUrl}/get-all`);
  }

  addTarefa(mensagem: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/post`, { mensagem });
  }

  updateTarefa(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/put?id=${id}`, { });
  }

  deleteTarefa(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/delete?id=${id}`);
  }
}