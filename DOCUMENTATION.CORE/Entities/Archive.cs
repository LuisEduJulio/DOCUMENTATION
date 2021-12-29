namespace DOCUMENTATION.CORE.Entities
{
    public class Archive : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}