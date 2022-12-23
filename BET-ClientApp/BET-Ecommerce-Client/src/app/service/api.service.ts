import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = ' https://localhost:7046/api/';
 
  constructor(private http : HttpClient) { }

  getProduct(){
    return this.http.get<any>(this.baseUrl + "Product/products")
    .pipe(map((res:any)=>{
      return res;
    }))
  }
}
