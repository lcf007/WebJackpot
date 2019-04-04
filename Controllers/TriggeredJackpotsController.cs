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
    public class TriggeredJackpotsController : Controller
    {
        private readonly WebJackpotContext _context;

        public TriggeredJackpotsController(WebJackpotContext context)
        {
            _context = context;
        }

        // GET: TriggeredJackpots
        public async Task<IActionResult> Index()
        {
            var webJackpotContext = _context.TriggeredJackpots.Include(t => t.Jackpot).Include(t => t.Player);
            return View(await webJackpotContext.ToListAsync());
        }

        // GET: TriggeredJackpots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triggeredJackpot = await _context.TriggeredJackpots
                .Include(t => t.Jackpot)
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (triggeredJackpot == null)
            {
                return NotFound();
            }

            return View(triggeredJackpot);
        }

        // GET: TriggeredJackpots/Create
        public IActionResult Create()
        {
            ViewData["JackpotID"] = new SelectList(_context.Jackpots, "JackpotID", "Name");
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "Name");
            return View();
        }

        // POST: TriggeredJackpots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,JackpotID,PlayerID,CurrentWin,TriggerTime")] TriggeredJackpot triggeredJackpot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(triggeredJackpot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JackpotID"] = new SelectList(_context.Jackpots, "JackpotID", "Name", triggeredJackpot.JackpotID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "Name", triggeredJackpot.PlayerID);
            return View(triggeredJackpot);
        }

        // GET: TriggeredJackpots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triggeredJackpot = await _context.TriggeredJackpots.FindAsync(id);
            if (triggeredJackpot == null)
            {
                return NotFound();
            }
            ViewData["JackpotID"] = new SelectList(_context.Jackpots, "JackpotID", "Name", triggeredJackpot.JackpotID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "Name", triggeredJackpot.PlayerID);
            return View(triggeredJackpot);
        }

        // POST: TriggeredJackpots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,JackpotID,PlayerID,CurrentWin,TriggerTime")] TriggeredJackpot triggeredJackpot)
        {
            if (id != triggeredJackpot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(triggeredJackpot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TriggeredJackpotExists(triggeredJackpot.ID))
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
            ViewData["JackpotID"] = new SelectList(_context.Jackpots, "JackpotID", "Name", triggeredJackpot.JackpotID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "Name", triggeredJackpot.PlayerID);
            return View(triggeredJackpot);
        }

        // GET: TriggeredJackpots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triggeredJackpot = await _context.TriggeredJackpots
                .Include(t => t.Jackpot)
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (triggeredJackpot == null)
            {
                return NotFound();
            }

            return View(triggeredJackpot);
        }

        // POST: TriggeredJackpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var triggeredJackpot = await _context.TriggeredJackpots.FindAsync(id);
            _context.TriggeredJackpots.Remove(triggeredJackpot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TriggeredJackpotExists(int id)
        {
            return _context.TriggeredJackpots.Any(e => e.ID == id);
        }
    }
}
