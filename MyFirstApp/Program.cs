using MyFirstApp.Models;

class Program
{
    static void Main(string[] args)
    {
        var laptop = new PortableComputer
        {
            Name = "My Laptop",
            Brand = "Dell",
            Processor = "Intel i7",
            Weight = 1.5,
            BatteryLife = 8
        };

        var desktop = new FixedComputer
        {
            Name = "Office PC",
            Brand = "HP",
            Processor = "AMD Ryzen 9",
            FormFactor = "All-in-One"
        };

        Console.WriteLine("=== Portable Computer ===");
        laptop.DisplayPortableSpecs();

        Console.WriteLine("\n=== Fixed Computer ===");
        desktop.DisplayFixedSpecs();
    }
}
