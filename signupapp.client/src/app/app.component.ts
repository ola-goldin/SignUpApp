import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) { }

  title = 'signupapp.client';
}
