import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products: any;

  constructor(private http: Http) { }

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.http.get('http://localhost:63530/api/product').subscribe(response => {
      this.products = response.json()
    });
  }

}
