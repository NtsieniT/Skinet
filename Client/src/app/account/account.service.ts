import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, of, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUser } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;

  // BehaviorSubject is to emit its initial value
  // ReplaySubject can specify the number of values we want the ReplaySubject to hold

  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  // helper method is used to persist user
loadCurrentUser(token: string){

  if (token === null){
    this.currentUserSource.next(null);
    return of(null);
  }
  let headers = new HttpHeaders();
  headers = headers.set('Authorization', `Bearer ${token}`);

  return this.http.get(this.baseUrl + 'account', {headers}).pipe(
    map((user: IUser) => {
      if (user) {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
      }
    })
  );

}

  login(values: any){
    return this.http.post(this.baseUrl + 'account/login', values).pipe(
      map((user: IUser) => {
        if (user){
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    );

  }

  register(values: any){
    return this.http.post(this.baseUrl + 'account/register', values).pipe(
      map((user: IUser) => {
        if (user){
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  logout(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/')
  }


  checkEmailExists(email: string){
    return this.http.get(this.baseUrl + 'account/emailexists?email=' + email);
  }


}
