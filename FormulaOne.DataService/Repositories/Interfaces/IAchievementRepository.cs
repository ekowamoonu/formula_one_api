namespace FormulaOne.DataService.Repositories;
using FormulaOne.Entities.DbSet;
using FormulaOne.DataService.Repositories.Interfaces;


public interface IAchievementRepository : IGenericRepository<Achievement>
{
    Task<Achievement?> GetDriverAchievmentAsync(Guid driverId);
}