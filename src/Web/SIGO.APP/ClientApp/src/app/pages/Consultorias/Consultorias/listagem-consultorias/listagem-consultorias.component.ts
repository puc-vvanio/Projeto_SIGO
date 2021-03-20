import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { ConsultoriaService } from '../../../../services/consultoria.service';
import { DataTablesOptions } from '../../../../utils/data-tables-utils';

@Component({
    selector: 'app-listagem-consultorias',
    templateUrl: './listagem-consultorias.component.html',
    styleUrls: ['./listagem-consultorias.component.css']
})
export class ListagemConsultoriasComponent implements OnInit {

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
    public consultorias;

    /**
     * Creates an instance of ListagemConsultoriasComponent.
     */
    constructor(
        private consultoriaService: ConsultoriaService, 
        private router: Router, 
        private route: ActivatedRoute, 
        private toastr: ToastrService) {}

    ngOnInit(): void {
        this.dtOptions = DataTablesOptions.PortuguesBrasil;

        this.obterListagemConsultorias();
    }

    /**
     * Handle Menu Click.
     */
    public onMenuClick(menu) {
        this.router.navigate([menu]);
    }

    /**
     * Get Consultorias List
     */
     obterListagemConsultorias() {
        this.consultoriaService.obterConsultorias().subscribe(
            result => {
                if (result != null) {
                    this.consultorias = result;
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
