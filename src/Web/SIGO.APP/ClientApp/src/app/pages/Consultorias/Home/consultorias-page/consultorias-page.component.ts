import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ConsultoriaService } from '../../../../services/consultoria.service'
import { ContratoService } from '../../../../services/contrato.service';

@Component({
  selector: 'app-consultorias-page',
  templateUrl: './consultorias-page.component.html',
  styleUrls: ['./consultorias-page.component.css']
})
export class ConsultoriasPageComponent implements OnInit {

    /**
     * Creates an instance of ConsultoriasPageComponent.
     */
    constructor(
        private consultoriaService: ConsultoriaService,
        private ContratoService: ContratoService,
        private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService) {}

    /**
     * Initializes the component
     */
    ngOnInit(): void {}

    /**
     * Handle Menu Click
     */
    public onMenuClick(menu) {
        this.router.navigate([menu]);
    }
}
