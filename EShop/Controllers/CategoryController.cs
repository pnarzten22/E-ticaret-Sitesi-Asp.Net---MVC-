using BusinessLayer.Concrete.Repositories;
using DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryRepository categoryRepository = new CategoryRepository();
        ProductRepository productRepository = new ProductRepository();
        Context1 db = new Context1();
        public PartialViewResult CategoryList()
        {
            return PartialView(categoryRepository.GetList());
        }
        public ActionResult Details(int id)
        {
            var cat = categoryRepository.CategoryDetails(id);
            return View(cat);
        }
       
    }
}