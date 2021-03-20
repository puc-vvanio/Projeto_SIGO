import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";
import { LoginDTO } from "../DTO/login.dto";

@Injectable()
export class UsuarioService {

    /**
     * Endpoint to the service
     */
     private readonly _endpoint: string = 'autenticacao/autenticar';

    /**
     * Creates an instance of UsuarioService.
     */
    constructor(private baseService: BaseService) {
    }

    /**
     * Call to POST authorization endpoint.
     */
    public autorizar(loginDTO : LoginDTO) {
        return this.baseService.post(this._endpoint, loginDTO);
    }
}
