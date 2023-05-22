namespace BikeServiceAPI.DAL;

public interface IRepository<T>
{
    void Add(T entity);
    T GetById(long id);
    void Update(T entity);
    void Delete(long id);
    IEnumerable<T> GetAll();
}