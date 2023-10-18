namespace Photogram.Entities.Common;

public interface IAuditableEntity : IEntity
{
    DateTimeOffset CreatedDate { get; set; }

    DateTimeOffset? ModifiedDate { get; set; }
}
