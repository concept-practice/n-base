namespace FromCoderToEngineer.Builder
{
    using System;

    public abstract class Entity
    {
        protected Entity(Guid id)
            : this()
        {
            Id = id;
        }

        protected Entity()
        {
        }

        public Guid Id { get; private set; }
    }
}
