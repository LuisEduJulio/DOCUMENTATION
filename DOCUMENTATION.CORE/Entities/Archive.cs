using System.ComponentModel.DataAnnotations.Schema;

namespace DOCUMENTATION.CORE.Entities
{
    public class Archive : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }

        [NotMapped]
        public virtual Topic Topic { get; set; }
    }
}