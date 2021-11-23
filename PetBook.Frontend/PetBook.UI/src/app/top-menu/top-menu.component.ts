import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  styleUrls: ['./top-menu.component.css']
})
export class TopMenuComponent implements OnInit {

  constructor(private router : Router) { }

  items: MenuItem[] = [];

    ngOnInit() {
        this.items = [
            {label: "Home", command: () => {this.router.navigateByUrl("home")}},
            {label: 'Quit', command: () => {
              localStorage.removeItem("jwt");
              this.router.navigateByUrl("login")
            }}
        ];
    }

}
