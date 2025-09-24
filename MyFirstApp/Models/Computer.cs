namespace MyFirstApp.Models;

class Computer
{
    public string Name { get; init; } = "Unknown";
    public string Brand { get; init; } = "Generic";
    public int RAM { get; private set; }
    public string Processor { get; init; } = "N/A";

    public void DisplaySpecs()
    {
        Console.WriteLine($"Computer Name: {Name}");
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Processor: {Processor}");
        Console.WriteLine($"RAM: {RAM} GB");
    }
}
