using FormulaOne.DataService.Data;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;


public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
{
    public AchievementRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public async Task<Achievement?> GetDriverAchievmentAsync(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetDriverAchievmentAsync function error", typeof(AchievementRepository));
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
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.id == id);

            if (result == null) return false;

            result.Status = 0;  //deleted
            result.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.id == achievement.id);
            if (result == null) return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.FastestLap = achievement.FastestLap;
            result.PolePositions = achievement.PolePositions;
            result.RaceWins = achievement.RaceWins;
            result.WorldChampionShip = achievement.WorldChampionShip;

            return true;


        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update function error", typeof(AchievementRepository));
            throw;
        }
    }
}