using ETAConsumer.Models;
using ETAConsumer.Repositories;
using Npgsql;

namespace ETAConsumer.Infrastructure.Repositories
{
    public class PostgresETAPredictionRepository : IETAPredictionRepository
    {
        private readonly string _connectionString;

        public PostgresETAPredictionRepository(string connectionString)
        {
            _connectionString = connectionString;
            EnsureTable();
        }

        private void EnsureTable()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"CREATE TABLE IF NOT EXISTS eta_predictions (
                    id SERIAL PRIMARY KEY,
                    package_id TEXT,
                    location TEXT,
                    scan_timestamp BIGINT,
                    eta TIMESTAMP
                );", conn);
            cmd.ExecuteNonQuery();
        }

        public void Add(ETAPrediction prediction)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO eta_predictions (package_id, location, scan_timestamp, eta) VALUES (@package_id, @location, @scan_timestamp, @eta)", conn);
            cmd.Parameters.AddWithValue("package_id", prediction.PackageId);
            cmd.Parameters.AddWithValue("location", prediction.Location);
            cmd.Parameters.AddWithValue("scan_timestamp", prediction.ScanTimestamp);
            cmd.Parameters.AddWithValue("eta", prediction.ETA);
            cmd.ExecuteNonQuery();
        }
    }
}