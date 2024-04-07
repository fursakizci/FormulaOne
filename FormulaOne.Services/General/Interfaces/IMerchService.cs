namespace FormulaOne.Services.General.Interfaces;

public interface IMerchService
{
    void CreateMerch(Guid driverId);
    void RemoveMerch(Guid driverId);
}