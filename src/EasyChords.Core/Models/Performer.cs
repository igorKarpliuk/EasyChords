using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChords.Core.Models
{
    public class Performer
    {
        int Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public virtual IList<Song> Songs { get; set; }
        public Performer()
        {
            this.Songs = new List<Song>();
        }


    }
}
