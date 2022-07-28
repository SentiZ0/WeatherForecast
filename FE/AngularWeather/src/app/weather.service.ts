import { Injectable } from '@angular/core';
import { Weather } from './Models/Weather';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor(private httpClient: HttpClient) { }

  getWeather = (city: string): Observable<Weather> => this.httpClient.post<Weather>("https://localhost:7286/WeatherForecast?city=" + city, city);
}
