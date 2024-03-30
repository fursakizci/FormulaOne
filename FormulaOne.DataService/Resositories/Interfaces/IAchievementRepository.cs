using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Resositories.Interfaces;

public interface IAchievementRepository:IGenericRepository<Achievement>
{
    Task<Achievement?> GetDriverAchievementAsync(Guid driverId);
    
}