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
- Entity Framework Core 7.0.1
- xUnit 7.0

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

**MAKE SURE BOTH DB LOCATIONS MATCH AND HAVE .db EXTENSION!!**

3. Now everything is set up and now you can run the code.

## Database ERD

![Model](https://github.com/rreintal/RIK/blob/main/ERD/db-erd.png)

## Analysis

The Data Access Layer (DAL) in this application has been designed using the Repository pattern. This approach has been chosen to ensure flexibility and maintainability in the event of a change in the data storage system. By defining the DAL's interactions with the data storage system through interfaces, any necessary modifications can be made to the code implementation without impacting the functioning of other systems that rely on it.

The Repository pattern facilitates separation of concerns by abstracting data access operations from the rest of the application's logic. This allows for greater ease of maintenance and extensibility, as changes to the data storage system can be accommodated simply by updating the code implementation of the DAL while leaving the interface specifications unchanged.

Overall, the use of the Repository pattern in our application's DAL provides a robust and flexible approach to data access that can accommodate potential changes to the underlying data storage system, while ensuring seamless integration with other components of the system.

Current system offers a convenient endpoint, `"/PaymentMethodTypes/Create"`, which enables the addition of custom payment method types. This feature provides users with the ability to add new payment methods without the need for modifying the source code, thereby reducing the risk of introducing errors and simplifying the process of extending the system's functionality.

Testing framework of choice for this project is xUnit. The testing suite includes two types of tests: basic database operation tests and domain model validation tests.

The domain model validation tests focus on validating the domain model's behavior and ensuring that it adheres to the system's business rules and requirements. These tests validate the various domain objects and their interactions, including any domain-specific logic or calculations. By verifying that the domain model behaves correctly, we can ensure that the system is functioning as intended and delivering the expected results.

Domain models include custom validation attribute implementations to ensure that data entered into the system adheres to the specific business rules and requirements of the domain. These custom validation attributes provide a flexible and extensible way to define and enforce data validation rules for the domain models.
