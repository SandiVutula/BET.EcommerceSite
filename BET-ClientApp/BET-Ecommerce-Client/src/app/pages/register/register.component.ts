import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  showPassword : boolean = false;
  showConfirmPassword : boolean = false;

  handlePasswordVisibility(){
    this.showPassword = !this.showPassword;
  }

  handleConfirmPasswordVisibility(){
    this.showConfirmPassword = !this.showConfirmPassword;
  }

  /*redirectToLogin(){
    this.router.navigateByUrl('login')
  }*/
}
