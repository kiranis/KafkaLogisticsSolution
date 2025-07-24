# Logistics Tracking Frontend

Angular 20 frontend application for the **Kafka Logistics Solution** - a real-time package tracking system built with event-driven microservices architecture.

## Overview

This frontend provides an intuitive interface for tracking packages in real-time, displaying scan events, and showing ETA predictions powered by the backend Kafka microservices.

### Key Features

- **Real-time Package Tracking** - Track packages by entering tracking numbers
- **Scan Event Timeline** - View complete package journey with location updates
- **ETA Predictions** - See estimated delivery times with confidence levels
- **Auto-refresh** - Live updates every 30 seconds for active tracking
- **Responsive Design** - Works on desktop and mobile devices

## Architecture Integration

This Angular app integrates with the Kafka Logistics Solution backend:

- **ScanIngestor Service** (`http://localhost:5000`) - Retrieves scan event history
- **ETAConsumer Service** (`http://localhost:5001`) - Fetches ETA predictions
- **Event-driven Updates** - Real-time data via Kafka message streaming

## Technology Stack

- **Angular 20** with standalone components
- **TypeScript** for type safety
- **RxJS** for reactive programming
- **Angular Router** for navigation
- **HttpClient** for API communication
- **Server-Side Rendering (SSR)** support

## Prerequisites

- **Node.js** (v18+ recommended)
- **npm** or **yarn**
- **Angular CLI** (`npm install -g @angular/cli`)
- Backend services running (ScanIngestor & ETAConsumer)

## Getting Started

### 1. Install Dependencies

```bash
cd front-end/angular-frontend
npm install
```

### 2. Start Backend Services

Ensure the backend microservices are running:

```bash
# From project root
docker-compose up -d
dotnet run --project ScanIngestor
dotnet run --project ETAConsumer
```

### 3. Start Development Server

```bash
ng serve
```

Navigate to `http://localhost:4200/` to access the application.

### 4. Test Package Tracking

Try these sample tracking numbers:
- `PKG-2024-001234`
- `LOG-2024-567890`
- `SHIP-2024-999999`

## Development

### Code Scaffolding

Generate new components:

```bash
ng generate component components/component-name
ng generate service services/service-name
ng generate interface models/interface-name
```

### Project Structure

```
src/app/
├── components/
│   └── package-tracking/          # Main tracking component
├── models/
│   └── tracking.models.ts         # TypeScript interfaces
├── services/
│   └── tracking.service.ts        # API service layer
├── app.component.*                # Root component
└── main.ts                       # Bootstrap configuration
```

### API Endpoints

The frontend connects to these backend endpoints:

```typescript
// Scan Events
GET http://localhost:5000/api/scans/{packageId}

// ETA Predictions  
GET http://localhost:5001/api/eta-predictions/{packageId}
```

## Building

### Development Build
```bash
ng build
```

### Production Build
```bash
ng build --configuration production
```

Build artifacts are stored in the `dist/` directory.

### Server-Side Rendering
```bash
npm run build:ssr
npm run serve:ssr
```

## Testing

### Unit Tests
```bash
ng test
```

### End-to-End Tests
```bash
ng e2e
```

### Test Coverage
```bash
ng test --code-coverage
```

## Docker Support

### Build Docker Image
```bash
docker build -t logistics-frontend .
```

### Run with Docker
```bash
docker run -p 4200:80 logistics-frontend
```

## Environment Configuration

### Development
- API Base URLs point to localhost services
- Hot reload enabled
- Debug mode active

### Production
- Optimized bundles
- Service worker enabled
- Production API endpoints

## Performance Features

- **Lazy Loading** - Components loaded on demand
- **Tree Shaking** - Unused code elimination
- **AOT Compilation** - Ahead-of-time compilation
- **Service Workers** - Offline capability (production)
- **Code Splitting** - Optimized bundle sizes

## Configuration

### API Endpoints
Update service URLs in `src/environments/`:

```typescript
export const environment = {
  production: false,
  scanApiUrl: 'http://localhost:5000/api',
  etaApiUrl: 'http://localhost:5001/api'
};
```

### Proxy Configuration
For development API proxying, see `proxy.conf.json`.

## Deployment

### Development
```bash
ng serve --host 0.0.0.0 --port 4200
```

### Production
```bash
ng build --configuration production
# Deploy dist/ folder to web server
```

### Docker Deployment
```bash
docker-compose -f docker-compose.prod.yml up
```

## Troubleshooting

### Common Issues

**CORS Errors**: Ensure backend services have CORS configured for `http://localhost:4200`

**API Connection**: Verify backend services are running on expected ports

**Build Errors**: Clear cache with `ng cache clean` or `rm -rf node_modules && npm install`

## Related Documentation

- [Kafka Logistics Solution](../../README.md) - Main project documentation
- [ScanIngestor API](../../ScanIngestor/README.md) - Scan event service
- [ETAConsumer API](../../ETAConsumer/README.md) - ETA prediction service
- [Angular CLI Documentation](https://angular.dev/tools/cli)

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit changes (`git commit -m 'Add amazing feature'`)
4. Push to branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is part of the Kafka Logistics Solution. See the main project LICENSE file for details.

## Support

For technical support or questions:
- Open an issue in the main repository
- Check existing documentation
- Review backend service logs for API issues