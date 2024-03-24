namespace ContainerManagementSystem.Models;

public class RefrigeratedContainer : Container
{
    private static Dictionary<string, double> ProductRequirements = new Dictionary<string, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };

    public string ProductType { get; }
    public double Temperature { get; private set; }

    public RefrigeratedContainer(double cargoWeight, double height, double ownWeight, double depth, double maxCapacity, string productType, double temperature)
        : base(cargoWeight, height, ownWeight, depth, maxCapacity, "C")
    {
        if (!ProductRequirements.ContainsKey(productType))
        {
            throw new ArgumentException($"Invalid product type: {productType}.");
        }

        ProductType = productType;
        Temperature = temperature;

        double requiredTemperature = ProductRequirements[productType];
        if (temperature < requiredTemperature)
        {
            throw new InvalidOperationException($"The temperature {temperature}°C for {productType} is too low;" +
                                                $"\n it must not be lower than {requiredTemperature}°C.");
        }
    }

    public override void LoadCargo(double weight)
    {
        if (CargoWeight + weight > MaxCapacity)
        {
            throw new OverfillException($"Cannot load cargo: weight exceeds max capacity of {MaxCapacity}kg.");
        }

        CargoWeight += weight;
    }

    public override void UnloadCargo()
    {
        CargoWeight = 0; 
    }
}