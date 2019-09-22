using System;
using System.Collections.Generic;
using System.Linq;
using GS.Core.Database.Entities;

namespace GS.Core.Api
{
    public class DataSedder
    {
       public static void Initialize(GsDbContext context)
        {
            if (!context.Genres.Any())
            {
                var genres = new List<Genres>()
                {
                    new Genres{ Id=11, Genre="Blue", Tag="GR00001000'", Description="Blues is about tradition and personal expression."},
                    new Genres{ Id=2, Genre="Classical", Tag="GR00001001", Description="Classical music is hard to define in specific terms."}
                };
                context.Genres.AddRange(genres);
                context.SaveChanges();
            }
            if (!context.Artists.Any())
            {
                var artists = new List<Artists>()
                {
                    new Artists{ Id=1, Tag="AR00000049", GenreId=11, Artist="Bessie Smith",YearsActive="1920s- 1930s",Biography="Classic Female Blues, Early Jazz,Vaudeville Blues", SmallThumbnail="AR00000049_thumbnail_s.jpg",BigThumbnail="AR00000049_thumbnail_b.jpg" },
                    new Artists{Id=2, Tag="AR00000050",GenreId=11,Artist="Muddy Waters",	YearsActive="1940s - 1980s",Biography="Blues Revival, Chicago Blues, Delta Blues, Electric Blues, Electric Chicago Blues, Regional Blues, Slide Guitar Blues",SmallThumbnail="AR00000050_thumbnail_s.jpg",BigThumbnail="AR00000050_thumbnail_b.jpg"}

                };
                context.Artists.AddRange(artists);
                context.SaveChanges();
            }
        }
    }
}
