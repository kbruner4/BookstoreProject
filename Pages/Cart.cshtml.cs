using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreProject.Infrastructure;
using BookstoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreProject.Pages
{
    public class CartModel : PageModel
    {
        private iBookstoreProjectRepository repo { get; set; }
        public CartModel (iBookstoreProjectRepository temp)
        {
            repo = temp;
        }

        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
