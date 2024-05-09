using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.WebUI.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IWebHostEnvironment _environment;

		public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment environment)
		{
			_productService = productService;
			_categoryService = categoryService;
			_environment = environment;

		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<ProductDTO> products = await _productService.GetProducts();
			return View(products);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductDTO product)
		{
			if (ModelState.IsValid)
			{
				await _productService.Add(product);
				return RedirectToAction(nameof(Index));
			}

			return View(product);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			ProductDTO productDTO = await _productService.GetById(id);

			if (productDTO == null)
			{
				return NotFound();
			}

			IEnumerable<CategoryDTO> categories = await _categoryService.GetCategories();

			ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productDTO.CategoryId);

			return View(productDTO);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ProductDTO productDTO)
		{
			if (ModelState.IsValid)
			{
				await _productService.Update(productDTO);
				return RedirectToAction(nameof(Index));
			}

			return View(productDTO);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			ProductDTO productDTO = await _productService.GetById(id);
			if (productDTO == null) return NotFound();

			return View(productDTO);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _productService.Remove(id);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			ProductDTO productDTO = await _productService.GetById(id);
			if (productDTO == null) return NotFound();

			string wwwroot = _environment.WebRootPath;
			string image = Path.Combine(wwwroot, "images\\", productDTO.Image);
			bool exists = System.IO.File.Exists(image);
			ViewBag.ImageExist = exists;

			return View(productDTO);
		}
	}
}
