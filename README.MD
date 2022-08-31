md PaymentContext
cd PaymentContext

git ini
dotnet new sln
dotnet new gitignore

md PaymentContext.Domain
md PaymentContext.Shared
md PaymentContext.Tests


cd PaymentContext.Domain
dotnet new classlib
cd ..

cd PaymentContext.Shared
dotnet new classlib
cd ..

cd PaymentContext.Tests
dotnet new mstest
cd ..

dotnet sln add PaymentContext.Domain\PaymentContext.Domain.csproj
dotnet sln add PaymentContext.Shared\PaymentContext.Shared.csproj
dotnet sln add PaymentContext.Tests\PaymentContext.Tests.csproj
