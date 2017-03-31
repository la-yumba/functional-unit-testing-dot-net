### Prerequisites

- .NET Core SDK from: http://dot.net/core

### Project setup

```

// dotnet new --all

mkdir MyBnb
cd MyBnb
dotnet new console

dotnet restore
dotnet run
// "Hello, world!"

cd ..
mkdir MyBnb.Tests
cd MyBnb.Tests
dotnet new xunit

dotnet restore
dotnet test

```

### Solution setup

```
cd ..
dotnet new sln -n MyBnb

dotnet sln add MyBnb/MyBnb.csproj
dotnet sln add MyBnb.Tests/MyBnb.Tests.csproj

dotnet add MyBnb.Tests/MyBnb.Tests.csproj reference MyBnb/MyBnb.csproj
```

### Watcher setup

Add to .csproj (see https://docs.microsoft.com/en-us/aspnet/core/tutorials/dotnet-watch)

```
<DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0" />
```

```
dotnet restore
dotnet watch test
```

### Adding dependencies

dotnet add package foo.bar

