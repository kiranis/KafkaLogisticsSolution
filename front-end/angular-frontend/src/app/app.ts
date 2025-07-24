import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  constructor(private router: Router) {}

  isTrackingPage(): boolean {
    // Implement your logic to determine if the current page is the tracking page
    return this.router.url.startsWith('/tracking');
  }

  navigateToDemo(trackingNumber: string): void {
    this.router.navigate(['/tracking'], { queryParams: { trackingNumber } });
  }
}