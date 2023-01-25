using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyChords.Core.Models.Identity;

namespace EasyChords.Core.Models
{
    public class Chords
    {
        public int Id { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Text { get; set; }
        public int LikesCount { get; set; }
        public int ViewsCount { get; set; }
        public User Author { get; set; }
        public Song Song { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public Chords() 
        {
            this.Comments = new List<Comment>();
        }
    }
}
