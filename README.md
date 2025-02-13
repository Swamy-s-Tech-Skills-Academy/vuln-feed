# vuln-feed

I am learning .NET 9 API, and MVC Project from different Video Courses, Books, and Websites

I am learning Building a `Start to Finish Containerization and Orchestration for Developers: with Kubernetes and Docker` by **Rob Pacheco**. This work is a result of the learnings from `Rob Pacheco's` Course.

## Software

```text
Windows 11
```

## Few Commands

```powershell
cd D:\STSA\vuln-feed>
PS D:\STSA\vuln-feed>

dotnet new sln -n VulnFeed

dotnet new classlib -n VulnFeed.Common -o src/VulnFeed.Common
dotnet sln add src/VulnFeed.Common/VulnFeed.Common.csproj

dotnet new classlib -n VulnFeed.Domain -o src/VulnFeed.Domain
dotnet sln add src/VulnFeed.Domain/VulnFeed.Domain.csproj

dotnet new classlib -n VulnFeed.Data -o src/VulnFeed.Data
dotnet sln add src/VulnFeed.Data/VulnFeed.Data.csproj

dotnet new mvc -n VulnFeed.Web -o src/VulnFeed.Web
dotnet sln add src/VulnFeed.Web/VulnFeed.Web.csproj

dotnet new console -n VulnFeed.Loader -o src/VulnFeed.Loader
dotnet sln add src/VulnFeed.Loader/VulnFeed.Loader.csproj

dotnet new mvc -n VulnFeed.Subscription -o src/VulnFeed.Subscription
dotnet sln add src/VulnFeed.Subscription/VulnFeed.Subscription.csproj
```

## Test Projects

```powershell
cd D:\STSA\vuln-feed>
PS D:\STSA\vuln-feed>

dotnet new xunit -n VulnFeed.Common.Tests -o tests/VulnFeed.Common.Tests
dotnet new xunit -n VulnFeed.Domain.Tests -o tests/VulnFeed.Domain.Tests
dotnet new xunit -n VulnFeed.Data.Tests -o tests/VulnFeed.Data.Tests
dotnet new xunit -n VulnFeed.Web.Tests -o tests/VulnFeed.Web.Tests
dotnet new xunit -n VulnFeed.Loader.Tests -o tests/VulnFeed.Loader.Tests

dotnet sln add tests/VulnFeed.Common.Tests/VulnFeed.Common.Tests.csproj
dotnet sln add tests/VulnFeed.Domain.Tests/VulnFeed.Domain.Tests.csproj
dotnet sln add tests/VulnFeed.Data.Tests/VulnFeed.Data.Tests.csproj
dotnet sln add tests/VulnFeed.Web.Tests/VulnFeed.Web.Tests.csproj
dotnet sln add tests/VulnFeed.Loader.Tests/VulnFeed.Loader.Tests.csproj
```
