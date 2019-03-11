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
    public class TriggerConditionsController : Controller
    {
        private readonly WebJackpotContext _context;

        public TriggerConditionsController(WebJackpotContext context)
        {
            _context = context;
        }

        // GET: TriggerConditions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TriggerCondition.ToListAsync());
        }

        // GET: TriggerConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triggerCondition = await _context.TriggerCondition
                .FirstOrDefaultAsync(m => m.ID == id);
            if (triggerCondition == null)
            {
                return NotFound();
            }

            return View(triggerCondition);
        }

        // GET: TriggerConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TriggerConditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,JackpotID,TriggerPoints")] TriggerCondition triggerCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(triggerCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(triggerCondition);
        }

        // GET: TriggerConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triggerCondition = await _context.TriggerCondition.FindAsync(id);
            if (triggerCondition == null)
            {
                return NotFound();
            }
            return View(triggerCondition);
        }

        // POST: TriggerConditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,JackpotID,TriggerPoints")] TriggerCondition triggerCondition)
        {
            if (id != triggerCondition.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(triggerCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TriggerConditionExists(triggerCondition.ID))
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
            return View(triggerCondition);
        }

        // GET: TriggerConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triggerCondition = await _context.TriggerCondition
                .FirstOrDefaultAsync(m => m.ID == id);
            if (triggerCondition == null)
            {
                return NotFound();
            }

            return View(triggerCondition);
        }

        // POST: TriggerConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var triggerCondition = await _context.TriggerCondition.FindAsync(id);
            _context.TriggerCondition.Remove(triggerCondition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TriggerConditionExists(int id)
        {
            return _context.TriggerCondition.Any(e => e.ID == id);
        }
    }
}
