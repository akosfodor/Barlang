using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Text;
using Barlang.Data;
using Barlang.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Barlang.Pages
{
    public class BarlangokTelepulesenkentModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public BarlangokTelepulesenkentModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string KijeloltTelepules { get; set; }

        public IList<SelectListItem> Telepulesek { get; set; }

        public IList<BarlangModel> Barlangok { get; set; }

        public void OnGet()
        {
            Telepulesek = _context.Barlangok.Select(x => x.Telepules).Distinct().OrderBy(t => t).Select(t => new SelectListItem { Value = t, Text = t}).ToList();
            Barlangok = _context.Barlangok.Where(x => x.Telepules == KijeloltTelepules).ToList();
        }
    }
}
