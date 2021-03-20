import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { RepositorioService } from '../../../../services/repositorio.service';
import { DataTablesOptions } from '../../../../utils/data-tables-utils';

@Component({
  selector: 'app-listagem-repositorios',
  templateUrl: './listagem-repositorios.component.html',
  styleUrls: ['./listagem-repositorios.component.css']
})
export class ListagemRepositoriosComponent implements OnInit {

    /**
     * 
     */
    public repositorios;

    /**
     * 
     */
    dtOptions: any;

    /**
     * 
     */
    public dtTrigger: Subject < any > = new Subject < any > ();

    /**
     * Creates an instance of class ListagemRepositoriosComponent
     */
    constructor(
        private repositorioService: RepositorioService, 
        private router: Router, 
        private route: ActivatedRoute,
        private toastr: ToastrService) {}
 
    /**
     * Initializes the component
     */
    ngOnInit(): void {
        this.dtOptions = DataTablesOptions.PortuguesBrasil;
        this.obterListagemRepositorios();
    }

    /**
     * Handle Menu Click
     */
    public onMenuClick(modulo) {
        this.router.navigate([modulo]);
    }

    /**
     * Get Repositorios List
     */
    obterListagemRepositorios() {
        this.repositorioService.obterRepositorios().subscribe(
            result => {
                if (result != null) {
                    this.repositorios = result;
                    this.dtTrigger.next();
                } else
                    this.toastr.error("Erro", "Alerta");
            },
            error => {
                this.toastr.error("Erro", "Alerta");
            }
        );
    }
}