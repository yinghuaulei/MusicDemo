using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicDemo.Models;

namespace MusicDemo.Controllers
{
    [ApiController]
    public class MusicsController : Controller
    {
        private readonly MusicContext _context;

        private readonly ILogger<MusicsController> _logger;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="logger">日志</param>
        public MusicsController(MusicContext context, ILogger<MusicsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //// GET: Musics
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Musics != null ? 
        //                  View(await _context.Musics.ToListAsync()) :
        //                  Problem("Entity set 'MusicContext.Musics'  is null.");
        //}

        // GET: Musics/Details/5
        [HttpGet]
        [Route("GetMusic")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Musics == null)
            {
                return NotFound();
            }

            var music = await _context.Musics
                .FirstOrDefaultAsync(m => m.Id == id);

            _logger.LogInformation("查询音乐");

            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        //// GET: Musics/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Musics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        [Route("CreateMusic")]
        public async Task<IActionResult> Create([Bind("Url,Title")] Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music);
                await _context.SaveChangesAsync();
                return Json(music);
            }
            return View(music);
        }

        //// GET: Musics/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null || _context.Musics == null)
        //    {
        //        return NotFound();
        //    }

        //    var music = await _context.Musics.FindAsync(id);
        //    if (music == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(music);
        //}

        // POST: Musics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("EditMusic")]
        //[ValidateAntiForgeryToken]
        [Route("EditMusic")]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Url,Title")] Music music)
        {
            if (id != music.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(music);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicExists(music.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(music);
            }
            return View(music);
        }

        // Get: Musics/Delete/5
        [HttpGet]
        [Route("DeleteMusic")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Musics == null)
            {
                return NotFound();
            }

            var music = await _context.Musics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music != null)
            {
                _context.Musics.Remove(music);
                await _context.SaveChangesAsync();
                return Json("");
            }

            return NotFound();
        }

        // POST: Musics/Delete/5
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //[Route("DeleteMusic")]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    if (_context.Musics == null)
        //    {
        //        return Problem("Entity set 'MusicContext.Musics'  is null.");
        //    }
        //    var music = await _context.Musics.FindAsync(id);
        //    if (music != null)
        //    {
        //        _context.Musics.Remove(music);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool MusicExists(long id)
        {
            return (_context.Musics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
