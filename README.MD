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

dotnet build


cd .\PaymentContext.Domain\
dotnet add reference ..\PaymentContext.Shared\PaymentContext.Shared.csproj
cd..


cd .\PaymentContext.Tests\ 
dotnet add reference ..\PaymentContext.Domain\PaymentContext.Domain.csproj
cd..

dotnet restore
dotnet build

cd .\PaymentContext.Domain\
del .\Class1.cs
md Entities
cd Entities

# Criando as classes (conferir)(conferir os comandos corretos, via dos)
dotnet new classlib Student.cs
dotnet new classlib Subscription.cs
dotnet new classlib Payment.cs

dotnet restore
dotnet build

cd .\PaymentContext.Domain\
del .\Class1.cs
md Entities

# Criando as classes: Student, Subscription e Payment

cd ..
cd ..
cd PaymentContext.Tests


# Criando as classes: Student, Subscription e Payment
md Entities
cd Entities

# ciar StudentTests.cs (conferir)
dotnet new classlib StudentTests.cs

# copiei o conteudo do UnitTest1.cs, para ter o modelo

cd..
cd .\PaymentContext.Shared\
dotnet add package flunt
cd ..

cd .\PaymentContext.Domain\
dotnet add package flunt
cd..

cd .\PaymentContext.Tests\
dotnet add package flunt
cd..

cd .\PaymentContext.Tests\
del .\UnitTest1.cs
cd..
