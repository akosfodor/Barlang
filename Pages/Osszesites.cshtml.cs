using Barlang.Data;
using Barlang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Text;

namespace Barlang.Pages
{
    public class OsszesitesModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public OsszesitesModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public List<TelepulesOsszesito> TelepulesOsszesites { get; set; } = new();

        public void OnGet()
        {
            TelepulesOsszesites = _context.Barlangok.GroupBy(x => x.Telepules).Select(y => new TelepulesOsszesito{Telepules = y.Key, BarlangokSzama = y.Count()}).OrderByDescending(t => t.BarlangokSzama).ToList();
        }

        public class TelepulesOsszesito
        {
            public string Telepules { get; set; }
            public int BarlangokSzama { get; set; }
        }
    }
}
