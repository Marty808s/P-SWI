/*
dotnet new xunit -n SchoolApp.Tests
dotnet add SchoolApp.Tests/SchoolApp.Tests.csproj reference path/k/tvemu/hlavnimu/Projektu.csproj
dotnet test

--> j�t do z�vislost�, p�idat referenci na projekt --> p�id�m dll

spu�t�n� testu/prav�m na test cs soubor a d�t testovat. N�sledn� ve v�stupech p�ej�t na testy:
dotnet test
*/

namespace SchoolApp.Tests;

public class UnitTest1
{
    [Fact]
    public void KurzCreator_ShouldIgnorePasswordAndRoleParameters()
    {
        var creator = new KurzCreator();

        // I kdy� po�leme password/role, m�lo by se vytvo�it Kurz bez ohledu na n�
        var entita = creator.createProduct("Algoritmy", "ALG101", "ignoredPass", "ignoredRole");

        var kurz = Assert.IsType<Kurz>(entita);
        Assert.Equal("Algoritmy", kurz.name);
        Assert.Equal("ALG101", kurz.code);
    }
}