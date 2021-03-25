import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";

@Injectable()
export class ContratoService {

    /**
     * Endpoint to the service
     */
    private readonly _endpoint: string = 'contrato';
    
    /**
     * Creates an instance of ConsultoriaService.
     */
    constructor(private baseService: BaseService) {
    }
    
    /**
     * Call to a GET list endpoint.
     */
    public obterContratos() {
        return this.baseService.get(this._endpoint);
    }
    /**
     * Call to a GET list endpoint.
     */
    public obterContratoResumo() {
      return this.baseService.get(this._endpoint + "/resumo");
    }
}
