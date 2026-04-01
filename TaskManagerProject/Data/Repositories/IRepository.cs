namespace TaskManagerProject.Data.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(string id);
        void Create(T entity);
        void Update(string id, T entity);
        void Delete(string id);
    }
}
