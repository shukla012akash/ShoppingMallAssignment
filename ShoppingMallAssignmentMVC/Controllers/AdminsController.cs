using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingMallAssignmentMVC.Areas.Identity.Data;
using ShoppingMallAssignmentMVC.Data;
using ShoppingMallAssignmentMVC.Models;

namespace ShoppingMallAssignmentMVC.Controllers
{
    public class AdminsController : Controller
    {
        private readonly AdminDbContext _adminDbContext;
        private readonly ShoppingMallMVCContext _shoppingMallMVCContext;
        private ShoppingMallUser _shoppingMallUser;

        public AdminsController(AdminDbContext adminDbContext, ShoppingMallMVCContext shoppingMallMVCContext)
        {
            _adminDbContext = adminDbContext;
            _shoppingMallMVCContext = shoppingMallMVCContext;

        }

        public IActionResult Approve(AdminModel adminModels)
        {

            adminModels.Status = "Approved";
            adminModels.IsApproved = true;
            _adminDbContext.AdminModels.Update(adminModels);
            _adminDbContext.SaveChanges();
            return View("Index", adminModels);
        }
        public IActionResult Reject(AdminModel adminModels)
        {
            adminModels.Status = "Rejected";
            _adminDbContext.AdminModels.Update(adminModels);
            _adminDbContext.SaveChanges();
            return View("Index", adminModels);
        }
        [Authorize(Policy = "writeonly")]
        public IActionResult Index()
        {
            if (_adminDbContext.AdminModels == null)
            {
                return NotFound();
            }

            List<AdminModel> adminModels = new List<AdminModel>();
            adminModels = _adminDbContext.AdminModels.Where(x => x.Status == "Pending" || x.Status == "Approved").ToList();
            if (adminModels == null)
            {
                return NotFound();
            }
            return View(adminModels);

        }

    }
}