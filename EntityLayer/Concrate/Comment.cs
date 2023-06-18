using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string  Description { get; set; }
        public DateTime CommentDate { get; set; }
        public string  CommentUser { get; set; }
        public bool Status  { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }

    }
}
