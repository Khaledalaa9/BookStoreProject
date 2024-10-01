using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreProject.DAL.Data;
using OnlineBookStore.DAL.Data.Models;
using BookStoreProject.BLL.Managers;

namespace BookStoreProject.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        // private readonly BookStoreDbContext _context;
        private readonly IBaseRepository<Supplier> _supplierRepo;

        //public SuppliersController(BookStoreDbContext context)
        //{
        //    _context = context;
        //}

        public SuppliersController(IBaseRepository<Supplier> supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            // return View(await _context.Suppliers.ToListAsync());
            return View(await _supplierRepo.GetAllAsync());
        }

        //// GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var supplier = await _context.Suppliers
            //    .FirstOrDefaultAsync(m => m.id == id);
            var supplier = _supplierRepo.GetByID(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Address,TelephoneNumber")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierRepo.Add(supplier);

                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierRepo.GetByIDAsync(id.GetValueOrDefault());
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Address,TelephoneNumber")] Supplier supplier)
        {
            if (id != supplier.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _supplierRepo.Update(supplier);
                    // await _aw
                }
                catch (DbUpdateConcurrencyException)
                {
                    var sup = _supplierRepo.GetByID(supplier.id);
                    if (sup == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = _supplierRepo.GetByID(id.GetValueOrDefault());
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = _supplierRepo.GetByID(id);
            if (supplier != null)
            {
                _supplierRepo.Delete(supplier);
            }


            return RedirectToAction(nameof(Index));
        }


    }
}
