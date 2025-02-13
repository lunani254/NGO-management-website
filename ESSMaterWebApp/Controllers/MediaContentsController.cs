using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESSMaterWebApp.Models;

namespace ESSMaterWebApp.Controllers
{
    public class MediaContentsController : Controller
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
        public MediaContentsController(MaterDBContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents
        /// <summary>
        /// Get all media contents.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaContents.ToListAsync());
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents/Details/5
        /// <summary>
        /// Get details of a media content.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContents
                .FirstOrDefaultAsync(m => m.MediaId == id);
            if (mediaContent == null)
            {
                return NotFound();
            }

            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents/Create
        /// <summary>
        /// Create a new media content.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        // POST: MediaContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create a new media content.
        /// </summary>
        /// <param name="mediaContent"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediaId,MediaTitle,Description,Type,Url")] MediaContent mediaContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents/Edit/5
        /// <summary>
        /// Edit a media content.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContents.FindAsync(id);
            if (mediaContent == null)
            {
                return NotFound();
            }
            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // POST: MediaContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Save changes to a media content.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mediaContent"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MediaId,MediaTitle,Description,Type,Url")] MediaContent mediaContent)
        {
            if (id != mediaContent.MediaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaContentExists(mediaContent.MediaId))
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
            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // GET: MediaContents/Delete/5
        /// <summary>
        /// Delete a media content.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContents
                .FirstOrDefaultAsync(m => m.MediaId == id);
            if (mediaContent == null)
            {
                return NotFound();
            }

            return View(mediaContent);
        }

        //---------------------------------------------------------------------//
        // POST: MediaContents/Delete/5
        /// <summary>
        /// Delete a media content.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaContent = await _context.MediaContents.FindAsync(id);
            if (mediaContent != null)
            {
                _context.MediaContents.Remove(mediaContent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Check if a media content exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool MediaContentExists(int id)
        {
            return _context.MediaContents.Any(e => e.MediaId == id);
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 