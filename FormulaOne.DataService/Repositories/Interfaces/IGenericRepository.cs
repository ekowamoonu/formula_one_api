using FormulaOne.DataService.Repositories.Interfaces;

namespace FormulaOne.DataService.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T?> GetById(Guid id);
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(Guid id);

}