import { Component, OnInit } from '@angular/core';
import { NavParams, ModalController } from '@ionic/angular';
import { HackSerivce } from '../services/hack.service';

@Component({
  selector: 'app-modal-clientes',
  templateUrl: './modal-clientes.page.html',
  styleUrls: ['./modal-clientes.page.scss'],
})

export class ModalClientesPage {
  clientes:any = [];

  constructor(private service: HackSerivce, private navParams: NavParams, public modalCt: ModalController) { 
    this.loadDate();
  }

  async loadDate(){
    this.clientes = await this.service.getClients(localStorage.getItem('rfc'));    
  }

  closeModal() {
    this.modalCt.dismiss();
  }
}
