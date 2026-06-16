using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Pages_Items
{
    public class DetailsModel : PageModel
    {
        private readonly Campus_Cart_Student_Marketplace.Data.ApplicationDbContext _context;

        public DetailsModel(Campus_Cart_Student_Marketplace.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Item Item { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);

            if (item is not null)
            {
                Item = item;

                return Page();
            }

            return NotFound();
        }
    }
}
