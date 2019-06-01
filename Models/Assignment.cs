﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAS
{
    public class Assignment
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string Attachment { get; set; }
        public string DueDate { get; set; }
        public int ClassID { get; set; }
        public string AddedOn { get; set; }
        public User CreateBy {get; set;}
        public List<Comments> Comments { get; set; }
    }
}
