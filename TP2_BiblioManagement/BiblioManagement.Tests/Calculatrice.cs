interface ICalculatrice
{
    int Addition(int a, int b);
    int Soustraction(int a, int b);
    int Multiplication(int a, int b);
    int Division(int a, int b);
}

public class Calculatrice
{
    public int Addition(int a, int b)
    {
        return a + b;
    }

    public int Soustraction(int a, int b)
    {
        return a - b;
    }

    public int Multiplication(int a, int b)
    {
        return a * b;
    }

    public int Division(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }
        return a / b;
    }
}