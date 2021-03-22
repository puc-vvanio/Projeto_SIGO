import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { ContratoService } from '../../../../services/contrato.service';
import { DataTablesOptions } from '../../../../utils/data-tables-utils';

@Component({
    selector: 'app-listagem-contratos',
    templateUrl: './listagem-contratos.component.html',
    styleUrls: ['./listagem-contratos.component.css']
})
export class ListagemContratosComponent implements OnInit {

    /**
     * 
     */
    dtOptions: any;

    /**
     * 
     */
    public dtTrigger: Subject < any > = new Subject < any > ();

    /**
     * 
     */
    public contratos;

    /**
     * Creates an instance of ListagemContratoServiceComponent.
     */
    constructor(
        private ContratoService: ContratoService, 
        private router: Router, 
        private route: ActivatedRoute, 
        private toastr: ToastrService) {}

    ngOnInit(): void {
        this.dtOptions = DataTablesOptions.PortuguesBrasil;
        this.obterListagemContratos();
    }

    /**
     * Handle Menu Click.
     */
    public onMenuClick(menu) {
        this.router.navigate([menu]);
    }

    /**
     * Get COntratos List
     */
     obterListagemContratos() {
       this.ContratoService.obterContratos().subscribe(
             result => {
                 if (result != null) {
                     this.contratos = result;
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
