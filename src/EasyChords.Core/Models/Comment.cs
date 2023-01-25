using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyChords.Core.Models.Identity;

namespace EasyChords.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CommentTime { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int ChordsId { get; set; }
        public Chords Chords { get; set; }
    }
}
