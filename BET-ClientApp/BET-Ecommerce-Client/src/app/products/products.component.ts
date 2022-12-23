import { Component, OnInit } from '@angular/core';
import { ApiService } from '../service/api.service';
import { CartService } from '../service/cart.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent  implements OnInit {
  public totalItem : number = 0;
  public productList : any ;
  public filterProducts : any;
  public page : any;

  constructor(private api : ApiService, private cartService : CartService) { }

  ngOnInit(): void {
    
    this.cartService.getProducts()
    .subscribe(res=>{
      this.totalItem = res.length;
    })

    this.api.getProduct()
    .subscribe(res=>{
      this.productList = res;
      this.filterProducts = res;
      this.productList.forEach((a:any) => {
        Object.assign(a,{quantity:1,total:a.price});
      });
      console.log(this.productList)
    });
  }

  addtocart(item: any){
    this.cartService.addToCart(item);
  }

  filter(product:string){
    this.filterProducts = this.productList
    .filter((a:any)=>{
      if(a.product == product || product==''){
        return a;
      }
    })
  }
}
