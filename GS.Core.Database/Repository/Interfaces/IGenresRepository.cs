using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Database.Entities;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface IGenresRepository : IRepository<Genres>
    {
        IEnumerable<Genres> GetAllWithSubGenres();
        IEnumerable<Genres> FindWithSubGenres(Func<Genres, bool> predicate);
        
    }
}
