FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Project5.Admin/Project5.Admin.csproj", "src/Project5.Admin/"]
COPY ["src/Project5.Admin.EntityFramework.Shared/Project5.Admin.EntityFramework.Shared.csproj", "src/Project5.Admin.EntityFramework.Shared/"]
COPY ["src/Project5.Admin.EntityFramework.SqlServer/Project5.Admin.EntityFramework.SqlServer.csproj", "src/Project5.Admin.EntityFramework.SqlServer/"]
COPY ["src/Project5.Shared/Project5.Shared.csproj", "src/Project5.Shared/"]
COPY ["src/Project5.Admin.EntityFramework.PostgreSQL/Project5.Admin.EntityFramework.PostgreSQL.csproj", "src/Project5.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Project5.Admin.EntityFramework.MySql/Project5.Admin.EntityFramework.MySql.csproj", "src/Project5.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/Project5.Admin/Project5.Admin.csproj"
COPY . .
WORKDIR "/src/src/Project5.Admin"
RUN dotnet build "Project5.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project5.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Project5.Admin.dll"]