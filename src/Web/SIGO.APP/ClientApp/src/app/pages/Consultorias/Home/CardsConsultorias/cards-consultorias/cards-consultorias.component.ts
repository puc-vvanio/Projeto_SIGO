import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-cards-consultorias',
  templateUrl: './cards-consultorias.component.html',
  styleUrls: ['./cards-consultorias.component.css']
})

export class CardsConsultoriasComponent implements OnInit {

    /**
     *
     */
    @Input() CardStyle: string;

    /**
     *
     */
    @Input() Title: string;

    /**
     *
     */
    @Input() SubTitle: string;

    /**
     *
     */
    @Input() Description: string;

    /**
     * Creates an instance of CardsConsultoriasComponent.
     */
    constructor() { }

    /**
     * Initializes the component
     */
    ngOnInit(): void {
    }

}
