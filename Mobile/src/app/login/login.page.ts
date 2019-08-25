import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { HackSerivce } from '../services/hack.service'


@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  rfc:string = '';
  pass:string = '';

  constructor(private router: Router, private service: HackSerivce) { 
  }

  async ngOnInit() {
  }

  async login(){
    let access_token = (await this.service.login(this.rfc,this.pass)).access_token;
    if(access_token){
      localStorage.setItem('token', access_token);
      this.router.navigate(['/tabs/tab1']);
    }
  }

}
