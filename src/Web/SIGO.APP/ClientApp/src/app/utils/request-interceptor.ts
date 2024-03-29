import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable, throwError, EMPTY } from "rxjs";
import { finalize, catchError } from "rxjs/operators";
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class RequestInterceptor implements HttpInterceptor {

    /**
     * Creates an instance of RequestInterceptor.
     */
    constructor(
        private router: Router, 
        private toastr: ToastrService) {}

    /**
     * Intercept HttpRequest and Treat Unauthorised Access
     */
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        //
        return next.handle(req).pipe(
            catchError(response => {
                if (response.status === 401)
                {
                    this.router.navigate(['']);
                    localStorage.removeItem("TOKEN");
                    this.toastr.warning("Por favor, faça login novamente (Sessão Expirada)!", "Alerta");
                    return EMPTY;
                }

                return throwError(response);
            }),
            finalize(() => (console.log('Requisição finalizada!')))
        );
    }

}
