import { Component, Input, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-orcamentos-pedidos-mes-graph',
  templateUrl: './orcamentos-pedidos-mes-graph.component.html',
  styleUrls: ['./orcamentos-pedidos-mes-graph.component.css']
})
export class OrcamentosPedidosMesGraphComponent implements OnInit {
    /**
     * 
     */
    public barChartOptions = {
        scaleShowVerticalLines: false,
        responsive: true
    };

    /**
     * 
     */
    public barChartLabels = ['Orçamentos', 'Pedidos'];

    /**
     * 
     */
    public barChartType = 'pie';

    /**
     * 
     */
    public barChartLegend = true;

    /**
     * 
     */
     public BarChartData = [{data: [50,50]}];

    /**
     * 
     */
    @Input() BarChartDataBind = [{data: [50,50]}];

    /**
     * 
     */
    @Input() Title: string;

    /**
     * Creates an instance of OrcamentosPedidosMesGraphComponent.
     */
    constructor() { }

    /**
     * Initializes the component
     */
    ngOnInit(): void {
    }

    /**
     *  Handle BarChart data changes
     */
    ngOnChanges(Changes: SimpleChanges) {
        if (Changes.BarChartDataBind != undefined && Changes.BarChartDataBind.currentValue != undefined) {
            this.BarChartData = Changes.BarChartDataBind.currentValue;
        }
    }
}
