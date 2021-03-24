import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";

import { DataTablesModule } from 'angular-datatables';
import { from } from 'rxjs';
import { ChartsModule } from 'ng2-charts';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { BaseService } from './services/base.service'
import { ConsultoriaService } from './services/consultoria.service'
import { ContratoService } from './services/contrato.service'
import { NormaService } from './services/norma.service'
import { UsuarioService } from './services/usuario.service'
import { RepositorioService } from './services/repositorio.service'
import { EventoService } from './services/evento.service'
import { NavigationGuardService } from './security/navigation.guard.service';
import { RequestInterceptor } from './utils/request-interceptor'

import { IconComponent } from './controls/icon/icon.component';
import { NavMenuComponent } from './controls/nav-menu/nav-menu.component';

import { LoginPageComponent } from './pages/Acesso/login-page.component';

import { GestaoProcessoIndustrialPageComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component';
import { EventosResolucoesGraphComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/Graphs/eventos-resolucoes-graph/eventos-resolucoes-graph.component';

import { ConsultoriasPageComponent } from './pages/Consultorias/Home/consultorias-page/consultorias-page.component';
import { CardsConsultoriasComponent } from './pages/Consultorias/Home/CardsConsultorias/cards-consultorias/cards-consultorias.component';
import { ListagemConsultoriasComponent } from './pages/Consultorias/Consultorias/listagem-consultorias/listagem-consultorias.component';
import { ListagemContratosComponent } from './pages/Consultorias/Contratos/listagem-contratos/listagem-contratos.component';

import { NormasPageComponent } from './pages/Normas/Home/normas-page/normas-page.component';
import { CardNormasHomeComponent } from './pages/Normas/Home/Cards/card-normas-home/card-normas-home.component';
import { ListagemNormasComponent } from './pages/Normas/Normas/listagem-normas/listagem-normas.component';
import { VisualizarNormaComponent } from "./pages/Normas/Normas/visualizar-norma/visualizar-norma.component";
import { ListagemRepositoriosComponent } from './pages/Normas/Repositorios/listagem-repositorios/listagem-repositorios.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    NavMenuComponent,
    IconComponent,
    GestaoProcessoIndustrialPageComponent,
    EventosResolucoesGraphComponent,
    ConsultoriasPageComponent,
    CardsConsultoriasComponent,
    ListagemConsultoriasComponent,
    ListagemContratosComponent,
    NormasPageComponent,
    CardNormasHomeComponent,
    ListagemNormasComponent,
    VisualizarNormaComponent,
    ListagemRepositoriosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DataTablesModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    BaseService,
    ConsultoriaService,
    ContratoService,
    NormaService,
    RepositorioService,
    UsuarioService,
    EventoService,
    [NavigationGuardService],
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
