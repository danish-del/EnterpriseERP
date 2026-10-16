using AutoMapper;
using EnterpriseERP.Application.DTO.Branch;
using EnterpriseERP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Application.Mapping
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch,ResponseBranchDto>();
            CreateMap<CreateBranchDto,Branch>();
            CreateMap<UpdateBranchDto,Branch>();
        }
    }
}
