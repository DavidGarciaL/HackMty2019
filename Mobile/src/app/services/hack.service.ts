import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import * as _ from 'lodash';
import {formatDate} from '@angular/common';

@Injectable({
  providedIn: 'root',
})

export class HackSerivce {
  url:string = 'http://konfio.azurewebsites.net/api/'
  httpOptions = {
    headers: new HttpHeaders().set("Authorization", "Bearer " +  localStorage.getItem('token'))
  };

  constructor(private http:HttpClient) { }

  async login(rfc:string, pass:string): Promise<any> {
    return this.http.post(
        this.url + 'Users/Authenticate', 
        {
            "rfc":rfc, 
            "password":pass
        }
    ).toPromise();
  }

  async getAllUsers(): Promise<any> {
    return this.http.get(this.url + 'Users', this.httpOptions).toPromise();
  }

  async getLimitedCharts(date): Promise<any> {
    return this.http.post(
      this.url + 'Transactions/GetVisualization', 
      {
          Limit: date
      }, 
      this.httpOptions
    ).toPromise();
  }

  async getIVA(date): Promise<any> {
    return this.http.post(
        this.url + 'Transactions/GetIva', 
        {
            Limit: date
        }, 
        this.httpOptions
    ).toPromise();
  }

  async getBestCLients(): Promise<any> {
    return this.http.post(
      this.url + 'Transactions/GetBestClients', 
      {
          Top: 5
      }, 
      this.httpOptions
    ).toPromise();
  }

  async getPeriodSales(date): Promise<any> {
    return this.http.post(
      this.url + 'Transactions/GetPeriodSales', 
      {
          Limit: date
      }, 
      this.httpOptions
    ).toPromise();
  }
  
  async getExpenses(date): Promise<any> {
    return this.http.post(
      this.url + 'Transactions/GetExpenses', 
      {
          Limit: date
      }, 
      this.httpOptions
    ).toPromise();
  }

  async getClients(rfc): Promise<any> {
    return this.http.post(
      this.url + 'Transactions/GetClientDEtail', 
      {
          emisorRFC: rfc
      }, 
      this.httpOptions
    ).toPromise();
  }
}