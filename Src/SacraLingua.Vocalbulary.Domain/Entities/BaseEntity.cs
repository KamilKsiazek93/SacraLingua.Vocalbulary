namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public abstract class BaseEntity<TEntity, TId>
    {
        protected TId _id;
        public virtual TId Id => _id;
    }
}
