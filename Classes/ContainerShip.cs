namespace ContainerManagementSystem;

public class ContainerShip
{
    public List<Container> Containers { get; private set; } = new List<Container>();
    public double MaxSpeed { get; }
    public int MaxContainerCount { get; }
    public double MaxWeight { get; }

    public ContainerShip(double maxSpeed, int maxContainerCount, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            throw new InvalidOperationException("Cannot load more containers: ship is full :(");
        }

        double currentLoad = Containers.Sum(c => c.CargoWeight + c.OwnWeight);
        if (currentLoad + container.CargoWeight + container.OwnWeight > MaxWeight * 1000)
        {
            throw new InvalidOperationException("Cannot load container: exceeds max weight capacity of the ship.");
        }
        
        Containers.Add(container);
    }

    public void UploadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container!=null)
        {
            container.UnloadCargo();
            Containers.Remove(container);
        }
    }

    public override string ToString()
    {
        var containerDescriptions = Containers.Select(c => c.ToString()).ToList();
        var containersInfo = containerDescriptions.Any() ? string.Join("\n", containerDescriptions) : "No containers loaded.";
        return $"ContainerShip - MaxSpeed: {MaxSpeed} knots, MaxContainerCount: {MaxContainerCount}, MaxWeight: {MaxWeight} tons" +
               $"\nLoaded Containers:" +
               $"\n{containersInfo}";
    }
}