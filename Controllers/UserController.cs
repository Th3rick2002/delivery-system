using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcelDeliverySystem.Data;
using ParcelDeliverySystem.Models;

namespace ParcelDeliverySystem.Controllers;

[Authorize(Roles = "SuperAdmin")]
public class UserController : Controller
{
    private readonly AppDBContext _context;

    public UserController(AppDBContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        var users = await _context.Users
            .Include(u => u.Role)
            .Where(u => u.Role.RoleName == "BranchAdmin")
            .ToListAsync();
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var branchAdminRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "BranchAdmin");
        if (branchAdminRole == null)
        {
            return BadRequest("El rol BranchAdmin no existe.");
        }

        ViewBag.RoleId = branchAdminRole.RoleId;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(User user)
    {
        if (ModelState.IsValid)
        {
            user.UserId = Guid.NewGuid();
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        var branchAdminRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "BranchAdmin");
        ViewBag.RoleId = branchAdminRole?.RoleId;
        return View(user);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var branchAdminRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "BranchAdmin");
        ViewBag.RoleId = branchAdminRole?.RoleId;
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, User user)
    {
        if (id != user.UserId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.UserId))
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
        return View(user);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(m => m.UserId == id);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(Guid id)
    {
        return _context.Users.Any(e => e.UserId == id);
    }
}