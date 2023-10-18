using Photogram.Entities.Common;

namespace Photogram.Entities
{
    public class Post : SoftDeletedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string ImagePath { get; set; }
    }
}
