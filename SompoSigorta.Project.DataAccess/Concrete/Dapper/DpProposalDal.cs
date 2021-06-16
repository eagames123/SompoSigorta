using SompoSigorta.Core.DataAccess.Dapper;
using SompoSigorta.Core.DataAccess.Dapper.Context;
using SompoSigorta.Project.DataAccess.Abstract;
using SompoSigorta.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SompoSigorta.Project.DataAccess.Concrete.Dapper
{
   public class DpProposalDal : DapperEntityRepository<Proposal, DapperConnectContext>, IProposalDal
    {
    }
}
