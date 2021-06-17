using Microsoft.AspNetCore.Mvc;

namespace SompoSigorta.Project.Web.UI.ViewComponents
{
    public class ResultViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
