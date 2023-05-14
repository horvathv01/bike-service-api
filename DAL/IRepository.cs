namespace BikeServiceAPI.DAL;

public interface IRepository<T>
{
    void Add(T entity);
    T GetById(int id);
    void Update(T entity);
    void Delete(int id);
    IEnumerable<T> GetAll();
}