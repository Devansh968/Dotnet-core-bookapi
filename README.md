# Dotnet-core-bookapi
![image](https://github.com/Devansh968/Dotnet-core-bookapi/assets/90167731/05fe2f56-2188-4eb4-92fc-839029ec5c63)
# Book API using .NET Core and Azure SQL Database

This repository contains a Book API implemented using .NET Core framework and connected to an Azure SQL Database. The API provides endpoints to manage books in the database.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Setup](#setup)
- [API Endpoints](#api-endpoints)
- [Database](#database)
- [Deployment](#deployment)
- [Authentication](#authentication)
- [Monitoring](#monitoring)
- [Contributing](#contributing)
- [License](#license)

## Features

- Create, Read, Update, and Delete book records.
- Store book information including title, author, genre, etc.
- Utilizes Entity Framework Core for data access and management.
- Hosted on Azure App Service.
- Connected to an Azure SQL Database.
- [Optional] Implements authentication for secure access.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Azure Subscription](https://azure.com/free)
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)

## Setup

1. Clone the repository:

```sh
git clone https://github.com/yourusername/book-api.git
cd book-api

Install project dependencies:
dotnet restore

Configure your Azure SQL Database connection string in appsettings.json:

{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string"
  }
}


API Endpoints

Endpoint	Description	HTTP Method
/api/books	Get all books	GET
/api/books/{id}	Get a book by ID	GET
/api/books	Create a new book	POST
/api/books/{id}	Update a book by ID	PUT
/api/books/{id}	Delete a book by ID	DELETE

Database
Azure SQL Database: YourDatabaseName.database.windows.net
Connection String: your-connection-string


Deployment
The API is deployed on Azure App Service: YourAppServiceName.azurewebsites.net

Authentication
[Optional] The API implements JWT authentication. To access protected endpoints, include an Authorization header with a valid JWT token.

Monitoring
[Optional] Monitoring and logging are set up using Azure Application Insights.
