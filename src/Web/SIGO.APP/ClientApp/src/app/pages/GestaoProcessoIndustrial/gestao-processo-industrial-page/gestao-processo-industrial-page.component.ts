import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EventoService } from '../../../services/evento.service';
import { DataTablesOptions } from '../../../utils/data-tables-utils';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-gestao-processo-industrial-page',
  templateUrl: './gestao-processo-industrial-page.component.html',
  styleUrls: ['./gestao-processo-industrial-page.component.css']
})

export class GestaoProcessoIndustrialPageComponent implements OnInit {

    /**
     *
     */
    public eventos;

    /**
     *
     */
    public listagemEventos;

    /**
     *
     */
    dtOptions: any;

    /**
     *
     */
    public dtTrigger: Subject < any > = new Subject < any > ();

    /**
     * Creates an instance of class GestaoProcessoIndustrialPageComponent
     */
    constructor(
        private eventoService: EventoService,
        private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService) {}

    /**
     * Initializes the component
     */
    ngOnInit(): void {
        this.dtOptions = DataTablesOptions.PortuguesBrasil;

        this.obterListagemEventos();
        // Remover para fazer a chamada ao procedimento remoto de messageria
        /*
        this.obterListagemEventos();

        this.iniciarTimerObterListagemEventos();
        */
        this.listagemEventos = [{
            data: [50, 50]
        }];
    }

    /**
     * Handle Menu Click
     */
    public onMenuClick(modulo) {
        this.router.navigate([modulo]);
    }

    /**
     * Get Eventos List
     */
     obterListagemEventos() {
        this.eventoService.obterEventos().subscribe(
            result => {
                if (result != null) {
                    this.eventos = result;
                    this.dtTrigger.next();
                } else
                    this.toastr.error("Erro", "Alerta");
            },
            error => {
                this.toastr.error("Erro", "Alerta");
            }
        );
    }

    /**
     * Get Ultimos Eventos List
     */
    obterListagemUltimosEventos() {
        this.eventoService.obterUltimosEventos().subscribe(
            result => {
                if (result != null) {
                    let listagemEventos: ListagemEventos = JSON.parse(result["descricao"]);

                    if (listagemEventos.Eventos != this.listagemEventos[0].data[0]) {
                        this.listagemEventos = [{
                            data: [listagemEventos.Eventos, listagemEventos.Resolucoes]
                        }];
                    }
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
     * Timer to get
     */
    iniciarTimerObterListagemEventos() {
        setInterval(() => {
            this.obterListagemEventos();
        }, 10000)
    }
}

/**
 * Data Interface
 */
interface ListagemEventos {
    Eventos: string;
    Resolucoes: string;
}
