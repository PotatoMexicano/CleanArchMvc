﻿using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;

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

    }
}
