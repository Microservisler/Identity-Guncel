﻿using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration;
using System;
using System.Reflection;
using MySqlMigrationAssembly = Project5.Admin.EntityFramework.MySql.Helpers.MigrationAssembly;
using PostgreSQLMigrationAssembly = Project5.Admin.EntityFramework.PostgreSQL.Helpers.MigrationAssembly;
using SqlMigrationAssembly = Project5.Admin.EntityFramework.SqlServer.Helpers.MigrationAssembly;

namespace Project5.Admin.Configuration.Database
{
    public static class MigrationAssemblyConfiguration
    {
        public static string GetMigrationAssemblyByProvider(DatabaseProviderConfiguration databaseProvider)
        {
            return databaseProvider.ProviderType switch
            {
                DatabaseProviderType.SqlServer => typeof(SqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
                DatabaseProviderType.PostgreSQL => typeof(PostgreSQLMigrationAssembly).GetTypeInfo()
                    .Assembly.GetName()
                    .Name,
                DatabaseProviderType.MySql => typeof(MySqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}







