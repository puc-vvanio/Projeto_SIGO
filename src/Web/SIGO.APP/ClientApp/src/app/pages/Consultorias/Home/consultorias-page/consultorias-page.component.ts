import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ContratoService } from '../../../../services/contrato.service';

@Component({
  selector: 'app-consultorias-page',
  templateUrl: './consultorias-page.component.html',
  styleUrls: ['./consultorias-page.component.css']
})
export class ConsultoriasPageComponent implements OnInit {
    /**
     *
     */    
     public resumo: any;    
    
    /**
     * Creates an instance of ConsultoriasPageComponent.
     */
    constructor(
        private ContratoService: ContratoService,
        private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService) {}

    /**
     * Initializes the component
     */
    ngOnInit(): void {
      this.obterContratoResumo();
    }

    /**
     * Handle Menu Click
     */
    public onMenuClick(menu) {
        this.router.navigate([menu]);
    }

    obterContratoResumo() {
         this.ContratoService.obterContratoResumo().subscribe(
               result => {
             if (result != null) {
                     this.resumo = result;                       
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
