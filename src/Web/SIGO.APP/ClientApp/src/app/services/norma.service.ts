import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";

@Injectable()
export class NormaService {

    /**
     * Endpoint to the service
     */
    private readonly _endpoint: string = 'normas/api/norma';

    /**
     * Creates an instance of NormaService.
     */
    constructor(private baseService: BaseService) {
    }

    /**
     * Call to GET list endpoint
     */
    public obterNormas() {
        return this.baseService.get(this._endpoint);
    }
}
