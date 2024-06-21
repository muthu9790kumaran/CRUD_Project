using CRUD_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_Project.Controllers
{
    public class CrudController : Controller
    {
        private readonly Pdatabase _hii;
        public CrudController(Pdatabase hii)
        {
            _hii = hii;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Crud mmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _hii.Add(mmodel);
                _hii.SaveChanges();
                TempData["hii"] = "Added Successfully";
                return RedirectToAction("Add");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Added" + ex;
                return View();

            }
        }

        public IActionResult Display()
        {
            var product = _hii.Product_Detail.ToList();
            return View(product);
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                var c = _hii.Product_Detail.Find(Id);
                if (c != null)
                {
                    _hii.Product_Detail.Remove(c);
                    _hii.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Display");
        }
        public IActionResult Update(int Id)
        {
            var c = _hii.Product_Detail.Find(Id);

            return View(c);
        }
        [HttpPost]
        public IActionResult Update(Crud mmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _hii.Product_Detail.Update(mmodel);
                _hii.SaveChanges();
                TempData["hii"] = "Updated Successfully";
                return RedirectToAction("Update");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Updated" + ex;
                return View();

            }
        }

    }
}
    

