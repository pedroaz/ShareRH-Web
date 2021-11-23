import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  username : string = "";
  password : string = "";
  errorMessage : string = "";

  constructor(private http: HttpClient, private router : Router) { }

  ngOnInit(): void {
  }

  login(){
    this.http.post("https://localhost:5001/users/auth", {
      name: this.username,
      password: this.password
    }).subscribe(response => {
      const token = (<any>response).token;
      console.log(token);
      localStorage.setItem("jwt", token);
      this.router.navigateByUrl("home");
    }, err => {
      this.errorMessage = "Login Inválido"
    })
  }

}
