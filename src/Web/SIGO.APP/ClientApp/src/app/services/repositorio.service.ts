import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";
import { RepositorioDTO } from "../DTO/repositorio.dto";

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

    /**
     * Call to POST item endpoint
     */
    public criarRepositorio(repositorioDTO : RepositorioDTO) {
        return this.baseService.post(this._endpoint, repositorioDTO);
    }
}
