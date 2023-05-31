#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BankAuthenticationService/BankAuthenticationService.csproj", "BankAuthenticationService/"]
COPY ["TransactionService/TransactionService.csproj", "TransactionService/"]
COPY ["NotificationContracts/NotificationContracts.csproj", "NotificationContracts/"]
RUN dotnet restore "BankAuthenticationService/BankAuthenticationService.csproj"
COPY . .
WORKDIR "/src/BankAuthenticationService"
RUN dotnet build "BankAuthenticationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankAuthenticationService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankAuthenticationService.dll"]
