using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class DimensionRosesController : Controller
    {
        private readonly ProjectContext _context;

        public DimensionRosesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: DimensionRoses
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.DimensionRose.ToListAsync());
        }

        // GET: DimensionRoses/Details/5
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionRose = await _context.DimensionRose
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (dimensionRose == null)
            {
                return NotFound();
            }

            return View(dimensionRose);
        }

        // GET: DimensionRoses/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DimensionRoses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] DimensionRose dimensionRose)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dimensionRose);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dimensionRose);
        }

        // GET: DimensionRoses/Edit/5
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionRose = await _context.DimensionRose.FindAsync(id);
            if (dimensionRose == null)
            {
                return NotFound();
            }
            return View(dimensionRose);
        }

        // POST: DimensionRoses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] DimensionRose dimensionRose)
        {
            if (id != dimensionRose.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dimensionRose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DimensionRoseExists(dimensionRose.EmployeeNumber))
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
            return View(dimensionRose);
        }

        // GET: DimensionRoses/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionRose = await _context.DimensionRose
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (dimensionRose == null)
            {
                return NotFound();
            }

            return View(dimensionRose);
        }

        // POST: DimensionRoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dimensionRose = await _context.DimensionRose.FindAsync(id);
            _context.DimensionRose.Remove(dimensionRose);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DimensionRoseExists(string id)
        {
            return _context.DimensionRose.Any(e => e.EmployeeNumber == id);
        }
    }
}
