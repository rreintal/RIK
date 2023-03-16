# Documentation

## Prerequisites

- Project NuGet packages

  ```
  Microsoft.EntityFrameworkCore
  Microsoft.EntityFrameworkCore.Design
  Microsoft.EntityFrameworkCore.InMemory
  Microsoft.EntityFrameworkCore.Sqlite
  Microsoft.EntityFrameworkCore.SqlServer
  Microsoft.EntityFrameworkCore.Tools
  Microsoft.NET.Test.Sdk
  Microsoft.VisualStudio.Web.CodeGeneration.Design
  ```

- .NET SDK 7.0.12

## Database ERD

## Setup

1. Install all neccessary NuGet packages.
2. Set local database location in class `ApplicationDbContextFactory`. This will be the location where SQLLite db file is saved.

```
public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("Data Source=LOCATION.db");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
```

    Do same thing in `appsettings.json`

```"ConnectionStrings": {
    "DefaultConnection": "DataSource=LOCATION.db;Cache=Shared"
  }
```

3. To add custom PaymentMethodTypes use endpoint `/PaymentMethodTypes/Create`

## Analysis

Repository muster

Custom payment type saab lisada

testid

custom validation
