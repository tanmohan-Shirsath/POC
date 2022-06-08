// import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
// import { FormBuilder } from '@angular/forms';
// import {RegisterService} from 'src/app/components/site/register/register.service';
// @Component({
//   selector: 'app-register',
//   templateUrl: './register.component.html',
//   styleUrls: ['./register.component.css']
// })
// export class RegisterComponent {

//   fields;
//   loginForm;
//   firstname: any;

//   constructor( private formBuilder: FormBuilder ) {
//     this.loginForm = this.formBuilder.group({
//       firstname: '',
//       MiddleName: '',
//       LastName: '',
//       Email: '',
//       Password:'',
//       Address:'',
//     });
//    }

//   // tslint:disable-next-line: use-lifecycle-interface
//   ngOnInit() {
//     this.fields = this.loginForm.getItem();
//   }
//   onSubmit(data)
//   {
//     this.fields = this.loginForm.clearCart();
//     this.loginForm.reset();

//     console.warn('Thank you for '); // Here we can give Email id and password for user. 
//     console.log ('Your first name is Submitted ');
//   }
// }
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: any = {};
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.authService.register(this.form).subscribe(
      data => {
        console.log(data);
        this.isSuccessful = true;
        this.isSignUpFailed = false;
      },
      err => {
        this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
      }
    );
  }
}

