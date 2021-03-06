﻿using Booklist_Razor_Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booklist_Razor_Pages.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Books= await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            Book book = await _db.Books.FindAsync(Id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            Message = "Book deleted succesfully.";
            return RedirectToPage("Index");
        }
    }
}