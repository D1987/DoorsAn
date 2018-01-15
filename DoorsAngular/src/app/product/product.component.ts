import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  product: any;

  constructor(private http: Http) { }

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.http.get('http://localhost:63530/api/products').subscribe(response =>{
      console.log(response);
    })
  }

}
