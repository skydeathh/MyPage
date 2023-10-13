namespace MyPage.Domain.Repositories;

public interface IMyPageRepository<T> where T : class {
    Task<T> GetAsync(long id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}