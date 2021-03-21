import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { NormaService } from '../../../../services/norma.service';
import { DataTablesOptions } from '../../../../utils/data-tables-utils';

@Component({
  selector: 'app-listagem-normas',
  templateUrl: './listagem-normas.component.html',
  styleUrls: ['./listagem-normas.component.css']
})
export class ListagemNormasComponent implements OnInit {

    /**
     * 
     */
    public normas;

    /**
     * 
     */
    dtOptions: any;

    /**
     * 
     */
    public dtTrigger: Subject < any > = new Subject < any > ();

    /**
     * Creates an instance of class ListagemNormasComponent
     */
    constructor(
        private normaService: NormaService, 
        private router: Router, 
        private route: ActivatedRoute, 
        private toastr: ToastrService) {}

    /**
     * Initializes the component
     */
    ngOnInit(): void {
        this.dtOptions = DataTablesOptions.PortuguesBrasil;

        this.obterListagemNormas();
    }

    /**
     * Handle Menu Click
     */
    public onMenuClick(modulo) {
        this.router.navigate([modulo]);
    }

    /**
     * Get Normas List
     */
    obterListagemNormas() {
        this.normaService.obterNormas().subscribe(
            result => {
                if (result != null) {
                    this.normas = result;
                    this.dtTrigger.next();
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
