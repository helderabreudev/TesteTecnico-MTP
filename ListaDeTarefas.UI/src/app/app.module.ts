import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TarefasComponent } from './lista-tarefa/lista-tarefa.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TarefaService } from './service/tarefa.service';

@NgModule({
  declarations: [
    AppComponent,
    TarefasComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    HttpClientModule
  ],
  providers: [TarefaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
