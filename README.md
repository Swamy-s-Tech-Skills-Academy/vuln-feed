# vuln-feed

I am learning .NET 9 API, and MVC Project from different Video Courses, Books, and Websites. I am learning Building a `Start to Finish Containerization and Orchestration for Developers: with Kubernetes and Docker` by **Rob Pacheco**. This work is a result of the learnings from `Rob Pacheco's` Course.

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
dotnet new xunit -n VulnFeed.Subscription.Tests -o tests/VulnFeed.Subscription.Tests

dotnet sln add tests/VulnFeed.Common.Tests/VulnFeed.Common.Tests.csproj
dotnet sln add tests/VulnFeed.Domain.Tests/VulnFeed.Domain.Tests.csproj
dotnet sln add tests/VulnFeed.Data.Tests/VulnFeed.Data.Tests.csproj
dotnet sln add tests/VulnFeed.Web.Tests/VulnFeed.Web.Tests.csproj
dotnet sln add tests/VulnFeed.Loader.Tests/VulnFeed.Loader.Tests.csproj
dotnet sln add tests/VulnFeed.Subscription.Tests/VulnFeed.Subscription.Tests.csproj
```

## Container Images

There are two container images that can be build: Postgres and Vulnerability Feed. In addition, it is often useful to run Postgres locally as a container in Docker while developing locally.

### Building the PostgreSQL Container Image

To build the Postgres container image: (starting from the root of the repo)

```powershell
cd postgres/docker
docker build -f Dockerfile -t vuln-postgres:latest .
```

## Running PostgreSQL in Docker

Once the Postgres container image is built, it can be run in Docker and exposed locally on port 5432:

```powershell
docker run --name vuln-pg -d -p 5432:5432 -e POSTGRES_PASSWORD=secret vuln-postgres:latest
```

Note that in this repository the password `secret` is often used. This is not a realistic password. Passwords should not be committed to repositories.

## Removing Existing PostgreSQL Docker container

```powershell
docker rm -f vuln-pg
```
