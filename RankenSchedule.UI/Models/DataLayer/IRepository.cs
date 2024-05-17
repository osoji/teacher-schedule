namespace RankenSchedule.UI.Models.DataLayer
{
    public interface IRepository<T>where T : class
    {
        IEnumerable<T> List(QueryOption<T> options);

        //Get type by id
        T? Get(int id);

        //Get type with LINQ query
        T? Get(QueryOption<T> options);

        //Create
        void Insert(T entity);

        //Update
        void Update(T entity);

        //Delete
        void Delete(T entity);

        //Save
        void Save();
    }
}
