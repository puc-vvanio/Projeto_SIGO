import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

    /**
     * Creates an instance of NavMenuComponent.
     */
    constructor(
        private router: Router, 
        private route: ActivatedRoute, 
        private toastr: ToastrService) {}

    /**
     * Initializes the component
     */
    ngOnInit(): void {}

    /**
     * Performs user logout
     */
    public sigoLogout(){
        this.router.navigate(['']);
        this.toastr.success('Sessão encerrada!');
    }
}
