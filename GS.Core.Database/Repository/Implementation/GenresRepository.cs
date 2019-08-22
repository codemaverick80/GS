using System;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Interfaces;

namespace GS.Core.Database.Repository.Implementation
{
    public class GenresRepository: Repository<Genres>, IGenresRepository
    {
        public GenresRepository(SGDbContext context):base(context)
        {

        }
    }
}
