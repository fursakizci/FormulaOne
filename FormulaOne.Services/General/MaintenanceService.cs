using FormulaOne.Services.General.Interfaces;

namespace FormulaOne.Services.General;

public class MaintenanceService:IMaintenanceService
{
    public void SyncRecords()
    {
        Console.WriteLine("The sync has started");
    }
}