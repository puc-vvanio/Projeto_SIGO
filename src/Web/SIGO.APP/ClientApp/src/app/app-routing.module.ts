import { RouterModule, Routes } from "@angular/router";
import { LoginPageComponent } from "./pages/Acesso/login-page.component";
import { GestaoProcessoIndustrialPageComponent } from "./pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component";
import { ConsultoriasPageComponent } from "./pages/Consultorias/Home/consultorias-page/consultorias-page.component";
import { ListagemConsultoriasComponent } from "./pages/Consultorias/Consultorias/listagem-consultorias/listagem-consultorias.component";
import { ListagemContratosComponent } from "./pages/Consultorias/Contratos/listagem-contratos/listagem-contratos.component";
import { NormasPageComponent } from "./pages/Normas/Home/normas-page/normas-page.component";
import { ListagemNormasComponent } from "./pages/Normas/Normas/listagem-normas/listagem-normas.component";
import { ListagemRepositoriosComponent } from "./pages/Normas/Repositorios/listagem-repositorios/listagem-repositorios.component";
import { InclusaoRepositorioComponent } from "./pages/Normas/Repositorios/inclusao-repositorio/inclusao-repositorio.component";

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
    canActivate: [NavigationGuardService]
  },
  {
    path: "Consultorias",
    component: ConsultoriasPageComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "Consultorias/Consultorias",
    component: ListagemConsultoriasComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "Consultorias/Contratos",
    component: ListagemContratosComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "Normas",
    component: NormasPageComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "Normas/Normas",
    component: ListagemNormasComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "Normas/Repositorios",
    component: ListagemRepositoriosComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "Normas/Repositorios/Novo",
    component: InclusaoRepositorioComponent,
    canActivate: [NavigationGuardService]
  }
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
