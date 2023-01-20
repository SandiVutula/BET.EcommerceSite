import { Component } from '@angular/core';
import { CartService } from '../service/cart.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  public products : any = [];
  public total !: number;
  public cartItems: any = [];
  public orderData = {};

  constructor(private cartService : CartService, private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.cartService.getProducts()
    .subscribe(res=>{
      this.products = res;
      this.total = this.cartService.getTotalPrice();
    })
  }

  removeItem(item: any){
    this.cartService.removeCartItem(item);
    this.total = this.cartService.getTotalPrice();
  }

  placeOrder() {
    this.http.post('https://localhost:7046/api/Checkout', this.orderData)
  .subscribe(
    (res) => {
      this.router.navigate(['/confirmation']);
    },
    (err) => {
      console.log(err);
    }
  );
  }  
}
