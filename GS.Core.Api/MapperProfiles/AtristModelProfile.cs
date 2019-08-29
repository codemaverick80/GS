using System;
using AutoMapper;
using GS.Core.Api.Models;
using GS.Core.Database.Entities;

namespace GS.Core.Api.MapperProfiles
{
    public class AtristModelProfile: Profile
    {
        public AtristModelProfile()
        {
            this.CreateMap<Artists, ArtistsModel>()
                .ForMember(artistModel=> artistModel.Born, o=>o.MapFrom(artistEntity=> artistEntity.ArtistBasicInfo.Born))
                .ForMember(artistModel=> artistModel.AlsoKnownAs, o=>o.MapFrom(artistEntity=> artistEntity.ArtistBasicInfo.Aka))
                .ForMember(artistModel => artistModel.Died, o => o.MapFrom(artistEntity => artistEntity.ArtistBasicInfo.Died));

        }

    }
}
