﻿using AutoMapper;
using GS.Core.Api.Contracts.V1.Requests;
using GS.Core.Api.Contracts.V1.Responses;
using GS.Core.Database.Entities;

namespace GS.Core.Api.MappingProfiles
{
    public class EntitiesToModelsProfile : Profile
    {
        public EntitiesToModelsProfile ()
        {

            CreateMap<Artists, ArtistGetResponse>()
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


//            CreateMap<Albums, AlbumsModel>()
//                .ForMember(dest=>dest.ReleaseYear,source=>source.MapFrom(src=>src.Year));

            CreateMap<Albums, AlbumGetResponse>()
                .ForMember(dest=>dest.ReleaseYear,source=>source.MapFrom(src=>src.Year));


            CreateMap<Tracks, TrackGetResponse>()
                .ForMember(dest=>dest.TrackId, source=>source.MapFrom(src=>src.Id));

            CreateMap<Genres, GenreGetResponse>();

          
            
            
            CreateMap<Genres, GenreCreateRequest>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.GenreName, source => source.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Description, source => source.MapFrom(src => src.Description));

            CreateMap<GenreCreateRequest,Genres>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Genre, source => source.MapFrom(src => src.GenreName))
                .ForMember(dest => dest.Description, source => source.MapFrom(src => src.Description));

        }
    }
}
