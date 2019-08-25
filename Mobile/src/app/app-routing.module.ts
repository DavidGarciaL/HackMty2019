import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    //loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule)
    loadChildren: () => import('./login/login.module').then(m => m.LoginPageModule)
  },  { path: 'modal-facturas', loadChildren: './modal-facturas/modal-facturas.module#ModalFacturasPageModule' },
  { path: 'modal-ventas', loadChildren: './modal-ventas/modal-ventas.module#ModalVentasPageModule' },

];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
