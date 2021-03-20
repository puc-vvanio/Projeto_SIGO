import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/Acesso/login-page.component';
import { AppRoutingModule } from './app-routing.module';
import { IconComponent } from './controls/icon/icon.component';
import { GestaoProcessoIndustrialPageComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component';

import { ChartsModule } from 'ng2-charts';
import { OrcamentosPedidosMesesGraphComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/Graphs/orcamentos-pedidos-meses-graph/orcamentos-pedidos-meses-graph.component';
import { OrcamentosPedidosMesGraphComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/Graphs/orcamentos-pedidos-mes-graph/orcamentos-pedidos-mes-graph.component';
import { ToastrModule } from 'ngx-toastr';

import { BaseService } from './services/base.service'
import { ConsultoriaService } from './services/consultoria.service'
import { NormaService } from './services/norma.service'
import { UsuarioService } from './services/usuario.service'
import { RepositorioService } from './services/repositorio.service'
import { EventoService } from './services/evento.service'

import { RequestInterceptor } from './utils/request-interceptor'
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";

import { ConsultoriasPageComponent } from './pages/Consultorias/Home/consultorias-page/consultorias-page.component';
import { NavMenuComponent } from './controls/nav-menu/nav-menu.component';
import { CardsConsultoriasComponent } from './pages/Consultorias/Home/CardsConsultorias/cards-consultorias/cards-consultorias.component';
import { DataTablesModule } from 'angular-datatables';
import { ListagemConsultoriasComponent } from './pages/Consultorias/Consultorias/listagem-consultorias/listagem-consultorias.component';
import { NormasPageComponent } from './pages/Normas/Home/normas-page/normas-page.component';
import { ListagemNormasComponent } from './pages/Normas/Normas/listagem-normas/listagem-normas.component';
import { ListagemRepositoriosComponent } from './pages/Normas/Repositorios/listagem-repositorios/listagem-repositorios.component';
import { CardNormasHomeComponent } from './pages/Normas/Home/Cards/card-normas-home/card-normas-home.component';
import { InclusaoRepositorioComponent } from './pages/Normas/Repositorios/inclusao-repositorio/inclusao-repositorio.component';

import { NavigationGuardService } from './security/navigation.guard.service';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    IconComponent,
    GestaoProcessoIndustrialPageComponent,
    OrcamentosPedidosMesesGraphComponent,
    OrcamentosPedidosMesGraphComponent,
    ConsultoriasPageComponent,
    NavMenuComponent,
    CardsConsultoriasComponent,
    ListagemConsultoriasComponent,
    NormasPageComponent,
    ListagemNormasComponent,
    ListagemRepositoriosComponent,
    CardNormasHomeComponent,
    InclusaoRepositorioComponent
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
