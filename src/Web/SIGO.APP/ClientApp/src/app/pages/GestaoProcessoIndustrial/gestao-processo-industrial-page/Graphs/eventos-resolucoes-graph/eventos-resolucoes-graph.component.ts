import { Component, Input, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-eventos-resolucoes-graph',
  templateUrl: './eventos-resolucoes-graph.component.html',
  styleUrls: ['./eventos-resolucoes-graph.component.css']
})

export class EventosResolucoesGraphComponent implements OnInit {

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
    public barChartLabels = ['00-02h', '02-04h', '04-06h', '06-08h', '08-10h', '10-12h', '24-14h', '14-16h', '16-18h', '18-20h', '20-22h', '22-24h'];

    /**
     *
     */
    public barChartType = 'bar';

    /**
     *
     */
    public barChartLegend = true;

    /**
     *
     */
    public BarChartData = [
      { data: [7, 9, 13, 17, 22, 27, 33, 32, 26, 21, 13, 9], label: 'Eventos' },
      { data: [5, 5, 7, 21, 23, 29, 30, 33, 24, 18, 11, 5], label: 'Resoluções' }
    ];

    /**
     *
     */
    @Input() BarChartDataBind = [];

    /**
     *
     */
    @Input() Title: string;

    /**
     * Creates an instance of OrcamentosPedidosMesesGraphComponent.
     */
    constructor() { }

    /**
     * Initializes the component
     */
    ngOnInit(): void {
    }

    /**
     * Handle BarChart data changes
     */
    ngOnChanges(Changes: SimpleChanges) {
        if (Changes.BarChartDataBind != undefined && Changes.BarChartDataBind.currentValue != undefined){
            //debugger;
            this.BarChartData = [
                { data: [7, 9, 13, 17, 22, 27, 33, 32, 26, 21, 13, 9, Changes.BarChartDataBind.currentValue[0].data[0]], label: 'Eventos' },
                { data: [5, 5, 7, 21, 23, 29, 30, 33, 24, 18, 11, 5, Changes.BarChartDataBind.currentValue[0].data[1]], label: 'Resoluções' }
            ];
        }
    }
}
