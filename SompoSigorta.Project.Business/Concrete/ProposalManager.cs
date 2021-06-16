using Newtonsoft.Json;
using RestSharp;
using SompoSigorta.Project.Business.Abstract;
using SompoSigorta.Project.DataAccess.Abstract;
using SompoSigorta.Project.Entities.Concrete;
using System.Collections.Generic;
using static SompoSigorta.Project.Entities.EngineAPI.ApiResponse;

namespace SompoSigorta.Project.Business.Concrete
{
    public class ProposalManager : IProposalService
    {
        private readonly IProposalDal _proposalDal;       

        public ProposalManager(IProposalDal proposalDal)
        {
            _proposalDal = proposalDal;            
        }

        /// <summary>
        /// Tüm teklifleri getiren metod
        /// </summary>
        /// <returns>List<Proposal></returns>
        public List<Proposal> GetAllList()
        {
            List<Proposal> proposalList = _proposalDal.GetAll("Select * From [dbo].[Proposals] WITH(NOLOCK)");

            return proposalList;
        }

        /// <summary>
        /// Teklif detayını getiren metod
        /// </summary>
        /// <param name="model">Proposal</param>
        /// <returns>Proposal</returns>
        public Proposal GetDetail(int id)
        {
            if (id == 0) return new Proposal();

            Proposal proposal = _proposalDal.Get($"Select * From [db_9adf55_somposigorta].[dbo].[Proposals] WITH(NOLOCK) Where Id={id} ");

            return proposal;
        }

        /// <summary>
        /// Teklif ekleme işlemini yapan metod
        /// ApiHelper aracılığı ile ilgili apiye istek atıp ekleme işlemi yapıyoruz
        /// Sonra kendi db mize yazıyoruz
        /// </summary>
        /// <param name="model">Proposal</param>
        /// <returns>Proposal</returns>
        public List<Result> Insert(Proposal model)
        {
            if (model.ProposalNo < 0 || model.RenewalNo < 0 || model.EndorsNo < 0 || string.IsNullOrEmpty(model.ProductNo)) return new List<Result>();

            int rowId = _proposalDal.Insert($"INSERT INTO [dbo].[Proposals] ([ProposalNo] ,[RenewalNo] ,[EndorsNo] ,[ProductNo],[ApiRequest],[ApiResponse]) VALUES ({model.ProposalNo} ,{model.RenewalNo} ,{model.EndorsNo} ,N'{model.ProductNo}',N'{model.ApiRequest}',N'{model.ApiResponse}'); SELECT CAST(SCOPE_IDENTITY() as int)");

            #region restsharp

            var client = new RestClient("https://api.sompojapan.com.tr/sample/engine");

            var request = new RestRequest(Method.POST);

            request.AddHeader("postman-token", "b52c2aa7-fffa-898c-e6b2-39d118ac1478");

            request.AddHeader("cache-control", "no-cache");

            request.AddHeader("content-type", "application/json");

            request.AddParameter(@"application/json", "{ \r\n     Authentication : { \r\n          Source: \"SOMPO\", \r\n          Key: \"77lTCSn41w\"\t\t \r\n     }, \r\n     Object: { \r\n          ProposalNo: " + model.ProposalNo + ", \r\n          EndorsNo: " + model.EndorsNo + ", \r\n          RenewalNo: " + model.RenewalNo + ", \r\n          ProductNo: \"" + model.ProductNo + "\" \r\n     } \r\n} ", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            UpdateResponse(rowId, JsonConvert.SerializeObject(request.Body), response.Content);

            Root apiResponse = JsonConvert.DeserializeObject<Root>(response.Content);

            #endregion

            return apiResponse.Results;
        }

        /// <summary>
        /// Teklif güncelleme işlemini yapan metod
        /// </summary>
        /// <param name="model">Proposal</param>
        /// <returns>Proposal</returns>
        public int Update(Proposal model)
        {
            if (model.Id == 0 || model.ProposalNo < 0 || model.RenewalNo < 0 || model.EndorsNo < 0 || string.IsNullOrEmpty(model.ProductNo)) return 0;

            int result = _proposalDal.Update($"UPDATE [dbo].[Proposals] SET [ProposalNo] = {model.ProposalNo} ,[RenewalNo] = {model.RenewalNo} ,[EndorsNo] = {model.EndorsNo} ,[ProductNo] = N'{model.ProductNo}' WHERE Id={model.Id}");

            return result;
        }
        /// <summary>
        /// Son Eklenen datanın istek ve yanıt bilgileri güncellenmekte
        /// </summary>
        /// <param name="Id">Son eklenen Id</param>
        /// <param name="apiRequest">istek</param>
        /// <param name="apiResponse">geri dönen yanıt</param>
        public void UpdateResponse(int Id, string apiRequest, string apiResponse)
        {
            try
            {
                _proposalDal.Update($"UPDATE [dbo].[Proposals] SET [ApiRequest] = N'{apiRequest}',[ApiResponse] = N'{apiResponse}' WHERE Id={Id}");
            }
            catch { }
        }

        /// <summary>
        /// Teklif silme işlemini yapan metod
        /// </summary>
        /// <param name="model">Proposal</param>
        /// <returns>Proposal</returns>
        public int Delete(Proposal model)
        {
            if (model.Id == 0) return 0;

            int result = _proposalDal.Delete($"DELETE FROM [dbo].[Proposals] WHERE Id={model.Id}");

            return result;
        }
                
    }
}
