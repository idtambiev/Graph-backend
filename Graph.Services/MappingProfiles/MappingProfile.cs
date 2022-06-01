using AutoMapper;
using Graph.Data.Entities;
using Graph.Services.DTOs;
using Graph.Services.DTOs.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.MappingProfiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<GraphEntity, GetGraphDTO>()
                .ForMember(dest => dest.Id, y => y.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, y => y.MapFrom(src => src.Name));

            CreateMap<Block, GetBlockDTO>()
                .ForMember(dest => dest.Id, y => y.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, y => y.MapFrom(src => src.Value))
                .ForMember(dest => dest.GraphId, y => y.MapFrom(src => src.GraphId))
                .ForMember(dest => dest.IsNewBlock, y => y.MapFrom(src => false))
                .ForMember(dest => dest.Relations, y => y.MapFrom(src => src.Relations));

            CreateMap<Relation, GetRelationDTO>()
                .ForMember(dest => dest.Id, y => y.MapFrom(src => src.Id))
                .ForMember(dest => dest.RelatedBlockId, y => y.MapFrom(src => src.RelatedId))
                .ForMember(dest => dest.BlockId, y => y.MapFrom(src => src.BlockId))
                .ForMember(dest => dest.Type, y => y.MapFrom(src => src.Type))
                .ForMember(dest => dest.Weight, y => y.MapFrom(src => src.Weight))
                .ForMember(dest => dest.IsNew, y => y.MapFrom(src => false));

            CreateMap<SaveRelationDTO, Relation>()
                .ForMember(dest => dest.RelatedId, y => y.MapFrom(src => src.RelatedBlockId))
                .ForMember(dest => dest.Type, y => y.MapFrom(src => src.Type))
                .ForMember(dest => dest.Weight, y => y.MapFrom(src => src.Weight))
                .ForMember(dest => dest.CreatedDate, y => y.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate, y => y.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsActive, y => y.MapFrom(src => true));


            CreateMap<CreateVectorDTO, Vector>()
                .ForMember(dest => dest.GraphId, y => y.MapFrom(src => src.GraphId))
                .ForMember(dest => dest.Value, y => y.MapFrom(src => src.Value))
                .ForMember(dest => dest.VectorItems, y => y.MapFrom(src => src.Items))
                .ForMember(dest => dest.CreatedDate, y => y.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate, y => y.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsActive, y => y.MapFrom(src => true));

            CreateMap<CreateVectorItemDTO, VectorItem>()
                .ForMember(dest => dest.Value, y => y.MapFrom(src => src.Value))
                .ForMember(dest => dest.Type, y => y.MapFrom(src => src.Type))
                .ForMember(dest => dest.Weight, y => y.MapFrom(src => src.Weight))
                .ForMember(dest => dest.CreatedDate, y => y.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate, y => y.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsActive, y => y.MapFrom(src => true));

            CreateMap<Vector, VectorDTO>()
                .ForMember(dest => dest.Id, y => y.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, y => y.MapFrom(src => src.Value))
                .ForMember(dest => dest.Items, y => y.MapFrom(src => src.VectorItems))
                .ForMember(dest => dest.MinWeight, y => y.MapFrom(src => src.VectorItems.OrderBy(x => x.Weight).First().Weight));

            CreateMap<VectorItem, VectorItemDTO>()
                 .ForMember(dest => dest.Id, y => y.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, y => y.MapFrom(src => src.Value))
                .ForMember(dest => dest.Weight, y => y.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Type, y => y.MapFrom(src => src.Type));

        }
    }
}
