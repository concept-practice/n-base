namespace FromCoderToEngineer.Builder.Repository
{
    public interface IUpdateEntity<in T>
    {
        void UpdateEntity(T entity);
    }
}
