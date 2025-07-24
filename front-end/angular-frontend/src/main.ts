import { bootstrapApplication } from '@angular/platform-browser';
import { Routes } from '@angular/router';
import { AppComponent } from './app/app.component';
import { PackageTrackingComponent } from './app/components/package-tracking/package-tracking.component';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';

const routes: Routes = [
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