# sln-api

Follow the instructions below to setup the project.

## Pre-requisites

- Net core SDK 8.0.0
- dotnet-ef 8.0.0 (Optional in production, but required for development)
- MySQL 8.0.0
- Node 18 (Optional in production, but required for development)

## Available Scripts

> :warning: Before running any script, make sure to run `yarn` to install all dependencies.

At the root of the project, you can run:

- `yarn ef`: Run Entity Framework commands in interactive mode

## Prepare the solution

Every Host and Migrator of project, we need to create `.env` from `.env.example` by running the following command:

```bash
MANAGEMENT_CONNECTION="..."
MYSQL_CONNECTION_STRING="..."
JWT_SECRET="..."
```

Generates a self-signed certificate to enable HTTPS use in development(skip if you are done that before):

```bash
# Windows, MacOS:
dotnet dev-certs https --trust

# Ubuntu(>= 20.04):
# original issue: https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-8.0&tabs=visual-studio%2Clinux-ubuntu
sudo apt update -y
sudo apt install -y ca-certificates openssl
dotnet dev-certs https
sudo -E dotnet dev-certs https -ep /usr/local/share/ca-certificates/aspnet/https.crt --format PEM
sudo update-ca-certificates
```
# sln-api
