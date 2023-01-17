using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChords.Core.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public Genre Genre { get; set; }
        public virtual IList<Chords> Chords { get; set; }
        public virtual IList<Performer> Performers { get; set; }
        public Song()
        {
            this.Chords = new List<Chords>();
            this.Performers = new List<Performer>();
        }
    }
}
