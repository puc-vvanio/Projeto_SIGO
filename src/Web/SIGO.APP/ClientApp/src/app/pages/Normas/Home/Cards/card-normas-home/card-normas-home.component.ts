import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-card-normas-home',
  templateUrl: './card-normas-home.component.html',
  styleUrls: ['./card-normas-home.component.css']
})
export class CardNormasHomeComponent implements OnInit {
    /**
     * 
     */
    @Input() Title: string;
    /**
     * 
     */
    @Input() Descricao: string;
    /**
     * 
     */
    @Input() ActionText: string;
    /**
     * 
     */
    @Input() Image: string;
    /**
     * 
     */
    @Input() Value: string;

    /**
     * 
     */
    @Output() ActionClicked = new EventEmitter();

    /**
     * Creates an instance of class CardNormasHomeComponent
     */
    constructor() {}
    
    /**
     * Initializes the component
     */
    ngOnInit(): void {
    }

    /**
     * Handle Action Click
     */
    public onActionClick() {
        this.ActionClicked.emit(this.Value);
    }
}
