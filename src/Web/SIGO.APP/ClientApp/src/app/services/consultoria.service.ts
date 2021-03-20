import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";

@Injectable()
export class ConsultoriaService {

    /**
     * Endpoint to the service
     */
    private readonly _endpoint: string = 'consultoria';

    /**
     * Creates an instance of ConsultoriaService.
     */
    constructor(private baseService: BaseService) {
    }
    
    /**
     * Call to a GET list endpoint.
     */
    public obterConsultorias() {
        return this.baseService.get(this._endpoint);
    }
}
