using AutoMapper;
using lawyer.api.domain;
using lawyer.api.clients.datastore.mssql.Model;

namespace lawyer.api.clients.datastore.mssql.Model.MappingProfiles
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Client, ClientEntity>().ReverseMap();
        }
    }
}