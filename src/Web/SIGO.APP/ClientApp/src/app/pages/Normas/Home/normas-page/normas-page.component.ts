import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NormaService } from '../../../../services/norma.service';
import { RepositorioService } from '../../../../services/repositorio.service';

@Component({
  selector: 'app-normas-page',
  templateUrl: './normas-page.component.html',
  styleUrls: ['./normas-page.component.css']
})
export class NormasPageComponent implements OnInit {
      
    /**
     * 
     */
    public quantNormas;
      
    /**
     * 
     */
    public quantRepositorios;

    /**
     * Creates an instance of class NormasPageComponent
     */
    constructor(
        private normaService: NormaService, 
        private repositorioService: RepositorioService, 
        private router: Router, 
        private route: ActivatedRoute, 
        private toastr: ToastrService) {}

    /**
     * Initializes the component
     */
    ngOnInit(): void {
        this.obterListagemNormas();
        this.obterListagemRepositorios();
    }

    /**
     * Handle Menu Click
     */
    public onMenuClick(modulo) {
        this.router.navigate([modulo]);
    }

    /**
     * 
     */
    obterListagemNormas() {
        this.normaService.obterNormas().subscribe(
            result => {
                if (result != null) {
                    this.quantNormas = result["length"];
                } else
                    this.toastr.warning("Nenhum registro localizado!", "Alerta");
            },
            error => {
                if (error.error != null)
                    this.toastr.error(error.error, "Alerta");
                else
                    this.toastr.error("Problema ao executar o acesso. Tente novamente mais tarde!", "Alerta");
            }
        );
    }

    /**
     * 
     */
    obterListagemRepositorios() {
        this.repositorioService.obterRepositorios().subscribe(
            result => {
                if (result != null) {
                    this.quantRepositorios = result["length"];
                } else
                    this.toastr.warning("Nenhum registro localizado!", "Alerta");
            },
            error => {
                if (error.error != null)
                    this.toastr.error(error.error, "Alerta");
                else
                    this.toastr.error("Problema ao executar o acesso. Tente novamente mais tarde!", "Alerta");
            }
        );
    }
}
