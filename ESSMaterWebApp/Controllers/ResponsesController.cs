﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESSMaterWebApp.Models;

namespace ESSMaterWebApp.Controllers
{
    public class ResponsesController : Controller
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
        public ResponsesController(MaterDBContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        // GET: Responses
        /// <summary>
        /// Get all responses.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var materDBContext = _context.Responses.Include(r => r.ResponseQuestion).Include(r => r.ResponseQuestionnaire);
            return View(await materDBContext.ToListAsync());
        }

        //---------------------------------------------------------------------//
        // GET: Responses/Details/5
        /// <summary>
        /// Get details of a response.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses
                .Include(r => r.ResponseQuestion)
                .Include(r => r.ResponseQuestionnaire)
                .FirstOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        //---------------------------------------------------------------------//
        // GET: Responses/Create
        /// <summary>
        /// Create a new response.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["ResponseQuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId");
            ViewData["ResponseQuestionnaireId"] = new SelectList(_context.Questionnaires, "QuestionnaireId", "QuestionnaireId");
            return View();
        }

        //---------------------------------------------------------------------//
        // POST: Responses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create a new response.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponseId,Response1,SubmissionDate,StronglyDisagree,Disagree,Neutral,Agree,StronglyAgree,ResponseQuestionId,ResponseQuestionnaireId")] Response response)
        {
            if (ModelState.IsValid)
            {
                _context.Add(response);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResponseQuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", response.ResponseQuestionId);
            ViewData["ResponseQuestionnaireId"] = new SelectList(_context.Questionnaires, "QuestionnaireId", "QuestionnaireId", response.ResponseQuestionnaireId);
            return View(response);
        }

        //---------------------------------------------------------------------//
        // GET: Responses/Edit/5
        /// <summary>
        /// Edit a response.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            ViewData["ResponseQuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", response.ResponseQuestionId);
            ViewData["ResponseQuestionnaireId"] = new SelectList(_context.Questionnaires, "QuestionnaireId", "QuestionnaireId", response.ResponseQuestionnaireId);
            return View(response);
        }

        //---------------------------------------------------------------------//
        // POST: Responses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit a response.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponseId,Response1,SubmissionDate,StronglyDisagree,Disagree,Neutral,Agree,StronglyAgree,ResponseQuestionId,ResponseQuestionnaireId")] Response response)
        {
            if (id != response.ResponseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(response);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponseExists(response.ResponseId))
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
            ViewData["ResponseQuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", response.ResponseQuestionId);
            ViewData["ResponseQuestionnaireId"] = new SelectList(_context.Questionnaires, "QuestionnaireId", "QuestionnaireId", response.ResponseQuestionnaireId);
            return View(response);
        }

        //---------------------------------------------------------------------//
        // GET: Responses/Delete/5
        /// <summary>
        /// Delete a response.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses
                .Include(r => r.ResponseQuestion)
                .Include(r => r.ResponseQuestionnaire)
                .FirstOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        //---------------------------------------------------------------------//
        // POST: Responses/Delete/5
        /// <summary>
        /// Delete a response.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _context.Responses.FindAsync(id);
            if (response != null)
            {
                _context.Responses.Remove(response);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Check if a response exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ResponseExists(int id)
        {
            return _context.Responses.Any(e => e.ResponseId == id);
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 