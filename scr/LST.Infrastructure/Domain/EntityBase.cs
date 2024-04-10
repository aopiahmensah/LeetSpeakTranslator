namespace LST.Infrastructure.Domain
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            IsActive = true;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
