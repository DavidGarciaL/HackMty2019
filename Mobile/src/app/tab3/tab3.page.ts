import { Component } from '@angular/core';
import { HackSerivce } from '../services/hack.service';
import { ModalClientesPage } from '../modal-clientes/modal-clientes.page';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page {
  clients = [];
  hidden:boolean;

  constructor(private service: HackSerivce, private modal: ModalController) {
    this.getBestClients();
  }

  async getBestClients() {
    this.hidden = false;
    this.clients = await this.service.getBestCLients();
    this.hidden = true;
  }

  async openModalFact(rfc: string) {
    localStorage.setItem('rfc', rfc);
    const myModal = await this.modal.create(
     {
      component: ModalClientesPage,
      componentProps: this.modal
     }
    );
    myModal.present();
  }

}
