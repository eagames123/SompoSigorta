using SompoSigorta.Project.Entities.Concrete;
using System.Collections.Generic;
using static SompoSigorta.Project.Entities.EngineAPI.ApiResponse;

namespace SompoSigorta.Project.Business.Abstract
{
    public interface IProposalService
    {
        /// <summary>
        /// Tüm teklifleri getiren metod
        /// </summary>
        /// <returns>List<Proposal></returns>
        List<Proposal> GetAllList();

        /// <summary>
        /// Teklif detayını getiren metod
        /// </summary>
        /// <param name="model">Proposal</param>
        /// <returns>Proposal</returns>
        Proposal GetDetail(int id);

        /// <summary>
        /// Teklif ekleme işlemini yapan metod
        /// ApiHelper aracılığı ile ilgili apiye istek atıp ekleme işlemi yapıyoruz
        /// Sonra kendi db mize yazıyoruz
        /// </summary>
        /// <param name="model">Proposal</param>
        /// <returns>Proposal</returns>
        List<Result> Insert(Proposal proposal);

        /// <summary>
        /// Teklif güncelleme işlemini yapan metod
        /// </summary>
        /// <param name="model">Proposal</param>
        /// <returns>Proposal</returns>
        int Update(Proposal proposal);

        /// <summary>
        /// Son Eklenen datanın istek ve yanıt bilgileri güncellenmekte
        /// </summary>
        /// <param name="Id">Son eklenen Id</param>
        /// <param name="apiRequest">istek</param>
        /// <param name="apiResponse">geri dönen yanıt</param>
        void UpdateResponse(int Id, string apiRequest, string apiResponse);

        /// <summary>
        /// Teklif silme işlemini yapan metod
        /// </summary>
        /// <param name="model">Proposal</param>
        /// <returns>Proposal</returns>
        int Delete(Proposal proposal);
    }
}