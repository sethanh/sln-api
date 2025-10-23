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


COPY ["Sln.Publisher/Sln.Publisher.Common/Sln.Publisher.Common.csproj", "Sln.Publisher/Sln.Publisher.Common/"]
RUN dotnet restore "Sln.Publisher/Sln.Publisher.Common"
COPY ["Sln.Publisher/Sln.Publisher.Data/Sln.Publisher.Data.csproj", "Sln.Publisher/Sln.Publisher.Data/"]
RUN dotnet restore "Sln.Publisher/Sln.Publisher.Data"
COPY ["Sln.Publisher/Sln.Publisher.Business/Sln.Publisher.Business.csproj", "Sln.Publisher/Sln.Publisher.Business/"]
RUN dotnet restore "Sln.Publisher/Sln.Publisher.Business"

COPY ["Sln.Publisher/Sln.Publisher.Host/Sln.Publisher.Host.csproj", "Sln.Publisher/Sln.Publisher.Host/"]
RUN dotnet restore "Sln.Publisher/Sln.Publisher.Host"


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

COPY ["Sln.Publisher/Sln.Publisher.Common/", "Sln.Publisher/Sln.Publisher.Common"]
RUN dotnet build "Sln.Publisher/Sln.Publisher.Common/Sln.Publisher.Common.csproj" -c Release
COPY ["Sln.Publisher/Sln.Publisher.Data/", "Sln.Publisher/Sln.Publisher.Data"]
RUN dotnet build "Sln.Publisher/Sln.Publisher.Data/Sln.Publisher.Data.csproj" -c Release
COPY ["Sln.Publisher/Sln.Publisher.Business/", "Sln.Publisher/Sln.Publisher.Business"]
RUN dotnet build "Sln.Publisher/Sln.Publisher.Business/Sln.Publisher.Business.csproj" -c Release

COPY ["Sln.Publisher/Sln.Publisher.Host/", "Sln.Publisher/Sln.Publisher.Host"]
RUN dotnet build "Sln.Publisher/Sln.Publisher.Host/Sln.Publisher.Host.csproj" -c Release
RUN dotnet publish "Sln.Publisher/Sln.Publisher.Host/Sln.Publisher.Host.csproj" -c Release -o "./dist"

# ***************************************
# RUNTIME
# ***************************************
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=builder /src/dist .
ENTRYPOINT ["dotnet", "Sln.Publisher.Host.dll"]