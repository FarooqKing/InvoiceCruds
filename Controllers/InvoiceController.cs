using InvoiceCruds.Iservice;
using InvoiceCruds.Models;
using InvoiceCruds.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCruds.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IUnitOfWork _colorRepo;

        public InvoiceController(IUnitOfWork categoryRepo)
        {
            _colorRepo = categoryRepo;

        }
        public async Task<IActionResult> Index()
        {
            var color = await _colorRepo.invoiceDetail.GetAllAsync();

            return View(color);
        }

        // GET: Brands/Create
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(InvoiceDetail color)
        {

            await _colorRepo.invoiceDetail.AddAsync(color);
            return RedirectToAction(nameof(Index));

        }

        // GET: Brands/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return NotFound();
            }

            var color = await _colorRepo.invoiceDetail.GetByIdAsync(id.Value);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Edit(InvoiceDetail color)
        {

            await _colorRepo.invoiceDetail.UpdateAsync(color);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _colorRepo.invoiceDetail.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
