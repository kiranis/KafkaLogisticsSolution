# KafkaLogisticsSolution

**KafkaLogisticsSolution** is a distributed logistics microservice suite built on **.NET 8**, designed to process package scan events and predict Estimated Time of Arrival (ETA) using event-driven architecture with Apache Kafka.

---

## Solution Architecture

This solution demonstrates modern microservices patterns with real-time event streaming for logistics operations:

### ScanIngestor Service

- **Event Producer** - Publishes scan events to Kafka topics
- **REST API** - Receives package scan data from logistics checkpoints
- **Real-time Processing** - Handles high-volume scan events from sorting centers
- **Integration Ready** - Designed for scanner hardware and logistics systems

### ETAConsumer Service

- **Event Consumer** - Subscribes to Kafka scan events in real-time
- **ETA Prediction Engine** - Applies algorithms to calculate delivery estimates
- **Data Persistence** - Stores predictions and audit trails in PostgreSQL
- **REST API** - Exposes ETA predictions with Swagger documentation

### Frontend Application

- **Angular 20** - Modern standalone component architecture
- **Real-time Tracking** - Package tracking interface with live updates
- **Responsive Design** - Works on desktop and mobile devices
- **Auto-refresh** - Live data updates every 30 seconds

---

## Tech Stack

**Backend Services:**
- **.NET 8** - Modern C# with minimal APIs
- **Apache Kafka** - Event streaming platform
- **PostgreSQL** - Reliable data persistence
- **Entity Framework Core** - ORM with migrations
- **Swagger/OpenAPI** - API documentation

**Frontend:**
- **Angular 20** - TypeScript-based SPA framework
- **RxJS** - Reactive programming for real-time updates
- **Angular Router** - Client-side routing
- **Server-Side Rendering** - Improved performance and SEO

**Infrastructure:**
- **Docker Compose** - Local development environment
- **Kafka + Zookeeper** - Message broker setup
- **PostgreSQL** - Database container

---

## Quick Start

### 1. Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18+ for Angular)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)

### 2. Clone and Setup

```bash
git clone <repository-url>
cd KafkaLogisticsSolution

# Start infrastructure
docker-compose up -d

# Install frontend dependencies
cd front-end/angular-frontend
npm install
cd ../..
```

### 3. Database Setup

```bash
cd ETAConsumer
dotnet ef database update
cd ..
```

### 4. Start All Services

```bash
# Terminal 1 - ScanIngestor Service
dotnet run --project ScanIngestor

# Terminal 2 - ETAConsumer Service  
dotnet run --project ETAConsumer

# Terminal 3 - Angular Frontend
cd front-end/angular-frontend
ng serve
```

### 5. Access Applications

- **Frontend**: http://localhost:4200
- **ScanIngestor API**: http://localhost:5000/swagger
- **ETAConsumer API**: http://localhost:5001/swagger

---

## Project Structure

```
KafkaLogisticsSolution/
│
├── ScanIngestor/                    # Producer microservice
│   ├── Controllers/                 # REST API endpoints
│   ├── Domain/                      # Business models
│   ├── Infrastructure/              # Kafka publishers
│   └── ScanIngestor.csproj
│
├── ETAConsumer/                     # Consumer microservice
│   ├── Controllers/                 # ETA prediction API
│   ├── Domain/                      # ETA calculation logic
│   ├── Infrastructure/              # Database & Kafka
│   ├── Services/                    # Background consumers
│   └── ETAConsumer.csproj
│
├── front-end/angular-frontend/      # Frontend application
│   ├── src/app/components/          # UI components
│   ├── src/app/services/            # API services
│   └── src/app/models/              # TypeScript interfaces
│
├── docker-compose.yml               # Infrastructure setup
├── KafkaLogisticsSolution.sln       # Solution file
└── README.md
```

---

## Configuration

### Backend Services

Update `appsettings.json` in each project:

#### ETAConsumer Configuration

```json
{
  "ConnectionStrings": {
    "PostgreSql": "Host=localhost;Port=5432;Database=etadb;Username=postgres;Password=yourpassword"
  },
  "Kafka": {
    "BootstrapServers": "localhost:9092",
    "Topic": "scan.events",
    "GroupId": "eta-consumer-group"
  }
}
```

