using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFMVC.Context;
using EFMVC.Models;

namespace EFMVC.Controllers
{
    public class CustomerOrderItemsController : Controller
    {
        private readonly MVCContext _context;

        public CustomerOrderItemsController(MVCContext context)
        {
            _context = context;
        }

        // GET: CustomerOrderItems
        public async Task<IActionResult> Index()
        {
              return _context.CustomerOrderItems != null ? 
                          View(await _context.CustomerOrderItems.ToListAsync()) :
                          Problem("Entity set 'MVCContext.CustomerOrderItems'  is null.");
        }

        // GET: CustomerOrderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerOrderItems == null)
            {
                return NotFound();
            }

            var customerOrderItem = await _context.CustomerOrderItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerOrderItem == null)
            {
                return NotFound();
            }

            return View(customerOrderItem);
        }

        // GET: CustomerOrderItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerOrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedDate")] CustomerOrderItem customerOrderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerOrderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerOrderItem);
        }

        // GET: CustomerOrderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerOrderItems == null)
            {
                return NotFound();
            }

            var customerOrderItem = await _context.CustomerOrderItems.FindAsync(id);
            if (customerOrderItem == null)
            {
                return NotFound();
            }
            return View(customerOrderItem);
        }

        // POST: CustomerOrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedDate")] CustomerOrderItem customerOrderItem)
        {
            if (id != customerOrderItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerOrderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerOrderItemExists(customerOrderItem.Id))
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
            return View(customerOrderItem);
        }

        // GET: CustomerOrderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerOrderItems == null)
            {
                return NotFound();
            }

            var customerOrderItem = await _context.CustomerOrderItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerOrderItem == null)
            {
                return NotFound();
            }

            return View(customerOrderItem);
        }

        // POST: CustomerOrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerOrderItems == null)
            {
                return Problem("Entity set 'MVCContext.CustomerOrderItems'  is null.");
            }
            var customerOrderItem = await _context.CustomerOrderItems.FindAsync(id);
            if (customerOrderItem != null)
            {
                _context.CustomerOrderItems.Remove(customerOrderItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerOrderItemExists(int id)
        {
          return (_context.CustomerOrderItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
