using SompoSigorta.Core.DataAccess;
using SompoSigorta.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SompoSigorta.Project.DataAccess.Abstract
{
   public  interface IProposalDal : IEntityRepository<Proposal>
    {
    }
}
