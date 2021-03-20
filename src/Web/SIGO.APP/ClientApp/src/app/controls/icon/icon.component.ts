import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-icon',
  templateUrl: './icon.component.html',
  styleUrls: ['./icon.component.css']
})
export class IconComponent implements OnInit {

    /**
     * 
     */
	@Input() Title: string;

    /**
     * 
     */
	@Input() ClassIcon: string;
	
	/**
	 * Creates an instance of IconComponent.
	 */
	constructor() {}

	/**
	 * Initializes the component
	 */
	ngOnInit(): void {}
}
