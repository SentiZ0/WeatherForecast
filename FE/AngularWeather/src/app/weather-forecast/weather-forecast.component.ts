import { Component, OnInit } from '@angular/core';
import { Weather } from '../Models/Weather';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.css']
})
export class WeatherForecastComponent implements OnInit {

  weather: Weather = {} as Weather;

  city : string = '';

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
  }

  getWeather() : void
  {
    this.weatherService.getWeather(this.city).subscribe(weather => this.weather = weather);
  }

  isNameCheck(): boolean {
    if (typeof this.weather.country != 'undefined' && this.weather.country) {
      return false;
    }
    return true;
  }
}


