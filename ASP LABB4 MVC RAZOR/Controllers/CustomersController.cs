using Microsoft.AspNetCore.Mvc;
using ASP_LABB4_MVC_RAZOR.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class CustomersController : Controller
{
    private readonly LibraryDbContext _context;

    public CustomersController(LibraryDbContext context)
    {
        _context = context;
    }

    // GET: Customers
    public IActionResult Index()
    {
        var customers = _context.Customers.ToList();
        return View(customers);
    }

    public IActionResult SearchByName(string searchString)
    {
        var customers = from m in _context.Customers
                        select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            customers = customers.Where(s => s.Name.Contains(searchString));
        }

        return View("Index", customers.ToList());
    }


    public IActionResult Books(int id)
    {
        var booksWithLoans = _context.Loans
                                     .Where(l => l.CustomerId == id)
                                     .Include(l => l.Book)
                                     .Select(l => new BookLoanViewModel
                                     {
                                         Title = l.Book.Title,
                                         Author = l.Book.Author,
                                         LoanDate = l.LoanDate,
                                         ReturnDate = l.ReturnDate,
                                         IsReturned = l.IsReturned
                                     })
                                     .ToList();

        ViewBag.CustomerName = _context.Customers.Find(id)?.Name;
        return View(booksWithLoans);
    }



    // GET: Customers/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer = _context.Customers
            .FirstOrDefault(m => m.UserId == id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // GET: Customers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Customers/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }


    // GET: Customers/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer = _context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    // POST: Customers/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("UserId,Name,Address,Email,PhoneNumber")] Customer customer)
    {
        if (id != customer.UserId)
        {
            return NotFound();
        }

        ModelState.Remove("Username");
        ModelState.Remove("Password");

        if (ModelState.IsValid)
        {
            try
            {
                var existingCustomer = _context.Customers.Find(id);
                if (existingCustomer == null) return NotFound();

                existingCustomer.Name = customer.Name;
                existingCustomer.Address = customer.Address;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;

                _context.Update(existingCustomer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.UserId == customer.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(customer);
    }


    // GET: Customers/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer = _context.Customers
            .FirstOrDefault(m => m.UserId == id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // POST: Customers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var customer = _context.Customers.Find(id);
        _context.Customers.Remove(customer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}

