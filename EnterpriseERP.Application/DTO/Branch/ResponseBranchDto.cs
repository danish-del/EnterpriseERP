using EnterpriseERP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Application.DTO.Branch
{
    public class ResponseBranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int ComapnyId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
