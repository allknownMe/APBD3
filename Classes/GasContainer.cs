namespace ContainerManagementSystem;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }
    
    public GasContainer(double cargoWeight, double height, double ownWeight, double depth, double maxCapacity, double pressure) 
        : base(cargoWeight, height, ownWeight, depth, maxCapacity, "G")
    {
        Pressure = pressure;
    }

    public override void LoadCargo(double weight)
    {
        NotifyHazard("Attempting to load beyond maximum capacity.");
        throw new OverfillException(" Loading faild. Beyond maximum capacity");
    }

    public override void UnloadCargo()
    {
        CargoWeight = Math.Max(CargoWeight * 0.05, 0);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard notification for container {SerialNumber}: {message}");
    }
}