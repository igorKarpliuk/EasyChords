using EasyChords.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChords.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Chords> ChordsRepository { get; }
        IGenericRepository<Comment> CommentsRepository { get; }
        IGenericRepository<Genre> GenresRepository { get; }
        IGenericRepository<Performer> PerformersRepository { get; }
        IGenericRepository<Song> SongRepository { get; }
        IGenericRepository<User> UsersRepository { get; }
        void Save();
    }
}
