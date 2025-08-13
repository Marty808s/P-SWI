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

    [Fact]
    public void Calculator_ShouldCalcAritmeticAverageFromGradeList()
    {
        AritmeticCalc avgCalc = new AritmeticCalc();
        var calculator = new Calculator<float>(avgCalc);

        List<float> grades = new List<float> { 1.0f, 2.0f, 3.0f };

        float res = calculator.calculate(grades);

        Assert.Equal(2, res);
    }

    [Theory]
    //z�pis float[] je pro vytvo�en� pole
    [InlineData(new float[] { 1f, 2f, 3f }, 2f)]
    [InlineData(new float[] { 10f, 20f, 30f, 40f }, 25f)]
    [InlineData(new float[] { 5f, 5f, 5f, 5f, 5f }, 5f)]
    [InlineData(new float[] { 0f, 100f }, 50f)]
    public void Calculator_ShouldCalcAritmeticAverage_FromMultipleLists(float[] gradesArray, float expected)
    {
        // Arrange
        var avgCalc = new AritmeticCalc();
        var calculator = new Calculator<float>(avgCalc);
        var grades = gradesArray.ToList();

        // Act
        float res = calculator.calculate(grades);

        // Assert
        Assert.Equal(expected, res);
    }

    // Kolekce testovac�ch vstup� pro Theory test
    public static IEnumerable<object[]> WeightedCases =>
        new List<object[]>
        {
        new object[]
        {
            // Vstupn� seznam zn�mek s v�hami (typ List<(float grade, float weight)>)
            new List<(float grade, float weight)>
            {
                (1f, 2f),   // zn�mka 1 s v�hou 2
                (1.5f, 2f), // zn�mka 1.5 s v�hou 2
                (1f, 1f)    // zn�mka 1 s v�hou 1
            },
            // O�ek�van� v�sledek: (sou�et zn�mka*vaha) / (sou�et vah)
            (1f * 2f + 1.5f * 2f + 1f * 1f) / (2f + 2f + 1f)
        }
        };


    // Theory = test se spou�t� pro ka�dou sadu dat z WeightedCases
    [Theory]
    [MemberData(nameof(WeightedCases))]
    public void Calculator_ShouldCalcWeightedAverage_FromList(
        List<(float grade, float weight)> grades, // vstupn� zn�mky
        float expected                           // o�ek�van� pr�m�r
    )
    {
        // Arrange � vytvo�en� kalkula�ky s pou�it�m strategie WeightedAverageCalc
        var calc = new Calculator<(float grade, float weight)>(new WeightedAverageCalc());

        // Act � v�po�et pr�m�ru z dan�ch zn�mek
        float res = calc.calculate(grades);

        // Assert � kontrola, �e v�sledek je v toleranci �1e-5 od o�ek�van�ho
        Assert.InRange(res, expected - 1e-5f, expected + 1e-5f);
    }

    [Fact]
    public void StudentCreator_CreatesUserWithStudentRole()
    {
        var creator = new StudentCreator();

        var ent = creator.createProduct("Karel", "ST999", "heslo");
        var user = Assert.IsType<User>(ent); //ov���, zde je v�n� typu User

        Assert.Equal("student", user.role);
        Assert.Equal("ST999", user.code);
    }

    [Fact]
    public void GetStudents_ReturnsOnlyRoleStudent()
    {
        var kurz = new Kurz("Algoritmy", "ALG101");
        var s1 = new User("Petr", "ST1", "x", "student");
        var s2 = new User("Jana", "ST2", "x", "student");
        var t1 = new User("Eva", "TE1", "x", "ucitel");

        kurz.addUser(s1);
        kurz.addUser(s2);
        kurz.addUser(t1);

        var students = kurz.getStudents();

        Assert.Equal(2, students.Count); // ov��� po�et
        Assert.All(students, s => Assert.Equal("student", s.role)); // vyzkou�� pomoc� cyklu - Promise.All alternativa
    }
}