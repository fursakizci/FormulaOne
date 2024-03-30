using FormulaOne.DataService.Data;
using FormulaOne.DataService.Resositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Resositories;

public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
{
    public AchievementRepository(ILogger logger, AppDbContext context) : base(logger, context)
    {
    }

    public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == driverId);
            
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} Get Driver Achievement function error", typeof(AchievementRepository));
            throw;
        }
        
    }
    
    public override async Task<IEnumerable<Achievement>> All()
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
            _logger.LogError(e,"{Repo} All function error", typeof(AchievementRepository));
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
            _logger.LogError(e,"{Repo} Delete function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

            if (result == null)
                return false;

            result.UpdatedTime = achievement.UpdatedTime;
            result.FastestLap = achievement.FastestLap;
            result.PolePosition = achievement.PolePosition;
            result.WorldChampionship = achievement.WorldChampionship;
            result.RaceWins = achievement.RaceWins;
            
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} Update function error", typeof(AchievementRepository));
            throw;
        }
    }
}
