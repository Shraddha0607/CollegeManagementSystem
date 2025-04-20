using AutoMapper;
using CollegeApp.Models.DomainModels;
using CollegeApp.Models.Dtos.RequestModels;
using CollegeApp.Models.Dtos.ResponseModels;

namespace CollegeApp.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicantResponse, ApplicantRequest>();
        CreateMap<ApplicantRequest, ApplicantResponse>();
        CreateMap<Transaction, TransactionResponse>();
    }
}
