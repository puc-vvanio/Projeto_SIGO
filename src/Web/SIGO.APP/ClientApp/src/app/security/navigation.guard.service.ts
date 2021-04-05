import { Injectable } from '@angular/core';
import { Router, RouterStateSnapshot } from '@angular/router'
import { ToastrService } from 'ngx-toastr';
import jwtDecode, * as jwt_decode from 'jwt-decode';

@Injectable({
    providedIn: 'root'
})

export class NavigationGuardService {
    constructor(private router: Router, private toastr: ToastrService) { }
    private decoded:any;
    private urlnav:any;

    canActivate(routerStateSnapshot: RouterStateSnapshot) {
        let result = true;

        let token = localStorage.getItem("TOKEN");

        if (token != null) {
            this.decoded = jwtDecode(token);
            let role = this.decoded.role;
            this.urlnav = routerStateSnapshot;
   
            if (this.urlnav.data.role != null && this.urlnav.data.role.indexOf(role) === -1) {
                // Regra de autorizacao de acesso
                this.router.navigate(["/GestaoProcessoIndustrial"]);
                this.toastr.warning("Usuário sem acesso a " + this.urlnav.data.modulo + "!", "Alerta");
                //return false;
            }
        }        

        if (token != null && !this.router.navigated) {
            if (routerStateSnapshot.url != "GestaoProcessoIndustrial")
                this.router.navigate(["/GestaoProcessoIndustrial"]);
        }
        else {
            result = this.router.navigated;

            if (!result && routerStateSnapshot.url != "/" && routerStateSnapshot.url.length != 0)
                this.router.navigate([""]);
            else
                result = true;
        }

        return result;
    }
}
