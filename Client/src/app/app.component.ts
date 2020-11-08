import { Component } from '@angular/core';
import { IProduct } from './shared/models/products';
import { HttpClient } from '@angular/common/http';
import { IPagination } from './shared/models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Skinet';
  products: IProduct[];

  constructor(private http: HttpClient){}

  // tslint:disable-next-line:use-lifecycle-interface
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/products?pageSize=50').subscribe(
      (response: IPagination) => {
        this.products = response.data;
      },
      error => {
        console.log(error);
      }
    );
  }

}
