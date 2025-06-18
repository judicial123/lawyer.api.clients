using AutoMapper;
using lawyer.api.clients.application.DTO;
using lawyer.api.clients.application.UseCases.Client.Create;
using lawyer.api.clients.application.UseCases.Client.Update;
using lawyer.api.domain;

namespace awyer.api.clients.application.Common.MappingProfiles;

public class ClienteProfile: Profile
{
    public ClienteProfile()
    {
        CreateMap<ClientDto, Client>().ReverseMap();
        CreateMap<CreateClientCommand, Client>().ReverseMap();
        CreateMap<UpdateClientCommand, Client>().ReverseMap();
    }
}