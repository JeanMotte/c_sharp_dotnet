namespace MyFirstApp.Models;

class PortableComputer : Computer
{
    public double Weight { get; set; }
    public double BatteryLife { get; set; }

    public void DisplayPortableSpecs()
    {
        DisplaySpecs();
        Console.WriteLine($"Weight: {Weight} kg");
        Console.WriteLine($"Battery Life: {BatteryLife} hours");
    }
}
