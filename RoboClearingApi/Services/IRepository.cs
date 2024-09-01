namespace RoboClearingApi.Services
{
    public interface IRepository <T, TId>
    {
        Task<TId> Add(T item);
        Task<T> GetById(TId id);
        Task<IEnumerable<T>> GetAll();
        Task<TId> Delete(TId id);
        Task<TId> UpDate(T item);

    }
}
