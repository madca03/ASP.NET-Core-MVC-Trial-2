# ASP.NET Core MVC RESTful API using EF Core DB First Approach

## Notes on creating models via EF Core's scaffolding
1. First, you need to have **Microsoft.EntityFrameworkCore.Tools** to have access to the **Scaffold-DbContext** command.
2. You also need to install a database provider for the database you are using. For this project, I'm using Microsoft SQL Server Express so I needed to have the **Microsoft.EntityFrameworkCore.SqlServer** data provide. These packages can be installed via the **Nuget Package Manager**
  
  ![Package setup for EF Core][package-setup-efcore]

3. Once you've installed the necessary packages, you now have access to the **Scaffold-DbContext** command in the **Package Manager Console**. See the documentation on **Scaffold-DbContext** [here][scaffold-dbcontext]. Here is another tutorial [link][scaffold-dbcontext-tutorial1] on the usage of **Scaffold DbContext**.
4. To use the **Scaffold-DbContext** command, you also need to have the **connection string** for your database. The **Scaffold-DbContext** has two positional arguments - the **connection string** and the **database provider** (for this case, it's **Microsoft.EntityFrameworkCore.SqlServer**). The code below shows an example on how to use the **Scaffold-DbContext** in the Package Manager Console. The **-OutputDir** command sets the directory where the model files will be put in. In this case, it's placed under the **Models** folder.

  ```
  Scaffold-DbContext "Data Source=LAPTOP-VRPV043O\SQLEXPRESS;Initial Catalog=testEFCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
  ```

[scaffold-dbcontext]: https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell#scaffold-dbcontext
[scaffold-dbcontext-tutorial1]: https://www.devart.com/dotconnect/postgresql/docs/EFCore-Database-First-NET-Core.html
[package-setup-efcore]: ./img/package-setup-for-efcore-db-first.png