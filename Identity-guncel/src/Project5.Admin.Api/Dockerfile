FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Project5.Admin.Api/Project5.Admin.Api.csproj", "src/Project5.Admin.Api/"]
COPY ["src/Project5.Admin.EntityFramework.Shared/Project5.Admin.EntityFramework.Shared.csproj", "src/Project5.Admin.EntityFramework.Shared/"]
COPY ["src/Project5.Admin.EntityFramework.SqlServer/Project5.Admin.EntityFramework.SqlServer.csproj", "src/Project5.Admin.EntityFramework.SqlServer/"]
COPY ["src/Project5.Shared/Project5.Shared.csproj", "src/Project5.Shared/"]
COPY ["src/Project5.Admin.EntityFramework.PostgreSQL/Project5.Admin.EntityFramework.PostgreSQL.csproj", "src/Project5.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Project5.Admin.EntityFramework.MySql/Project5.Admin.EntityFramework.MySql.csproj", "src/Project5.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/Project5.Admin.Api/Project5.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/Project5.Admin.Api"
RUN dotnet build "Project5.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project5.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Project5.Admin.Api.dll"]