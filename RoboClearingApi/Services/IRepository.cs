namespace RoboClearingApi.Services
{
    public interface IRepository <T, TId>
    {
        TId Add(T item);
        T GetById(TId id);
        IEnumerable<T> GetAll();
        TId Delete(TId id);
        TId UpDate(T item);

    }
}
