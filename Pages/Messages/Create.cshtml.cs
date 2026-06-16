using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Pages_Messages
{
    public class CreateModel : PageModel
    {
        private readonly Campus_Cart_Student_Marketplace.Data.ApplicationDbContext _context;

        public CreateModel(Campus_Cart_Student_Marketplace.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ItemId"] = new SelectList(_context.Set<Item>(), "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Message Message { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Message.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
