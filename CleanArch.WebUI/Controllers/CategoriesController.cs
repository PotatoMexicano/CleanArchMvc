using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService _catService)
        {
            _categoryService = _catService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryDTO> categories = await _categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDTO = await _categoryService.GetById(id);
            if (categoryDTO == null) return NotFound();
            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDTO = await _categoryService.GetById(id);

            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var categoryDTO = await _categoryService.GetById(id);

            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }
    }
}
