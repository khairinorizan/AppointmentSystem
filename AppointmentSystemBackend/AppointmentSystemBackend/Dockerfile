FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AppointmentSystemBackend/AppointmentSystemBackend.csproj", "AppointmentSystemBackend/"]
RUN dotnet restore "AppointmentSystemBackend/AppointmentSystemBackend.csproj"
COPY . .
WORKDIR "/src/AppointmentSystemBackend"
RUN dotnet build "AppointmentSystemBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppointmentSystemBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppointmentSystemBackend.dll"]
