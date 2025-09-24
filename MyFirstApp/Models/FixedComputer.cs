namespace MyFirstApp.Models;

class FixedComputer : Computer
{
    public string FormFactor { get; init; } = "Desktop";

    public void DisplayFixedSpecs()
    {
        DisplaySpecs();
        Console.WriteLine($"Form Factor: {FormFactor}");
    }
}
