using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrøveEksamen.Models;

namespace PrøveEksamen.Pages
{
    public class KontoModel : PageModel
    {
        public Bank bank { get; set; }
        public int BankID { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                bank = new Bank();
                bank.Name = "Vælg bank først";
                return Page();
            }
            BankID = id.Value;
            foreach(Bank b in BankModel.Banks)
            {
                if (b.Id == id)
                {
                    bank = b;
                }
            }
            return Page();
        }

        [BindProperty]
        public Konto Konto { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            foreach (Bank b in BankModel.Banks)
            {
                if (b.Id == id)
                {
                    if(b.KontoList == null)
                    {
                        b.KontoList = new List<Konto>();
                    }
                    b.KontoList.Add(Konto);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
