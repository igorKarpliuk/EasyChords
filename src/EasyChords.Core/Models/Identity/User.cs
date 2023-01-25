using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EasyChords.Core.Models.Identity
{
    public class User : IdentityUser <Guid>
    {
        //public int Id { get; set; }
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual IList<Chords> Chords { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public User()
        {
            Chords = new List<Chords>();
            Comments = new List<Comment>();
        }
    }
}
