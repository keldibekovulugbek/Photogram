namespace Photogram.Entities.Common;

public abstract class SoftDeletedEntity : AuditableEntity, ISoftDeletedEntity
{
    public bool IsDeleted { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }
}
