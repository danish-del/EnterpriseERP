using AutoMapper;
using EnterpriseERP.Application.DTO.Company;
using EnterpriseERP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Application.Mapping
{
    public class CompanyMapping : Profile
    {
        public CompanyMapping()
        {
            CreateMap<Company,ResponseComapnyDto>();
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<UpdateComapnyDto, Company>();
        }
    }
}
