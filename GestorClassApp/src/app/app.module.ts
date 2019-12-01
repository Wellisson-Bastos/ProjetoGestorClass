import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AlunoCadastroComponent } from './aluno-cadastro/aluno-cadastro.component';
import { AlunoListaComponent } from './aluno-lista/aluno-lista.component';
import { MatriculaListaComponent } from './matricula-lista/matricula-lista.component';
import { MatriculaCadastroComponent } from './matricula-cadastro/matricula-cadastro.component';

@NgModule({
  declarations: [
    AppComponent,
    AlunoCadastroComponent,
    AlunoListaComponent,
    MatriculaListaComponent,
    MatriculaCadastroComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
