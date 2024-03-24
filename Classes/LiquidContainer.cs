namespace ContainerManagementSystem;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    
    public LiquidContainer(double cargoWeight, double height, double ownWeight, double depth, double maxCapacity, bool isHazardous) 
        : base(cargoWeight, height, ownWeight, depth, maxCapacity, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double weight)
    {
        double capacityLimit = IsHazardous ? 0.5 * MaxCapacity : 0.9 * MaxCapacity;
        if (CargoWeight + weight > capacityLimit)
        {
            NotifyHazard("Attempting to load beyond safe capacity. ");
            throw new OverfillException("Loading failed: exceeds safe cargo limit for hazardous materials.");
        }

        CargoWeight += weight;
    }
    
    public override void UnloadCargo()
    {
        CargoWeight = 0;
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD NOTIFICATION for container {SerialNumber}: {message}");
    }
    
}