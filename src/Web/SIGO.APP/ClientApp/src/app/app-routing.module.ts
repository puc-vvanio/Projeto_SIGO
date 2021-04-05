import { RouterModule, Routes } from "@angular/router";
import { LoginPageComponent } from "./pages/Acesso/login-page.component";
import { GestaoProcessoIndustrialPageComponent } from "./pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component";
import { ConsultoriasPageComponent } from "./pages/Consultorias/Home/consultorias-page/consultorias-page.component";
import { ListagemConsultoriasComponent } from "./pages/Consultorias/Consultorias/listagem-consultorias/listagem-consultorias.component";
import { ListagemContratosComponent } from "./pages/Consultorias/Contratos/listagem-contratos/listagem-contratos.component";
import { NormasPageComponent } from "./pages/Normas/Home/normas-page/normas-page.component";
import { ListagemNormasComponent } from "./pages/Normas/Normas/listagem-normas/listagem-normas.component";
import { VisualizarNormaComponent } from "./pages/Normas/Normas/visualizar-norma/visualizar-norma.component";
import { ListagemRepositoriosComponent } from "./pages/Normas/Repositorios/listagem-repositorios/listagem-repositorios.component";


import { NgModule } from "@angular/core";
import { NavigationGuardService } from "./security/navigation.guard.service";

const appRoutes: Routes = [
  {
    path: "",
    component: LoginPageComponent
  },
  {
    path: "GestaoProcessoIndustrial",
    component: GestaoProcessoIndustrialPageComponent,
    canActivate: [NavigationGuardService],
    data: { role: "Admin,Gerente,Colaborador", modulo: "Gestão do Proceso Industrial"} 
  },
  {
    path: "Consultorias",
    component: ConsultoriasPageComponent,
    canActivate: [NavigationGuardService],
    data: { role: "Admin,Gerente", modulo: "Assessorias e Consultorias" }
  },
  {
    path: "Consultorias/Consultorias",
    component: ListagemConsultoriasComponent,
    canActivate: [NavigationGuardService],
    data: { role: "Admin,Gerente", modulo: "Assessorias e Consultorias" }
  },
  {
    path: "Consultorias/Contratos",
    component: ListagemContratosComponent,
    canActivate: [NavigationGuardService],
    data: { role: "Admin,Gerente", modulo: "Assessorias e Consultorias" }
  },
  {
    path: "Normas",
    component: NormasPageComponent,
    canActivate: [NavigationGuardService],
    data: { role: "Admin,Gerente,Colaborador", modulo: "Gestão de Normas" } 
  },
  {
    path: "Normas/Normas",
    component: ListagemNormasComponent,
    canActivate: [NavigationGuardService],
    data: { role: "Admin,Gerente,Colaborador", modulo: "Gestão de Normas" }
  },
  {
    path: "Normas/Norma/:normaId",
    component: VisualizarNormaComponent,
    canActivate: [NavigationGuardService],
    data: { role: "Admin,Gerente,Colaborador", modulo: "Gestão de Normas" }
  },
  {
    path: "Normas/Repositorios",
    component: ListagemRepositoriosComponent,
    canActivate: [NavigationGuardService],
    data: { role: "Admin,Gerente,Colaborador", modulo: "Gestão de Normas" } 
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
      {
        enableTracing: false
      }
    )
  ],
  exports: [
    RouterModule
  ]
})

export class AppRoutingModule {}
