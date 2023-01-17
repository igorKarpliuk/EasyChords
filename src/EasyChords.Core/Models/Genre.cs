using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChords.Core.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Song> Songs { get; set; }
        public Genre() 
        {
            this.Songs = new List<Song>();
        }
    }
}
