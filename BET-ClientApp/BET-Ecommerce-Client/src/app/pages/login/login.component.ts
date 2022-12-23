import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, Validators} from "@angular/forms";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit{
  public loginForm : FormGroup = new FormGroup({
    EmailAddress:new FormControl('', [Validators.required, Validators.email]),
    Password:new FormControl('', [Validators.required, Validators.minLength(6)]),
  });

  constructor(private httpClient: HttpClient, private router: Router){}

  ngOnInit(): void {
  }
  
  validateInput(input:any){
    return !this.loginForm.get(input)?.valid &&
            this.loginForm.get(input)?.touched;
}

  loginUser(){
    this.httpClient.post<any>("https://localhost:7046/api/Account/login", this.loginForm.value)
    .subscribe(res=>{
      console.log("Login successful!");
      this.loginForm.reset();
      this.router.navigate(['products']);
    }, err=>{
      console.log("Login unsuccessful, Something went wrong!")
    })
     
  }
}
