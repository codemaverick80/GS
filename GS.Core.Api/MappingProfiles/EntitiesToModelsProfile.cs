using System;
using System.Linq;
using AutoMapper;
using GS.Core.Api.Models;
using GS.Core.Database.Entities;

namespace GS.Core.Api.MapperProfiles
{
    public class EntitiesToModelsProfile : Profile
    {
        public EntitiesToModelsProfile ()
        {

            CreateMap<Artists, ArtistsModel>()
                .ForMember(dest=> dest.Born, source=>source.MapFrom(src=> src.ArtistBasicInfo.Born))
                .ForMember(dest => dest.AlsoKnownAs, source => source.MapFrom(src => src.ArtistBasicInfo.Aka))
                .ForMember(dest => dest.Died, source => source.MapFrom(src => src.ArtistBasicInfo.Died))
                //.ForMember(dest => dest.Albums, source => source.MapFrom(src => src.Albums.Select(x =>
                //        new AlbumModel
                //        {
                //            Album = x.Album,
                //            Year = x.Year,
                //            Label = x.Label,
                //            AlbumUrl = x.AlbumUrl,
                //            ThumbnailL = x.ThumbnailL,
                //            ThumbnailM = x.ThumbnailM,
                //            ThumbnailS = x.ThumbnailS,
                //            Rating = x.Rating,
                //            UserRating = x.UserRating
                //        })))
                ;


            CreateMap<Albums, AlbumsModel>()
                .ForMember(dest=>dest.AlbumId,source=>source.MapFrom(src=>src.Id));


            CreateMap<Tracks, TracksModel>()
                .ForMember(dest=>dest.TrackId, source=>source.MapFrom(src=>src.Id));

            CreateMap<Genres, GenresModel>();

        }
    }
}
