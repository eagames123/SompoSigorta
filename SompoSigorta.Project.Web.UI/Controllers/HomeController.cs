using Microsoft.AspNetCore.Mvc;
using SompoSigorta.Project.Business.Abstract;
using SompoSigorta.Project.Entities.Concrete;
using SompoSigorta.Project.Web.UI.Models;
using System.Collections.Generic;
using static SompoSigorta.Project.Entities.EngineAPI.ApiResponse;

namespace SompoSigorta.Project.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProposalService _proposalService;

        public HomeController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }

        public IActionResult Index()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult SendProposal([FromBody] Proposal model)
        {
            List<Result> result = _proposalService.Insert(model);

            return Json(result);
        }

        [HttpPost]
        public IActionResult GetRequestForDialog(int id)
        {
            Proposal result = _proposalService.GetDetail(id);

            return Json(result.ApiRequest);
        }

        [HttpPost]
        public IActionResult GetResponseForDialog(int id)
        {
            Proposal result = _proposalService.GetDetail(id);

            return Json(result.ApiResponse);
        }

        public IActionResult GetAllResult()
        {
            List<Proposal> proposalList = _proposalService.GetAllList();

            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                ProposalList = proposalList
            };

            return View(homeIndexViewModel);
        }        

    }
}
