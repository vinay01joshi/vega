using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Api Resources
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom( v => v.Features.Select( vf => vf.FeatureId)));

            // Api resource to Domain
            CreateMap<VehicleResource,Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr,v) => {
                    // Remove unselected feature
                    var removedFeatures = new List<VehicleFeature>();
                    foreach(var f in v.Features)
                        if(!vr.Features.Contains(f.FeatureId))
                            removedFeatures.Add(f);
                    
                    foreach(var f in removedFeatures)
                        v.Features.Remove(f);

                    // Add new Features
                    foreach(var id in vr.Features)
                        if(v.Features.Any(f => f.FeatureId == id))
                            v.Features.Add(new VehicleFeature {FeatureId = id});

                });
        }
    }
}