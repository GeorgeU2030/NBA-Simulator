FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /NBA-Simulator-project
COPY ["NBA-Simulator-project/NBA-Simulator-project.csproj", "NBA-Simulator-project/"]
RUN dotnet restore "NBA-Simulator-project/NBA-Simulator-project.csproj"
COPY . .
WORKDIR "/NBA-Simulator-project/NBA-Simulator-project"
RUN dotnet build "NBA-Simulator-project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NBA-Simulator-project.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NBA-Simulator-project.dll"]