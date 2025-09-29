namespace BiblioManagement.Tests;

public class CalculatriceTest
{
    [Fact]
    public void Addition()
    {
        var calculatrice = new Calculatrice();
        int result = calculatrice.Addition(2, 3);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Soustraction()
    {
        var calculatrice = new Calculatrice();
        int result = calculatrice.Soustraction(5, 3);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Multiplication()
    {
        var calculatrice = new Calculatrice();
        int result = calculatrice.Multiplication(4, 3);
        Assert.Equal(12, result);
    }

    [Fact]
    public void Division()
    {
        var calculatrice = new Calculatrice();
        int result = calculatrice.Division(10, 2);
        Assert.Equal(5, result);
    }
}
