using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barlang.Data;
using Barlang.Models;

namespace Barlang.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public DeleteModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BarlangModel BarlangModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlangmodel = await _context.Barlangok.FirstOrDefaultAsync(m => m.Id == id);

            if (barlangmodel == null)
            {
                return NotFound();
            }
            else
            {
                BarlangModel = barlangmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlangmodel = await _context.Barlangok.FindAsync(id);
            if (barlangmodel != null)
            {
                BarlangModel = barlangmodel;
                _context.Barlangok.Remove(BarlangModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
