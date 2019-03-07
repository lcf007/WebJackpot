using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebJackpot.Data;
using WebJackpot.Models;

namespace WebJackpot.Controllers
{
    public class JackpotsController : Controller
    {
        private readonly WebJackpotContext _context;

        public JackpotsController(WebJackpotContext context)
        {
            _context = context;
        }

        // GET: Jackpots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jackpot.ToListAsync());
        }

        // GET: Jackpots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jackpot = await _context.Jackpot
                .FirstOrDefaultAsync(m => m.JackpotID == id);
            if (jackpot == null)
            {
                return NotFound();
            }

            return View(jackpot);
        }

        // GET: Jackpots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jackpots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JackpotID,Name,CurrentWin,CurrentTime")] Jackpot jackpot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jackpot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jackpot);
        }

        // GET: Jackpots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jackpot = await _context.Jackpot.FindAsync(id);
            if (jackpot == null)
            {
                return NotFound();
            }
            return View(jackpot);
        }

        // POST: Jackpots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JackpotID,Name,CurrentWin,CurrentTime")] Jackpot jackpot)
        {
            if (id != jackpot.JackpotID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jackpot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JackpotExists(jackpot.JackpotID))
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
            return View(jackpot);
        }

        // GET: Jackpots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jackpot = await _context.Jackpot
                .FirstOrDefaultAsync(m => m.JackpotID == id);
            if (jackpot == null)
            {
                return NotFound();
            }

            return View(jackpot);
        }

        // POST: Jackpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jackpot = await _context.Jackpot.FindAsync(id);
            _context.Jackpot.Remove(jackpot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JackpotExists(int id)
        {
            return _context.Jackpot.Any(e => e.JackpotID == id);
        }
    }
}
