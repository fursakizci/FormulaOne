using FormulaOne.DataService.Data;
using FormulaOne.DataService.Resositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Resositories;

public class DriverRepository:GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ILogger logger, AppDbContext context) : base(logger, context)
    {
    }

    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch(Exception e)
        {
            _logger.LogError(e,"{Repo} All function error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            //get my entity
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return false;

            result.Status = 0;
            result.UpdatedTime = DateTime.UtcNow;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} Delete function error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Driver driver)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);

            if (result == null)
                return false;

            result.DriverNumber = driver.DriverNumber;
            result.UpdatedTime = DateTime.UtcNow;
            result.FirstName = driver.FirstName;
            result.LastName = driver.LastName;
            result.DateOfBirth = driver.DateOfBirth;
            
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} Update function error", typeof(DriverRepository));
            throw;
        }
    }
    
    
    
}