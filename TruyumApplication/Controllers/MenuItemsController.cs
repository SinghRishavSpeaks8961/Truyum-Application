using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruyumApplication.Models;
using TruyumApplication.ViewModels;

namespace TruyumApplication.Controllers
{
    public class MenuItemsController : Controller
    {
        private TruyumContext _context;

        public MenuItemsController()
        {
            _context = new TruyumContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MenuItems
        public ActionResult Index()
        {
            return View();
            
        }
        
        public ActionResult Create()
        {
            ViewBag.Id = false;
            var categoryTypes = _context.Categories.ToList();
            var viewModel = new NewItemViewModel
            {
                Categories = categoryTypes
            };
            return View(viewModel);
        }
        
        public ActionResult Admin(bool isAdmin)
        {
            ViewBag.IsAdmin = isAdmin;

            List<MenuItem> items;
            if (isAdmin)
            {
                items = _context.MenuItems.Include(m => m.Category).ToList();
            }
            else
            {
                items = _context.MenuItems.Include(m => m.Category).Where(m => m.Active && m.DateOfLaunch < DateTime.Now).ToList();
            }
            if (items == null)
                return HttpNotFound("Item not found");
            
            return View(items);
        }
        
        [HttpPost]
        public ActionResult Submit(MenuItem menuItem)
        {
            if (menuItem.Id == 0)
            {
                _context.MenuItems.Add(menuItem);
            }
            else
            {
                var itemInDb = _context.MenuItems.SingleOrDefault(m => m.Id == menuItem.Id);
                itemInDb.Name = menuItem.Name;
                itemInDb.Price = menuItem.Price;
                itemInDb.FreeDelivery = menuItem.FreeDelivery;
                itemInDb.DateOfLaunch = menuItem.DateOfLaunch;
                itemInDb.CategoryId = menuItem.CategoryId;
                itemInDb.Active = menuItem.Active;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Admin", "MenuItems",routeValues:new { isAdmin=true});
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Id = true;
            var item = _context.MenuItems.SingleOrDefault(m => m.Id == id);

            if (item == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewItemViewModel
            {
                MenuItem = item,
                Categories = _context.Categories.ToList()
            };

            return View("Create",viewModel);
        }

    }
}