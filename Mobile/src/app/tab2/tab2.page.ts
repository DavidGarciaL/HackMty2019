import { Component, OnInit } from '@angular/core';
import { HackSerivce } from '../services/hack.service';
import * as moment from 'moment';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {
  sales = 0;
  hidden: boolean;
  expenses = 0;
  earnings = 0;
  lineChartLegend = true;
  lineChartType = 'line';
  lineChartLabels = [];
  lineChartOptions = { responsive: true };
  lineChartData = [
    {data: [], label: 'Ingresos'},
    {data: [], label: 'Egresos'}
  ];
  lineChartColors = [
    {
      backgroundColor: 'rgba(0, 220, 184, 0.2)',
      borderColor: '#00C2A2',
      pointBackgroundColor: '#04B49A',
      pointBorderColor: '#04B49A',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    {
      backgroundColor: 'rgba(128, 115, 230, 0.2)',
      borderColor: '#574BA8',
      pointBackgroundColor: '#5C5A92',
      pointBorderColor: '#5C5A92',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(77,83,96,1)'
    }
  ];
  time:any;

  constructor(private service: HackSerivce) {
    let date = moment().subtract(3, 'months').calendar();
    this.launch(date); 
  }

  async launch(date) {
    this.hidden = false;
    if(localStorage.getItem('token')){
      let res = await this.service.getLimitedCharts(date);
      this.expenses = res.expenses;
      this.sales = res.sales;
      this.earnings =- this.earnings;
      this.lineChartLabels = res.incomeList.map(x => x.date);
      this.lineChartData.find(x => x.label === "Ingresos").data = res.incomeList.map(x => {
        return x.total;
      });

      this.lineChartData.find(x => x.label === "Egresos").data = res.outcomeList.map(x => {
        return x.total;
      });
    }
    this.hidden = true;
  }

  randomize():void {
    let _lineChartData = new Array(this.lineChartData.length);
    for (let i = 0; i < this.lineChartData.length; i++) {
      _lineChartData[i] = {data: new Array(this.lineChartData[i].data.length), label: this.lineChartData[i].label};
      for (let j = 0; j < this.lineChartData[i].data.length; j++) {
        _lineChartData[i].data[j] = Math.floor((Math.random() * 100) + 1);
      }
    }
    this.lineChartData = _lineChartData;
  }

  change(event){
    let date = moment().subtract(event.detail.value, 'months').calendar();
    this.launch(date);
  }
}
