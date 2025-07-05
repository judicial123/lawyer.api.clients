using AutoMapper;
using lawyer.api.clients.domain;

namespace lawyer.api.clients.datastore.mssql.Model.MappingProfiles;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Client, ClientEntity>().ReverseMap();
    }
}