using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Pages_CartItems
{
    public class IndexModel : PageModel
    {
        private readonly Campus_Cart_Student_Marketplace.Data.ApplicationDbContext _context;

        public IndexModel(Campus_Cart_Student_Marketplace.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CartItem> CartItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CartItem = await _context.CartItem
                .Include(c => c.Item).ToListAsync();
        }
    }
}
