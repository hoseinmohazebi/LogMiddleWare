namespace LogMiddleWare.Persistance
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> TableNoTracking { get; }
    }
}