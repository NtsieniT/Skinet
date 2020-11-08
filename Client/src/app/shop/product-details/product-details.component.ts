import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IProduct } from 'src/app/shared/models/products';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;

  // Activated route gives access to route parameter so that we can
  // get routes activating and pass the ID to our API
  constructor(private shopService: ShopService,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct(){
    // casting to an integer, simply add a plus(+) infront of activatedRoute
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(product => {
        this.product = product;
      },
      error => {
        console.log(error);
      }
      );

  }

}
