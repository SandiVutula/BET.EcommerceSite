import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  constructor(){ }
  showPassword : boolean = false;

  handlePasswordVisibility(){
    this.showPassword = !this.showPassword;
  }
/*
  redirectToRegister(){
    this.router.navigateByUrl('register')
  }*/
}
