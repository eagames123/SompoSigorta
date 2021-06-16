using SompoSigorta.Project.Entities.Concrete;
using System.Collections.Generic;
using static SompoSigorta.Project.Entities.EngineAPI.ApiResponse;

namespace SompoSigorta.Project.Business.Abstract
{
    public interface IProposalService
    {
        List<Proposal> GetAllList();

        Proposal GetDetail(int id);

        List<Result> Insert(Proposal proposal);

        int Update(Proposal proposal);

        void UpdateResponse(int Id,string apiRequest,string apiResponse);
        
        int Delete(Proposal proposal);
    }
}