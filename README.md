# KafkaLogisticsSolution

**KafkaLogisticsSolution** is a distributed logistics microservice suite built on **.NET 8**, designed to process package scan events and predict Estimated Time of Arrival (ETA) using event-driven architecture.

---

## Solution Architecture

This solution contains two independent but coordinated services:

### 🔹 ScanIngestor

- Publishes scan events to a Kafka topic.
- Simulates or integrates with scanners at sorting centers and delivery checkpoints.
- Acts as a Kafka producer in the logistics event pipeline.

### 🔹 ETAConsumer

- Subscribes to Kafka scan events.
- Applies ETA prediction logic.
- Stores results in a PostgreSQL database.
- Exposes a REST API with Swagger documentation.

---

## Tech Stack

- **.NET 8**
- **Apache Kafka**
- **PostgreSQL**
- **Entity Framework Core**
- **Swagger / OpenAPI**
- **Docker (recommended for Kafka & Postgres setup)**

---

## Getting Started

### 1. Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- Kafka and Zookeeper (local or Confluent Cloud)
- PostgreSQL server

---

### 2. Repository Structure

```
KafkaLogisticsSolution.sln
│
├── ScanIngestor/
│   └── ScanIngestor.csproj
│
├── ETAConsumer/
│   └── ETAConsumer.csproj
```

---

### 3. Configuration

Update `appsettings.json` in each project:

#### ETAConsumer

```json
{
  "ConnectionStrings": {
    "PostgreSql": "Host=localhost;Port=5432;Database=etadb;Username=your_user;Password=your_password"
  },
  "Kafka": {
    "BootstrapServers": "localhost:9092",
    "Topic": "scan-events",
    "GroupId": "eta-consumer-group"
  }
}
```

#### ScanIngestor

```json
{
  "Kafka": {
    "BootstrapServers": "localhost:9092",
    "Topic": "scan-events"
  }
}
```

---

### 4. Running the Solution

#### Apply Database Migrations

```bash
cd ETAConsumer
dotnet ef database update
```

#### Launch Services

```bash
dotnet run --project ScanIngestor
dotnet run --project ETAConsumer
```

Swagger UI available at:  
📍 `http://localhost:<port>/swagger`

---

## API Endpoints (ETAConsumer)

| Method | Route                 | Description                 |
|--------|-----------------------|-----------------------------|
| GET    | `/api/eta`            | List latest ETA predictions |
| POST   | `/api/eta/predict`    | Trigger manual prediction   |
| GET    | `/health`             | Health check                |

---

## Docker Tips

For a local environment:

- Use Docker Compose to spin up Kafka + Zookeeper + Postgres.
- Use [confluentinc/cp-kafka](https://hub.docker.com/r/confluentinc/cp-kafka) for Kafka setup.

---

## Roadmap Ideas

- Integrate ML model for dynamic ETA prediction.
- Add Prometheus + Grafana for observability.
- Use Kafka Streams for windowed event aggregation.
- Add dead-letter queue for failed Kafka messages.

---

## License

MIT License — see [LICENSE](LICENSE) file for details.

---

## Contact

**Anis Toauti**  
Senior .NET Developer | Cloud & DevOps Enthusiast  
[LinkedIn](https://www.linkedin.com/in/anis-toauti) | [GitHub](https://github.com/kiranis) | Montréal, QC
