using MongoDB.Driver;

namespace TaskManagerProject.Data.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(MongoContext context, string collectionName)
        {
            _collection = context.GetCollection<T>(collectionName);
        }

        public List<T> GetAll()
        {
            return _collection.Find(_ => true).ToList();
            //Se esse não funcionar é por caus do _
        }

        public T GetById(string id)
        {
            return _collection
                .Find(Builders<T>.Filter.Eq("Id", id))
                .FirstOrDefault();
        }

        public void Create(T entity)
        {
            _collection.InsertOne(entity);
        }

        public void Update(string id, T entity)
        {
            _collection.ReplaceOne(
                Builders<T>.Filter.Eq("Id", id),
                entity
            );
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(
                Builders<T>.Filter.Eq("_id", id)
            );
        }
    }
}
