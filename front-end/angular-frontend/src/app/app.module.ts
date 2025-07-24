import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { PackageTrackingComponent } from './components/package-tracking/package-tracking.component';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter, Routes } from '@angular/router';

const routes : Routes = [
  { path: '', redirectTo: '/tracking', pathMatch: 'full' },
  { path: 'tracking', component: PackageTrackingComponent },
  { path: '**', redirectTo: '/tracking' }
];

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient()
  ]
}).catch(err => console.error(err));