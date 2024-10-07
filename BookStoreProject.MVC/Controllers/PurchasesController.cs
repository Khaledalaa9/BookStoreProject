using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreProject.DAL.Data;
using BookStoreProject.DAL.Data.Models;
using BookStoreProject.BLL;
using BookStoreProject.DAL.ViewModels;
using BookStoreProject.BLL.Managers;
using BookStoreProject.DAL.Migrations;

namespace BookStoreProject.MVC.Controllers
{
    public class PurchasesController : Controller
    {
     
        private readonly IBaseRepository<Purchase> _purchaseRepo;
        private readonly IBaseRepository<Book> _booksRepo;
        private readonly IBaseRepository<Supplier> _supplierRepo;
        

        public PurchasesController(IBaseRepository<Purchase> purchaseRepo, IBaseRepository<Book> bookRepo, IBaseRepository<Supplier> supplierRepo)
        {
            _purchaseRepo = purchaseRepo;
            _booksRepo = bookRepo;
            _supplierRepo = supplierRepo;
           
        }

        //public PurchasesController(BookStoreDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            //var bookStoreDbContext = _context.Purchases.Include(p => p.Suppler);
            //return View(await bookStoreDbContext.ToListAsync());

            return NotFound();
        }

        // GET: Purchases/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var purchase = await _context.Purchases
        //        .Include(p => p.Suppler)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (purchase == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(purchase);
        //}

        // GET: Purchases/Create
        public IActionResult Create()
        {
            //ViewData["SupplerID"] = new SelectList(_context.Suppliers, "id", "Address");
            //return View();


            PurchaseBookVM purchaseBookVM = new PurchaseBookVM()
            {
                Purchase = new Purchase()
                { 

                },
                Books = _booksRepo.GetAll(),
                Suppliers = _supplierRepo.GetAll()


            };


            return View(purchaseBookVM);
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseBookVM purchasevm)
        {
            if (ModelState.IsValid)
            {

                Purchase purchase = new Purchase()
                {
                    PurchaseDate = purchasevm.Purchase.PurchaseDate,
                    Quantity = purchasevm.Purchase.Quantity,
                    // BookId = purchasevm.Purchase.BookId,

                    SupplerID = purchasevm.Purchase.SupplerID

                };
                _purchaseRepo.Add(purchase);

            }

            return RedirectToAction("Home/index");
        }

        // GET: Purchases/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var purchase = await _context.Purchases.FindAsync(id);
        //    if (purchase == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["SupplerID"] = new SelectList(_context.Suppliers, "id", "Address", purchase.SupplerID);
        //    return View(purchase);
        //}

        //// POST: Purchases/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,PurchaseDate,SupplerID")] Purchase purchase)
        //{
        //    if (id != purchase.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(purchase);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PurchaseExists(purchase.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["SupplerID"] = new SelectList(_context.Suppliers, "id", "Address", purchase.SupplerID);
        //    return View(purchase);
        //}

        //// GET: Purchases/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var purchase = await _context.Purchases
        //        .Include(p => p.Suppler)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (purchase == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(purchase);
        //}

        //// POST: Purchases/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var purchase = await _context.Purchases.FindAsync(id);
        //    if (purchase != null)
        //    {
        //        _context.Purchases.Remove(purchase);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PurchaseExists(int id)
        //{
        //    return _context.Purchases.Any(e => e.Id == id);
        //}
    }
}
