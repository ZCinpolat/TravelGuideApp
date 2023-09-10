﻿using System.ComponentModel.DataAnnotations;

namespace WEBAPI.DAL.Entities
{
    public class Visitor
    {
        [Key]
        public int VisitorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country{ get; set; }
        public string Mail{ get; set; }

    }
}
