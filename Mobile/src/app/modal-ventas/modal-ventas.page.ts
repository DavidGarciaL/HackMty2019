import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-modal-ventas',
  templateUrl: './modal-ventas.page.html',
  styleUrls: ['./modal-ventas.page.scss'],
})
export class ModalVentasPage {
  ventas:any = [];

  constructor(private  modalCt: ModalController) {
    this.ventas =   JSON.parse(localStorage.getItem('invoices'));
   }

  closeModal() {
    this.modalCt.dismiss();
  }
}
