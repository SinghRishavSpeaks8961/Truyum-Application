using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using TruyumApplication.Models;

namespace TruyumApplication.Controllers
{
    
    public class CartController : Controller
    {
        private TruyumContext _context;

        public CartController()
        {
            _context = new TruyumContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cart
        public ActionResult Index()
        {
            
            var items = _context.Carts.Include(m => m.MenuItem).ToList();
            ViewBag.Total = 0;
            
            return View(items);
        }
        //GET: Cart/AddToCart?menuItemId
        public ActionResult AddToCart(int menuItemId)
        {
            ViewBag.UserId = 1;
            Cart cart = new Cart
            {
                MenuItenId = menuItemId
            };
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var item = _context.Carts.SingleOrDefault(m => m.Id==id);
            if (item != null)
            {
                _context.Carts.Remove(item);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index","Cart");
        }
    }
}