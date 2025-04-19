# Dockerized .NET API with MongoDB

This is a RESTful API built with ASP.NET Core, MongoDB, and Docker Compose.  
It counts how many times the container has been executed and persists the value in a MongoDB collection.

---

## 🚀 Features

- ASP.NET Core Web API using Minimal APIs + Controllers
- MongoDB persistence
- Dockerized with multi-stage build
- Configuration via `appsettings.json` and environment variables
- API Documentation with Swagger

---

## 📦 Technologies

- ASP.NET Core 8.0
- MongoDB 7.0
- Docker / Docker Compose
- Swashbuckle (Swagger UI)
- C# 11

---

## ⚙️ How to Run Locally (with Docker Compose)

1. Clone the repo:
   ```bash
   git clone https://github.com/your-username/dockerized-dotnet-mongodb-api.git
   cd dockerized-dotnet-mongodb-api
