import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginDTO } from '../../DTO/login.dto';
import { UsuarioService } from '../../services/usuario.service';
//import * as jwt_decode from 'jwt-decode';

@Component({
    selector: 'app-login-page',
    templateUrl: './login-page.component.html',
    styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

    /**
     *
     */
    public loginForm;

    /**
     * Creates an instance of LoginPageComponent.
     */
    constructor(
        private usuarioService: UsuarioService,
        private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService) {}

    /**
     * Initializes the component
     */
    ngOnInit(): void {
        // empty local storage
        localStorage.clear();
        // create forgroup with validators
        this.loginForm = new FormGroup({
            email: new FormControl('', [Validators.required, this.emailValidator]),
            senha: new FormControl('', [Validators.required, this.senhaValidator])
        });
    }

    /**
     * Send authorization request
     * Navigates to main module
     */
    public autorizarUsuario() {
        let loginDTO = new LoginDTO();
        loginDTO.email = this.loginForm.value.email;
        loginDTO.senha = this.loginForm.value.senha;

        this.usuarioService.autorizar(loginDTO).subscribe(

            result => {

                if (result != null) {
                    localStorage.setItem("TOKEN", result.token);
                    //var teste = jwt_decode(result.token);                      
                    this.router.navigate(['/GestaoProcessoIndustrial']);
                }
                else
                    this.toastr.warning("Problema ao executar o acesso. Tente novamente mais tarde!", "Alerta");
            },
            error => {
              if (error.error != null && error.status > 0)
                    this.toastr.error(error.error, "Alerta");
                else
                    this.toastr.error("Problema ao executar o acesso. Tente novamente mais tarde!", "Alerta");
            }
        );
    }

    /**
     * Validates email input format.
     */
    private emailValidator(control: AbstractControl) {
        let result = null;
        //
        if (control.dirty) {
            if (control.value == null) {
                result = {
                    TextError: "O campo não pode estar vazio!"
                };
            } else {
                let regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);

                if (!regexp.test(control.value)) {
                    result = {
                        TextError: "O Email informado não tem formato válido!"
                    };
                }
            }
        }

        return result;
    }

    /**
     * Validates passwd input format
     */
    private senhaValidator(control: AbstractControl) {
        let result = null;
        //
        if (control.dirty) {
            if (control.value == null) {
                result = {
                    TextError: "O campo não pode estar vazio!"
                };
            }
        }

        return result;
    }
}
