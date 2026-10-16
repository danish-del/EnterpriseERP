using EnterpriseERP.Application.DTO.Branch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Application.Validators.Company
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateBranchDto>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Id).NotEmpty().
                WithMessage("Id is required");
        }
    }
}
