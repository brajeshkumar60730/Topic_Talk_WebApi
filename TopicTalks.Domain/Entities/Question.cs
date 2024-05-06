﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TopicTalks.Domain.Entities
{
    public class Question
    {
        public long QuestionId { get; set; }

        private string _topic;
        public string Topic
        {
            get => _topic;
            set
            {
                // Replace multiple consecutive commas with a single comma
                value = Regex.Replace(value, ",+", ",");

                if (value.StartsWith(","))
                {
                    value = value[1..];
                }
                if (value.EndsWith(","))
                {
                    value = value[..^1];
                }

                _topic = value;
            }
        }

        public string Explanation { get; set; } = null!;

        public long? UserId { get; set; }

        [NotMapped]
        public bool HasTeachersResponse { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public User? User { get; set; }
    }
}
