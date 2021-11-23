import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {

  maxAmountOfStars: number = 5;
  readOnly : Boolean = true;

  constructor(private router : Router) { }

  ngOnInit(): void {
  }

  goToLogin(){
    this.router.navigateByUrl("login");
  }

}
