import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Pet } from 'src/app/models/pet';
import { User } from 'src/app/models/user';
import {HubConnection, HubConnectionBuilder} from '@aspnet/signalr'


@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  pets : Pet[] = [];
  users : User[] = [];
  hubConnection : HubConnection | undefined;

  constructor(private http : HttpClient) { 
    this.hubConnection = new HubConnectionBuilder()
    .withUrl("https://localhost:5001/petBookHub")
    .build();

    this.hubConnection.start();

    this.hubConnection.on("Refresh", () => {
      console.log("Refresh");
      this.refresh();
    })
  }

  ngOnInit(): void {
    this.refresh();
  }

  refresh(){
    this.http.get<Pet[]>("https://localhost:5001/pets").subscribe(result => {
      this.pets = result;
    });

    this.http.get<User[]>("https://localhost:5001/users").subscribe(result => {
      this.users = result;
    });
  }

}
