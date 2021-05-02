FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Outlaws.API.csproj", "./"]
RUN dotnet restore "Outlaws.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Outlaws.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Outlaws.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Outlaws.API.dll"]
