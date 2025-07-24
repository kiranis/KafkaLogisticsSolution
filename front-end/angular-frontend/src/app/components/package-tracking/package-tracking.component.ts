import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-package-tracking',
  standalone: true,
  imports: [CommonModule, FormsModule], // Add FormsModule here
  templateUrl: './package-tracking.component.html',
  styleUrls: ['./package-tracking.component.css']
})
export class PackageTrackingComponent {
formatDateTime(arg0: any) {
throw new Error('Method not implemented.');
}
  trackingNumber: string = '';
  etaPrediction: any = null;
scanEvents: any;
loading: any;
error: any;

  constructor(private http: HttpClient) {}

  trackPackage() {
    // Your tracking logic here
  }

  getCurrentStatus() {
    // Your status logic here
  }

  formatETA(dateTime: string) {
    // Your ETA formatting logic here
  }
}