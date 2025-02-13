using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESSMaterWebApp.Models;

namespace ESSMaterWebApp.Controllers
{
    public class DiagnosesController : Controller
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
        public DiagnosesController(MaterDBContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        // GET: Diagnoses
        /// <summary>
        /// Get all diagnoses.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var materDBContext = _context.Diagnoses.Include(d => d.DiagnosisQuestionnaire);
            return View(await materDBContext.ToListAsync());
        }

        //---------------------------------------------------------------------//
        // GET: Diagnoses/Details/5
        /// <summary>
        /// Get details of a diagnosis.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses
                .Include(d => d.DiagnosisQuestionnaire)
                .FirstOrDefaultAsync(m => m.DiagnosisId == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        //---------------------------------------------------------------------//
        // GET: Diagnoses/Create
        /// <summary>
        /// Create a new diagnosis.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["DiagnosisQuestionnaireId"] = new SelectList(_context.Questionnaires, "QuestionnaireId", "QuestionnaireId");
            return View();
        }

        //---------------------------------------------------------------------//
        // POST: Diagnoses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Save a new diagnosis.
        /// </summary>
        /// <param name="diagnosis"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiagnosisId,AssessmentDetails,DiagnosisQuestionnaireId")] Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosisQuestionnaireId"] = new SelectList(_context.Questionnaires, "QuestionnaireId", "QuestionnaireId", diagnosis.DiagnosisQuestionnaireId);
            return View(diagnosis);
        }

        //---------------------------------------------------------------------//
        // GET: Diagnoses/Edit/5
        /// <summary>
        /// Edit a diagnosis.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            ViewData["DiagnosisQuestionnaireId"] = new SelectList(_context.Questionnaires, "QuestionnaireId", "QuestionnaireId", diagnosis.DiagnosisQuestionnaireId);
            return View(diagnosis);
        }

        //---------------------------------------------------------------------//
        // POST: Diagnoses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Save changes to a diagnosis.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="diagnosis"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiagnosisId,AssessmentDetails,DiagnosisQuestionnaireId")] Diagnosis diagnosis)
        {
            if (id != diagnosis.DiagnosisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosisExists(diagnosis.DiagnosisId))
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
            ViewData["DiagnosisQuestionnaireId"] = new SelectList(_context.Questionnaires, "QuestionnaireId", "QuestionnaireId", diagnosis.DiagnosisQuestionnaireId);
            return View(diagnosis);
        }

        //---------------------------------------------------------------------//
        // GET: Diagnoses/Delete/5
        /// <summary>
        /// Delete a diagnosis.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses
                .Include(d => d.DiagnosisQuestionnaire)
                .FirstOrDefaultAsync(m => m.DiagnosisId == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        //---------------------------------------------------------------------//
        // POST: Diagnoses/Delete/5
        /// <summary>
        /// Delete Confirmed for a diagnosis.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis != null)
            {
                _context.Diagnoses.Remove(diagnosis);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Check if a diagnosis exists.    
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DiagnosisExists(int id)
        {
            return _context.Diagnoses.Any(e => e.DiagnosisId == id);
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 