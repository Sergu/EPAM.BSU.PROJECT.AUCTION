using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.interfaces.Services;
using Auction.Models;
using Auction.Infrastructure.Mappers;

namespace Auction.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult GetAllActiveCategories(bool? isActive,int? category, string searchString)
        {
            var categories = categoryService.GetAll().Select(cat => cat.ToMvcCategory());

            //ViewBag.Category = category;
            //ViewBag.IsActive = isActive;
            //ViewBag.SearchString = searchString;

            return PartialView("_ActiveCategoryViewPartial", categories);
        }
        public ActionResult GetAllSoldCategories(int? category)
        {
            var categories = categoryService.GetAll().Select(cat => cat.ToMvcCategory());

            return PartialView("_SoldCategoryViewPartial", categories);
        }

        public ActionResult GetCategoryInfo(int? category)
        {
            CategoryViewModel model = null;
            if (category == null)
            {
                model = new CategoryViewModel();
                model.Name = "All";
                model.Description = "This category contains all lots from all categories";
            }
            else
            {
                model = categoryService.GetAll().FirstOrDefault(c => c.Id == category.Value).ToMvcCategory();
            }
            return PartialView("_CategoryInfoPartialView", model);
        }

    }
}
