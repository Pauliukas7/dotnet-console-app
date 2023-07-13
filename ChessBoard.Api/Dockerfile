FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChessBoard.Api.csproj", "./"]
RUN dotnet restore "ChessBoard.Api.csproj"
COPY . .
RUN dotnet publish "ChessBoard.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ChessBoard.Api.dll"]