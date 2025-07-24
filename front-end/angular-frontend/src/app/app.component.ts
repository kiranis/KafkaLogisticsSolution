import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Location } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive, CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-frontend';

  constructor(
    private router: Router,
    private location: Location
  ) {}

  isTrackingPage(): boolean {
    return this.location.path() === '/tracking';
  }

  navigateToDemo(trackingNumber: string): void {
    this.router.navigate(['/tracking'], { 
      queryParams: { demo: trackingNumber } 
    }).then(() => {
      console.log(`Demo navigation with tracking: ${trackingNumber}`);
    });
  }
}