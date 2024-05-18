namespace CleanArch.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public DateTime CreateAt { get; protected set; }
        public string? Hash { get; protected set; }

        protected Entity()
        {
            CreateAt = DateTime.Now;
            Hash = string.Empty;
        }
    }
}
