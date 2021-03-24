import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl  } from '@angular/forms';
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

    /**
     * Creates an instance of class NormasPageComponent
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

}
