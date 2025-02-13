using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESSMaterWebApp.Models;

namespace ESSMaterWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        /// <summary>
        /// Database context.
        /// </summary>
        private readonly MaterDBContext _context;

        //---------------------------------------------------------------------//
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context"></param>
        public EmployeesController(MaterDBContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        // GET: Employees
        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        //---------------------------------------------------------------------//
        // GET: Employees/Details/5
        /// <summary>
        /// Get details of an employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        //---------------------------------------------------------------------//
        // GET: Employees/Create
        /// <summary>
        /// Create a new employee.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create a new employee.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,Surname,EmailAddress,PhoneNumber,Role,JobDescription")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //---------------------------------------------------------------------//
        // GET: Employees/Edit/5
        /// <summary>
        /// Edit an employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //---------------------------------------------------------------------//
        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Save changes to an employee.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,Surname,EmailAddress,PhoneNumber,Role,JobDescription")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        //---------------------------------------------------------------------//
        // GET: Employees/Delete/5
        /// <summary>
        /// Delete an employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        //---------------------------------------------------------------------//
        // POST: Employees/Delete/5
        /// <summary>
        /// Delete an employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Check if an employee exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 