﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOCUMENTATION.CORE.Entities
{
    public class Topic : BaseEntity
    {
        public Topic(string title, string description, int topicId, DateTime dateCreation)
        {
            Title = title;
            Description = description;
            TopicId = topicId;
            DateCreation = dateCreation;

            Topics = new List<Topic>();
            Archives = new List<Archive>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int? TopicId { get; set; }

        [NotMapped]
        public virtual List<Topic> Topics { get; set; }

        [NotMapped]
        public virtual List<Archive> Archives { get; set; }
    }
}