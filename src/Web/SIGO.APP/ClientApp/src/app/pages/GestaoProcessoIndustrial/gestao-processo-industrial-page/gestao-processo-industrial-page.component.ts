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
    public listagemOrcamentosVendas;
    
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
        // Remover para fazer a chamada ao procedimento remoto de messageria
        /*
        this.obterListagemEventos();
        this.obterListagemEventosOrcamentosVendas();
        
        this.iniciarTimerObterListagemEventosOrcamentosVendas();
        */
        this.listagemOrcamentosVendas = [{
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
     * Get Eventos Orcamento Vendas List
     */
    obterListagemEventosOrcamentosVendas() {
        this.eventoService.obterEventosOrcamentosVendas().subscribe(
            result => {
                if (result != null) {
                    let listagemOrcamentosVendas: ListagemOrcamentosVendas = JSON.parse(result["descricao"]);

                    if (listagemOrcamentosVendas.Orcamentos != this.listagemOrcamentosVendas[0].data[0]) {
                        this.listagemOrcamentosVendas = [{
                            data: [listagemOrcamentosVendas.Orcamentos, listagemOrcamentosVendas.Vendas]
                        }];
                    }
                } else
                    this.toastr.error("Erro", "Alerta");
            },
            error => {
                this.toastr.error("Erro", "Alerta");
            }
        );
    }

    /**
     * Timer to get 
     */
    iniciarTimerObterListagemEventosOrcamentosVendas() {
        setInterval(() => {
            this.obterListagemEventosOrcamentosVendas();
        }, 10000)
    }
}

/**
 * Data Interface 
 */
interface ListagemOrcamentosVendas {
    Orcamentos: string;
    Vendas: string;
}