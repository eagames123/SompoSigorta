using SompoSigorta.Core.DataAccess.Dapper;
using SompoSigorta.Core.DataAccess.Dapper.Context;
using SompoSigorta.Project.DataAccess.Abstract;
using SompoSigorta.Project.Entities.Concrete;

namespace SompoSigorta.Project.DataAccess.Concrete.Dapper
{
    public class DpProposalDal : DapperEntityRepository<Proposal, DapperConnectContext>, IProposalDal
    {
    }
}
