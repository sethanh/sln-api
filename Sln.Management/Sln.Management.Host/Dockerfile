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



COPY ["Sln.Management/Sln.Management.Contract/Sln.Management.Contract.csproj", "Sln.Management/Sln.Management.Contract/"]
RUN dotnet restore "Sln.Management/Sln.Management.Contract"
COPY ["Sln.Management/Sln.Management.Common/Sln.Management.Common.csproj", "Sln.Management/Sln.Management.Common/"]
RUN dotnet restore "Sln.Management/Sln.Management.Common"
COPY ["Sln.Management/Sln.Management.Data/Sln.Management.Data.csproj", "Sln.Management/Sln.Management.Data/"]
RUN dotnet restore "Sln.Management/Sln.Management.Data"
COPY ["Sln.Management/Sln.Management.Business/Sln.Management.Business.csproj", "Sln.Management/Sln.Management.Business/"]
RUN dotnet restore "Sln.Management/Sln.Management.Business"

COPY ["Sln.Management/Sln.Management.Host/Sln.Management.Host.csproj", "Sln.Management/Sln.Management.Host/"]
RUN dotnet restore "Sln.Management/Sln.Management.Host"


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

COPY ["Sln.Management/Sln.Management.Contract/", "Sln.Management/Sln.Management.Contract"]
RUN dotnet build "Sln.Management/Sln.Management.Contract/Sln.Management.Contract.csproj" -c Release
COPY ["Sln.Management/Sln.Management.Common/", "Sln.Management/Sln.Management.Common"]
RUN dotnet build "Sln.Management/Sln.Management.Common/Sln.Management.Common.csproj" -c Release

COPY ["Sln.Management/Sln.Management.Data/", "Sln.Management/Sln.Management.Data"]
RUN dotnet build "Sln.Management/Sln.Management.Data/Sln.Management.Data.csproj" -c Release
COPY ["Sln.Management/Sln.Management.Business/", "Sln.Management/Sln.Management.Business"]
RUN dotnet build "Sln.Management/Sln.Management.Business/Sln.Management.Business.csproj" -c Release
COPY ["Sln.Management/Sln.Management.Host/", "Sln.Management/Sln.Management.Host"]

RUN dotnet build "Sln.Management/Sln.Management.Host/Sln.Management.Host.csproj" -c Release
RUN dotnet publish "Sln.Management/Sln.Management.Host/Sln.Management.Host.csproj" -c Release -o "./dist"

# ***************************************
# RUNTIME
# ***************************************
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=builder /src/dist .
ENTRYPOINT ["dotnet", "Sln.Management.Host.dll"]