import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
//import { DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NormaService } from '../../../../services/norma.service';

@Component({
  selector: 'app-visualizar-norma',
  templateUrl: './visualizar-norma.component.html',
  styleUrls: ['./visualizar-norma.component.css']
})

export class VisualizarNormaComponent implements OnInit {

    /**
     *
     */
    public norma;
    public normaAtualizada;

    /**
     * Creates an instance of class NormasPageComponent
     */
  constructor(
        //private datePipe: DatePipe,
        private normaService: NormaService,
        private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService) {}

    /**
     * Initializes the component
     */
    ngOnInit(): void {
        const routeParams = this.route.snapshot.paramMap;
        const normaId = Number(routeParams.get('normaId'));

        this.obterNorma(normaId);
    }

    /**
     * Handle Menu Click
     */
    public onMenuClick(menu) {
        this.router.navigate([menu]);
    }

    /**
     * Get Normas List
     */
    obterNorma(normaId) {
        this.normaService.obterNorma(normaId).subscribe(
            result => {
                if (result != null) {
                    this.norma = result;
                    this.obterAtualizacaoNorma(this.norma.nome); 
                } else
                    this.toastr.warning("Registro não localizado!", "Alerta");
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
     * Get Normas List
     */
    obterAtualizacaoNorma(normaId) {
        this.normaService.obterAtualizacaoNorma(normaId).subscribe(
            result => {
                if (result != null) {
                    this.normaAtualizada = result;
                    this.toastr.success("Norma: " + this.normaAtualizada.nome + "</br>" + "Status: " + this.normaAtualizada.status + "</br>" +
                                        "Data Status: " + formatDate(this.normaAtualizada.data, 'dd/MM/yyy hh:mm', 'en-US'), 'Informação atualizada', {enableHtml: true}); //this.datePipe.transform( this.normaAtualizada.data,"dd/MM/yyy hh:mm"));                    
                } else
                     this.toastr.warning("Serviço verificação de norma não disponível!", "Alerta");
            },
            error => {
                this.toastr.warning("Serviço verificação de norma não disponível!", "Alerta");
            }
        );
    }
}