#### ScanIngestor Configuration

```json
{
  "Kafka": {
    "BootstrapServers": "localhost:9092",
    "Topic": "scan.events"
  }
}
```

### Frontend Configuration

```typescript
// src/environments/environment.ts
export const environment = {
  production: false,
  scanApiUrl: 'http://localhost:5000/api',
  etaApiUrl: 'http://localhost:5001/api'
};
```

---

## API Documentation

### ScanIngestor Endpoints

| Method | Route                    | Description                    |
|--------|--------------------------|--------------------------------|
| POST   | `/api/scans`            | Submit new package scan        |
| GET    | `/api/scans/{packageId}` | Get scan history for package  |
| GET    | `/health`               | Service health check           |

### ETAConsumer Endpoints

| Method | Route                           | Description                    |
|--------|---------------------------------|--------------------------------|
| GET    | `/api/eta-predictions`          | List latest ETA predictions    |
| GET    | `/api/eta-predictions/{packageId}` | Get ETA for specific package |
| POST   | `/api/eta-predictions/calculate` | Trigger manual ETA calculation |
| GET    | `/health`                       | Service health check           |

---

## Sample Usage

### Track a Package

1. **Open Frontend**: Navigate to http://localhost:4200
2. **Enter Tracking Number**: Use `PKG-2024-001234`
3. **View Results**: See scan timeline and ETA prediction
4. **Live Updates**: Watch for real-time updates

### Submit Scan Events

```bash
# POST to ScanIngestor
curl -X POST http://localhost:5000/api/scans \
  -H "Content-Type: application/json" \
  -d '{
    "packageId": "PKG-2024-001234",
    "location": "Chicago Hub",
    "scanType": "IN_TRANSIT",
    "timestamp": "2024-07-23T10:30:00Z"
  }'
```

---

## Development

### Code Generation

```bash
# Backend - Add new controller
dotnet new webapi -n NewService

# Frontend - Generate components
ng generate component components/new-feature
ng generate service services/new-service
```

### Testing

```bash
# Backend tests
dotnet test

# Frontend tests
cd front-end/angular-frontend
ng test
ng e2e
```

### Database Migrations

```bash
cd ETAConsumer
dotnet ef migrations add NewMigration
dotnet ef database update
```

---

## Docker Deployment

### Build Images

```bash
# Backend services
docker build -t scan-ingestor -f ScanIngestor/Dockerfile .
docker build -t eta-consumer -f ETAConsumer/Dockerfile .

# Frontend
cd front-end/angular-frontend
docker build -t logistics-frontend .
```

### Production Deployment

```bash
docker-compose -f docker-compose.prod.yml up -d
```

---

## Architecture Patterns

- **Event-Driven Architecture** - Loose coupling via Kafka messaging
- **CQRS Pattern** - Separate read/write operations
- **Microservices** - Independent, scalable services
- **Clean Architecture** - Domain-centric design
- **Repository Pattern** - Data access abstraction
- **Dependency Injection** - Testable, maintainable code

---

## Monitoring & Observability

### Health Checks
- Built-in health endpoints for all services
- Database connectivity monitoring
- Kafka broker health validation

### Logging
- Structured logging with Serilog
- Correlation IDs for request tracing
- Error aggregation and alerting

### Metrics (Future)
- Prometheus integration
- Grafana dashboards
- Custom business metrics

---

## Roadmap

**Phase 1 (Current)**
- ✅ Basic event-driven architecture
- ✅ Real-time package tracking
- ✅ ETA prediction engine

**Phase 2 (Planned)**
- 🔄 Machine Learning ETA models
- 🔄 Advanced monitoring with Prometheus
- 🔄 Kubernetes deployment manifests

**Phase 3 (Future)**
- 📋 Multi-tenant support
- 📋 Advanced analytics dashboard
- 📋 Mobile application
- 📋 Integration with major carriers

---

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## License

MIT License — see [LICENSE](LICENSE) file for details.

---

## Contact

**Anis Toauti**  
Senior .NET Developer | Cloud & DevOps Enthusiast  
[LinkedIn](https://www.linkedin.com/in/anistouati) | [GitHub](https://github.com/kiranis) | Montréal, QC