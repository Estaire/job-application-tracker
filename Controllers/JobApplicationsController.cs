using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTracker.Web.Data;
using JobTracker.Web.Models;

namespace JobTracker.Web.Controllers;

[Authorize]
public class JobApplicationsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public JobApplicationsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: JobApplications
    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var applications = await _context.JobApplications
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.DateApplied)
            .ToListAsync();

        return View(applications);
    }

    // GET: JobApplications/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var userId = _userManager.GetUserId(User);
        var jobApplication = await _context.JobApplications
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (jobApplication == null)
        {
            return NotFound();
        }

        return View(jobApplication);
    }

    // GET: JobApplications/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: JobApplications/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CompanyName,RoleTitle,Status,DateApplied,JobPostingUrl,Notes")] JobApplication jobApplication)
    {
        if (ModelState.IsValid)
        {
            jobApplication.UserId = _userManager.GetUserId(User)!;
            _context.Add(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(jobApplication);
    }

    // GET: JobApplications/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var userId = _userManager.GetUserId(User);
        var jobApplication = await _context.JobApplications
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (jobApplication == null)
        {
            return NotFound();
        }

        return View(jobApplication);
    }

    // POST: JobApplications/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,RoleTitle,Status,DateApplied,JobPostingUrl,Notes")] JobApplication jobApplication)
    {
        var userId = _userManager.GetUserId(User);
        var existingApplication = await _context.JobApplications
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (existingApplication == null)
        {
            return NotFound();
        }

        if (id != jobApplication.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            existingApplication.CompanyName = jobApplication.CompanyName;
            existingApplication.RoleTitle = jobApplication.RoleTitle;
            existingApplication.Status = jobApplication.Status;
            existingApplication.DateApplied = jobApplication.DateApplied;
            existingApplication.JobPostingUrl = jobApplication.JobPostingUrl;
            existingApplication.Notes = jobApplication.Notes;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(jobApplication);
    }

    // GET: JobApplications/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var userId = _userManager.GetUserId(User);
        var jobApplication = await _context.JobApplications
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (jobApplication == null)
        {
            return NotFound();
        }

        return View(jobApplication);
    }

    // POST: JobApplications/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var userId = _userManager.GetUserId(User);
        var jobApplication = await _context.JobApplications
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (jobApplication != null)
        {
            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
