﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_UWP_Full.Entity
{
     class Song
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string singer { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string link { get; set; }

        public Dictionary<string, string> Validate()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(name))
            {
                errors.Add("name", "Name is required!");
            }
            else if (name.Length < 5 || name.Length > 30)
            {
                errors.Add("name", "Name must be 5 to 30 characters!");
            }

            if (string.IsNullOrEmpty(singer))
            {
                errors.Add("singer", "Singer is required!");
            }

            if (string.IsNullOrEmpty(description))
            {
                errors.Add("description","Description is required!");
            }
            if (string.IsNullOrEmpty(author))
            {
                errors.Add("author", "Author is required!");
            }
            if (string.IsNullOrEmpty(thumbnail))
            {
                errors.Add("thumbnail", "Thumbnail is required!");
            }
            if (string.IsNullOrEmpty(link))
            {
                errors.Add("link", "Link is required!");
            }

            return errors;
        }
    }
}
