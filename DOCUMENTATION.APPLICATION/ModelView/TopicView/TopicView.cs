using DOCUMENTATION.CORE.Entities;
using System;
using System.Collections.Generic;

namespace DOCUMENTATION.APPLICATION.ModelView.TopicView
{
    public class TopicView
    {
        public TopicView()
        {            
            Topics = new List<Topic>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int? TopicId { get; set; }       
        public List<Topic> Topics { get; set; }       
        public int AuthorId { get; set; }       
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public DateTime Creation { get; set; }
    }
}
