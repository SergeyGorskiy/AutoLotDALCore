using System.Threading.Tasks;
using AutoLotDALCore.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AutoLotMVCCore.ViewComponents
{
    public class InventoryViewComponent : ViewComponent
    {
        private readonly IInventoryRepo _repo;

        public InventoryViewComponent(IInventoryRepo repo)
        {
            _repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cars = _repo.GetAll(x => x.Make, true);
            if (cars != null)
            {
                return View("InventoryPartialView", cars);
            }
            return new ContentViewComponentResult("Unable to locate record.");
        }
    }
}