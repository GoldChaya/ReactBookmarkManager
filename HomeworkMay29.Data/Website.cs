﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeworkMay29.Data
{
    public class Website
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public int Liked { get; set; }
    }
}