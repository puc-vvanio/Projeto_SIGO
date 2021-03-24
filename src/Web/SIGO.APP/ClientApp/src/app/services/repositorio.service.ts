import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";

@Injectable()
export class RepositorioService {

    /**
     * Endpoint to the service
     */
    private readonly _endpoint: string = 'repositorio';

    /**
     * Creates an instance of RepositorioService.
     */
    constructor(private baseService: BaseService) {
    }

    /**
     * Call to GET list endpoint
     */
    public obterRepositorios() {
        return this.baseService.get(this._endpoint);
    }
}
