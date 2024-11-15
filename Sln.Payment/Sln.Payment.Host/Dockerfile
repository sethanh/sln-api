# ***************************************
# BUILD
# ***************************************
FROM mcr.microsoft.com/dotnet/sdk:8.0 as builder

# Create .env file at the root of the project
RUN touch .env

WORKDIR /src
# Restore dependencies as distinct layers
COPY ["Sln.Shared/Sln.Shared.Contract/Sln.Shared.Contract.csproj", "Sln.Shared/Sln.Shared.Contract/"]
RUN dotnet restore "Sln.Shared/Sln.Shared.Contract"
COPY ["Sln.Shared/Sln.Shared.Common/Sln.Shared.Common.csproj", "Sln.Shared/Sln.Shared.Common/"]
RUN dotnet restore "Sln.Shared/Sln.Shared.Common"
COPY ["Sln.Shared/Sln.Shared.Data/Sln.Shared.Data.csproj", "Sln.Shared/Sln.Shared.Data/"]
RUN dotnet restore "Sln.Shared/Sln.Shared.Data"
COPY ["Sln.Shared/Sln.Shared.Business/Sln.Shared.Business.csproj", "Sln.Shared/Sln.Shared.Business/"]
RUN dotnet restore "Sln.Shared/Sln.Shared.Business"

COPY ["Sln.Shared/Sln.Shared.Host/Sln.Shared.Host.csproj", "Sln.Shared/Sln.Shared.Host/"]
RUN dotnet restore "Sln.Shared/Sln.Shared.Host"



COPY ["Sln.Payment/Sln.Payment.Contract/Sln.Payment.Contract.csproj", "Sln.Payment/Sln.Payment.Contract/"]
RUN dotnet restore "Sln.Payment/Sln.Payment.Contract"
COPY ["Sln.Payment/Sln.Payment.Common/Sln.Payment.Common.csproj", "Sln.Payment/Sln.Payment.Common/"]
RUN dotnet restore "Sln.Payment/Sln.Payment.Common"
COPY ["Sln.Payment/Sln.Payment.Data/Sln.Payment.Data.csproj", "Sln.Payment/Sln.Payment.Data/"]
RUN dotnet restore "Sln.Payment/Sln.Payment.Data"
COPY ["Sln.Payment/Sln.Payment.Business/Sln.Payment.Business.csproj", "Sln.Payment/Sln.Payment.Business/"]
RUN dotnet restore "Sln.Payment/Sln.Payment.Business"

COPY ["Sln.Payment/Sln.Payment.Host/Sln.Payment.Host.csproj", "Sln.Payment/Sln.Payment.Host/"]
RUN dotnet restore "Sln.Payment/Sln.Payment.Host"


# Copy everything else and build
COPY ["Sln.Shared/Sln.Shared.Common/", "Sln.Shared/Sln.Shared.Common"]
RUN dotnet build "Sln.Shared/Sln.Shared.Common/Sln.Shared.Common.csproj" -c Release
COPY ["Sln.Shared/Sln.Shared.Data/", "Sln.Shared/Sln.Shared.Data"]
RUN dotnet build "Sln.Shared/Sln.Shared.Data/Sln.Shared.Data.csproj" -c Release
COPY ["Sln.Shared/Sln.Shared.Contract/", "Sln.Shared/Sln.Shared.Contract"]
RUN dotnet build "Sln.Shared/Sln.Shared.Contract/Sln.Shared.Contract.csproj" -c Release
COPY ["Sln.Shared/Sln.Shared.Business/", "Sln.Shared/Sln.Shared.Business"]
RUN dotnet build "Sln.Shared/Sln.Shared.Business/Sln.Shared.Business.csproj" -c Release

COPY ["Sln.Shared/Sln.Shared.Host/", "Sln.Shared/Sln.Shared.Host"]
RUN dotnet build "Sln.Shared/Sln.Shared.Host/Sln.Shared.Host.csproj" -c Release

COPY ["Sln.Payment/Sln.Payment.Contract/", "Sln.Payment/Sln.Payment.Contract"]
RUN dotnet build "Sln.Payment/Sln.Payment.Contract/Sln.Payment.Contract.csproj" -c Release
COPY ["Sln.Payment/Sln.Payment.Common/", "Sln.Payment/Sln.Payment.Common"]
RUN dotnet build "Sln.Payment/Sln.Payment.Common/Sln.Payment.Common.csproj" -c Release
COPY ["Sln.Payment/Sln.Payment.Data/", "Sln.Payment/Sln.Payment.Data"]
RUN dotnet build "Sln.Payment/Sln.Payment.Data/Sln.Payment.Data.csproj" -c Release
COPY ["Sln.Payment/Sln.Payment.Business/", "Sln.Payment/Sln.Payment.Business"]
RUN dotnet build "Sln.Payment/Sln.Payment.Business/Sln.Payment.Business.csproj" -c Release

COPY ["Sln.Payment/Sln.Payment.Host/", "Sln.Payment/Sln.Payment.Host"]
RUN dotnet build "Sln.Payment/Sln.Payment.Host/Sln.Payment.Host.csproj" -c Release
RUN dotnet publish "Sln.Payment/Sln.Payment.Host/Sln.Payment.Host.csproj" -c Release -o "./dist"

# ***************************************
# RUNTIME
# ***************************************
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=builder /src/dist .
ENTRYPOINT ["dotnet", "Sln.Payment.Host.dll"]