using System.Collections.Generic;

namespace GS.Core.Api.Models.Responses
{
    public class ArtistGetResponse
    {
        public long Id { get; set; }
        public string Tag { get; set; }
        public long GenreId { get; set; }
        public string Artist { get; set; }
        public string YearsActive { get; set; }
        public string Biography { get; set; }
        public string SmallThumbnail { get; set; }
        public string BigThumbnail { get; set; }


        public ICollection<AlbumGetResponse> Albums { get; set; }
        //public virtual Genres Genre { get; set; }
        //public virtual ArtistBasicInfo ArtistBasicInfo { get; set; }
        //public virtual ICollection<Albums> Albums { get; set; }


        /* Extending ArtistModel by adding ArtistBasicInfo properties, instead of creating new model for ArtistBasicInfo
        * We have to let AutoMapper know about the related data/entity
        *
        * Approach A: concat Related Entity with Paroperty name (ArtistBasicInfo+Born=ArtistBasicInfoBorn)
        * 
        *   public string ArtistBasicInfoBorn { get; set; }
            public string ArtistBasicInfoDied { get; set; }
            public string ArtistBasicInfoAka { get; set; }
        * 
        */


        /*
         * Approach B: Mapping individual property in ArtistModelProfile.cs
         *  this.CreateMap<Artists, ArtistModel>()
                .ForMember(artistModel=> artistModel.Born, o=>o.MapFrom(artistEntity=> artistEntity.ArtistBasicInfo.Born))
                .ForMember(artistModel=> artistModel.AlsoKnownAs, o=>o.MapFrom(artistEntity=> artistEntity.ArtistBasicInfo.Aka))
                .ForMember(artistModel => artistModel.Died, o => o.MapFrom(artistEntity => artistEntity.ArtistBasicInfo.Died));
         * 
         */

        public string Born { get; set; }
        public string Died { get; set; }
        public string AlsoKnownAs { get; set; }
    }
}