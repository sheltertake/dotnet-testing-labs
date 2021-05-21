# dotnet-testing-labs


## 01 - Solution - VS

 - update nuget
 - install Moq in unit test project
 - install FluentAssertion (all tests project)
## 00 - Solution - Setup


```cmd

PS C:\Github\dotnet-testing-labs> dotnet new gitignore
The template "dotnet gitignore file" was created successfully.

PS C:\Github\dotnet-testing-labs> dotnet new api -n FooApi -o src/FooApi
The template "ASP.NET Core Web API" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on src/FooApi\FooApi.csproj...
  Determining projects to restore...
  Restored C:\Github\dotnet-testing-labs\src\FooApi\FooApi.csproj (in 310 ms).
Restore succeeded.

PS C:\Github\dotnet-testing-labs> dotnet new nunit -n FooApiUnitTests -o tests/FooApiUnitTests
The template "NUnit 3 Test Project" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on tests/FooApiUnitTests\FooApiUnitTests.csproj...
  Determining projects to restore...
  Restored C:\Github\dotnet-testing-labs\tests\FooApiUnitTests\FooApiUnitTests.csproj (in 3,86 sec).
Restore succeeded.

PS C:\Github\dotnet-testing-labs> dotnet new nunit -n FooApiFunctionalTests -o tests/FooApiFunctionalTests
The template "NUnit 3 Test Project" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on tests/FooApiFunctionalTests\FooApiFunctionalTests.csproj...
  Determining projects to restore...
  Restored C:\Github\dotnet-testing-labs\tests\FooApiFunctionalTests\FooApiFunctionalTests.csproj (in 2,2 sec).
Restore succeeded.

PS C:\Github\dotnet-testing-labs> dotnet new nunit -n FooApiE2eTests -o tests/FooApiE2eTests
The template "NUnit 3 Test Project" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on tests/FooApiE2eTests\FooApiE2eTests.csproj...
  Determining projects to restore...
  Restored C:\Github\dotnet-testing-labs\tests\FooApiE2eTests\FooApiE2eTests.csproj (in 2,06 sec).
Restore succeeded.

PS C:\Github\dotnet-testing-labs> dotnet new nunit -n FooApiArchTests -o tests/FooApiArchTests
The template "NUnit 3 Test Project" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on tests/FooApiArchTests\FooApiArchTests.csproj...
  Determining projects to restore...
  Restored C:\Github\dotnet-testing-labs\tests\FooApiArchTests\FooApiArchTests.csproj (in 2 sec).
Restore succeeded.


PS C:\Github\dotnet-testing-labs>

```