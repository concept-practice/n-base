namespace FromCoderToEngineer.Builder.Repository
{
    public interface IAddEntity<in T>
    {
        void AddEntity(T entity);
    }
}
