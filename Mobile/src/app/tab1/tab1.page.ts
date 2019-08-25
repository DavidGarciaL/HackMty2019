import { Component } from '@angular/core';
import { HackSerivce } from '../services/hack.service';
import * as moment from 'moment';

@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page {

  // Doughnut
  lineChartColorsPurple = [
    {
      backgroundColor: ['#B8AAE9' , '#7264C9']
    }
  ];
  lineChartColorsGreen = [
    {
      backgroundColor: ['#00DCB8' , '#00C2A2']
    }
  ];
  ivaChargedLabel:any[] = ['Iva Cobrado', 'Total de Ventas'];
  ivaChargedData:any[] = [];
  ivaPaidLabels:any[] = ['Iva Pagado', 'Total de Ventas'];
  ivaPaidData:any[] = [];
  doughnutChartType:string = 'doughnut';
  chargedIva = 0;
  charged = 0;
  paidIva = 0;
  paid = 0;
  ivaToPaid = 0;
  hidden:boolean;
  public doughnutColors:any[] = [
    { backgroundColor: ["#86c7f3", "#ffe199"] },
    { borderColor: ["#AEEBF2", "#FEFFC9"] }];

  constructor(private service: HackSerivce) {
    this.launchTab("2019-01-01"); 
  }

  async launchTab(date){
    this.hidden = false;
    if(localStorage.getItem('token')){
      let res = await this.service.getIVA(date);
      this.chargedIva = res.chargedIva;
      this.charged = res.charged;
      this.paidIva = res.paidIva;
      this.paid = res.paid;
      this.ivaToPaid = res.ivaToPaid;
      this.ivaChargedData = [res.chargedIva, res.charged];
      this.ivaPaidData = [res.paidIva, res.paid];
    }
    this.hidden = true;
  }

  // events
  public chartClicked(e:any):void {
  }

  public chartHovered(e:any):void {
  }

  change(event){
    let date = moment().subtract(event.detail.value, 'months').calendar();
    this.launchTab(date);
  }

  
}
