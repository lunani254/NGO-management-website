using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESSMaterWebApp.Models;

namespace ESSMaterWebApp.Controllers
{
    public class DonationInterestsController : Controller
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
        public DonationInterestsController(MaterDBContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        // GET: DonationInterests
        /// <summary>
        /// Get all donation interests.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonationInterests.ToListAsync());
        }

        //---------------------------------------------------------------------//
        // GET: DonationInterests/Details/5
        /// <summary>
        /// Get details of a donation interest.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationInterest = await _context.DonationInterests
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donationInterest == null)
            {
                return NotFound();
            }

            return View(donationInterest);
        }

        //---------------------------------------------------------------------//
        // GET: DonationInterests/Create
        /// <summary>
        /// Create a new donation interest.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        // POST: DonationInterests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create a new donation interest.
        /// </summary>
        /// <param name="donationInterest"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationId,FirstName,Surname,Country,EmailAddress,PhoneNumber,AmountPledged,DateSubmitted")] DonationInterest donationInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donationInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(donationInterest);
        }

        //---------------------------------------------------------------------//
        // GET: DonationInterests/Edit/5
        /// <summary>
        /// Edit a donation interest.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationInterest = await _context.DonationInterests.FindAsync(id);
            if (donationInterest == null)
            {
                return NotFound();
            }
            return View(donationInterest);
        }

        //---------------------------------------------------------------------//
        // POST: DonationInterests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Save changes to a donation interest.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="donationInterest"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonationId,FirstName,Surname,Country,EmailAddress,PhoneNumber,AmountPledged,DateSubmitted")] DonationInterest donationInterest)
        {
            if (id != donationInterest.DonationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donationInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationInterestExists(donationInterest.DonationId))
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
            return View(donationInterest);
        }

        //---------------------------------------------------------------------//
        // GET: DonationInterests/Delete/5
        /// <summary>
        /// Delete a donation interest.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationInterest = await _context.DonationInterests
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donationInterest == null)
            {
                return NotFound();
            }

            return View(donationInterest);
        }

        //---------------------------------------------------------------------//
        // POST: DonationInterests/Delete/5
        /// <summary>
        /// Delete a donation interest. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donationInterest = await _context.DonationInterests.FindAsync(id);
            if (donationInterest != null)
            {
                _context.DonationInterests.Remove(donationInterest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Check if a donation interest exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DonationInterestExists(int id)
        {
            return _context.DonationInterests.Any(e => e.DonationId == id);
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 