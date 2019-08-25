import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ChartsModule } from 'ng2-charts';
import {HttpClientModule} from '@angular/common/http';
import { ModalFacturasPage } from '../app/modal-facturas/modal-facturas.page';
import { ModalVentasPage } from '../app/modal-ventas/modal-ventas.page';
import { ModalClientesPage } from '../app/modal-clientes/modal-clientes.page';

@NgModule({
  declarations: [AppComponent, ModalFacturasPage, ModalVentasPage, ModalClientesPage],
  entryComponents: [ModalFacturasPage, ModalVentasPage,ModalClientesPage],
  imports: [BrowserModule, IonicModule.forRoot(), AppRoutingModule, ChartsModule, HttpClientModule],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
