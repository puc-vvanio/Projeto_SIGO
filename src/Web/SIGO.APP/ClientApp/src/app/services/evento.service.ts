import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";

@Injectable()
export class EventoService {

    /**
     * Endpoint to the service
     */
    private readonly _endpoint: string = 'gestaoprocessoindustrial/api/evento';

    /**
     * Creates an instance of EventoService.
     */
    constructor(private baseService: BaseService) {
    }

    /**
     * Call to GET list endpoint
     */
    public obterEventos() {
        return this.baseService.get(this._endpoint);
    }

    /**
     * Call to GET specific list endpoint
     */
    public obterEventosOrcamentosVendas() {
        return this.baseService.get(this._endpoint + '/tipoEvento/maisRecente/' + 4);
    }
}