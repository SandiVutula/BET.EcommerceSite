import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, Validators} from "@angular/forms";
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit{
  public registerForm : FormGroup = new FormGroup({
    EmailAddress:new FormControl('', [Validators.required, Validators.email]),
    Password:new FormControl('', [Validators.required, Validators.minLength(6)]),
    ConfirmPassword:new FormControl('', [Validators.required, Validators.minLength(6)])
  });

  constructor(private httpClient: HttpClient, private router: Router){}

  ngOnInit(): void {
  }

  validateInput(input:any){
      return !this.registerForm.get(input)?.valid &&
              this.registerForm.get(input)?.touched;
  }
  registerUser(){
    this.httpClient.post<any>("https://localhost:7046/api/Account/register", this.registerForm.value)
    .subscribe(res=>{
      alert("Sign up successful!");
      this.registerForm.reset();
      this.router.navigate(['login']);
    }, err=>{
      console.log("Something went wrong!")
    })
  }
}
