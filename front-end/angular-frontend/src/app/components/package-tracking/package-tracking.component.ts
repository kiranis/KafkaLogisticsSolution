import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';


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

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute
    ) {
      this.route.queryParams.subscribe(params => {
        if (params['demo']) {
          this.trackingNumber = params['demo'];
          this.trackPackage(); // Auto-trigger tracking
        }
      });
    }

  trackPackage() {
  }

  getCurrentStatus() {
  }

  formatETA(dateTime: string) {
  }
}