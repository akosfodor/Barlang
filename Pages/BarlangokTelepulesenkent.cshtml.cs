using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Text;
using Barlang.Data;
using Barlang.Models;

namespace Barlang.Pages
{
    public class BarlangokTelepulesenkentModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        private BarlangokTelepulesenkentModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public string KijeloltTelepules { get; set; }

        public IList<string> Telepulesek { get; set; }

        public IList<BarlangModel> Barlangok { get; set; }

        public void OnGet()
        {
            Telepulesek = _context.Barlangok.Select(x => x.Telepules).ToList();
            Barlangok = _context.Barlangok.Where(x => x.Telepules == KijeloltTelepules).ToList();
        }
    }
}
