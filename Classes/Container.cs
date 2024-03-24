namespace ContainerManagementSystem;

public abstract class Container
{
    private static int _nextId = 1;

    public string SerialNumber { get; }
    public double CargoWeight { get; set; }
    public double Height { get; }
    public double OwnWeight { get; }
    public double Depth { get; }
    public double MaxCapacity { get; }

    protected Container(double cargoWeight, double height, double ownWeight,double depth, double maxCapacity, string type)
    {
        SerialNumber = $"KON-{type}-{_nextId++}";
        CargoWeight = cargoWeight;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        MaxCapacity = maxCapacity;
    }

    public abstract void LoadCargo(double weight);
    public abstract void UnloadCargo();
    
}