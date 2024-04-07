using FormulaOne.Services.General.Interfaces;

namespace FormulaOne.Services.General;

public class MerchService:IMerchService
{
    public void CreateMerch(Guid driverId)
    {
        Console.WriteLine($"This will create merch for the driver {driverId}");
    }

    public void RemoveMerch(Guid driverId)
    {
        Console.WriteLine($"This will remove merch for the driver {driverId}"); 
    }
}