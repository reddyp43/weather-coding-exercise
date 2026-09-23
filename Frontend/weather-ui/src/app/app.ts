import { Component, inject, OnInit, signal } from '@angular/core';
import { Weather } from './models/weather.model';
import { WeatherService } from './services/weather.service';

@Component({
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html'
})
export class App implements OnInit {
  private readonly weatherService = inject(WeatherService);

  weatherData = signal<Weather[]>([]);
  isLoading = signal(false);
  errorMessage = signal('');

  ngOnInit(): void {
    this.loadWeather();
  }

  loadWeather(): void {
    this.isLoading.set(true);
    this.errorMessage.set('');

    this.weatherService.getWeather().subscribe({
      next: (data) => {
        this.weatherData.set(data);
        this.isLoading.set(false);
      },
      error: () => {
        this.errorMessage.set('Unable to load weather data.');
        this.isLoading.set(false);
      }
    });
  }
}
