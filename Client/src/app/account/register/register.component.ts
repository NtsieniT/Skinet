import { Component, OnInit } from '@angular/core';
import { AsyncValidatorFn, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { of, timer } from 'rxjs';
import { delay, map, switchMap } from 'rxjs/operators';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {


  registerForm: FormGroup;
  errors: string[];

  constructor(private fb: FormBuilder, private accountService: AccountService,
              private router: Router) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.registerForm = this.fb.group({
      displayName: [null, [Validators.required]],
      email: [null, [Validators.required,
                     Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')],
                     // called when both validators have passed
                     [this.validateEmailNotTaken()]
                    ],
      password: [null, [Validators.required]]

    });
  }

  onSubmit(){
   this.accountService.register(this.registerForm.value).subscribe(response => {
     this.router.navigateByUrl('/shop');
   },
    error => {
      console.log(error);
      this.errors = error.errors;
    }
   );
  }

  // this method will make a call to the server to check if email exists in the server
  // and the call will be asyncronuous with a delay to make the check as the user types in 
  // the email address in the form
  validateEmailNotTaken(): AsyncValidatorFn {
    return control => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value){
            return of(null);
          }
          return this.accountService.checkEmailExists(control.value).pipe(
            map(results => {
              return results ? {emailExists: true} : null;
            })
          );
        })
      );
    }
  }

}
