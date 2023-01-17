using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChords.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual IList<Chords> Chords { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public User()
        {
            this.Chords = new List<Chords>();
            this.Comments = new List<Comment>();
        }
    }
}
