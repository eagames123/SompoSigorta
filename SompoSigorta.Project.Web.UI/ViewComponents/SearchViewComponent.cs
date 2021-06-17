using Microsoft.AspNetCore.Mvc;

namespace SompoSigorta.Project.Web.UI.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
