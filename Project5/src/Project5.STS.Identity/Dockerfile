FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Project5.STS.Identity/Project5.STS.Identity.csproj", "src/Project5.STS.Identity/"]
COPY ["src/Project5.Admin.EntityFramework.Shared/Project5.Admin.EntityFramework.Shared.csproj", "src/Project5.Admin.EntityFramework.Shared/"]
COPY ["src/Project5.Shared/Project5.Shared.csproj", "src/Project5.Shared/"]
RUN dotnet restore "src/Project5.STS.Identity/Project5.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Project5.STS.Identity"
RUN dotnet build "Project5.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project5.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Project5.STS.Identity.dll"]