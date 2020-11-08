import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

// This will be used for lazy loading
const routes: Routes = [
  {path: '', component: ShopComponent},
  {path: ':id', component: ProductDetailsComponent},
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes) // Routes will be available on the shop mmodule and not on app module
  ],
  exports: [RouterModule]
})
export class ShopRoutingModule { }
