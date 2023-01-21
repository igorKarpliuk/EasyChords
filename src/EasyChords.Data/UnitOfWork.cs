using EasyChords.Core.Interfaces;
using EasyChords.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChords.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public EasyChordsDbContext _dbContext; 
        public IGenericRepository<Chords> ChordsRepository { get; }
        public IGenericRepository<Comment> CommentsRepository { get; }
        public IGenericRepository<Genre> GenresRepository { get; }
        public IGenericRepository<Performer> PerformersRepository { get; }
        public IGenericRepository<Song> SongRepository { get; }
        public IGenericRepository<User> UsersRepository { get; }
        public UnitOfWork(EasyChordsDbContext dbContext,
            IGenericRepository<Chords> ChordsRepository,
            IGenericRepository<Comment> CommentsRepository,
            IGenericRepository<Genre> GenresRepository,
            IGenericRepository<Performer> PerformersRepository,
            IGenericRepository<Song> SongRepository,
            IGenericRepository<User> UsersRepository
            )
        {
            _dbContext = dbContext;
            this.ChordsRepository = ChordsRepository;
            this.CommentsRepository = CommentsRepository;
            this.GenresRepository = GenresRepository;
            this.PerformersRepository = PerformersRepository;
            this.SongRepository = SongRepository;
            this.UsersRepository = UsersRepository;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
