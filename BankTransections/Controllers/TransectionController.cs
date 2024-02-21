using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankTransections.Models;

namespace BankTransections.Controllers
{
    public class TransectionController : Controller
    {
        private readonly TransectionDBContext _context;

        public TransectionController(TransectionDBContext context)
        {
            _context = context;
        }

        // GET: Transection
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trasections.ToListAsync());
        }

       

        // GET: Transection/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if(id == 0){
                return View(new Transection());
            }
            else
                return View(_context.Trasections.Find(id));
            
        }

        // POST: Transection/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransectionId,AccountNumber,BenificaryName,BankName,SwiftCode,Amount,Date")] Transection transection)
        {
            if (ModelState.IsValid)
            {
                if(transection.TransectionId == 0)
                {
                    transection.Date = DateTime.Now;
                    _context.Add(transection);
                }
                else
                    _context.Update(transection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transection);
        }

      
       

       
        // POST: Transection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transection = await _context.Trasections.FindAsync(id);
            if (transection != null)
            {
                _context.Trasections.Remove(transection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
