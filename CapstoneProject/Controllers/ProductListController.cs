﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProject.Context;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProject.Controllers
{
    public class ProductListController : Controller
    {
        private readonly CapstoneShoppingListDBContext _context;
        public DbSet<ShoppingListDetails> shoppingListDetails;
        public DbSet<ShoppingList> shoppingLists;
        public DbSet<ProductList> productLists;

        public ProductListController(CapstoneShoppingListDBContext context)
        {
            _context = context;
        }

        // GET: ProductLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductList.ToListAsync());
        }

        public IActionResult Checkout()
        {
            var cart = _context.ShoppingListDetails;
            var joinShoppingListDetails = (from p in _context.ProductList
                                           join sd in _context.ShoppingListDetails
                                           on p.Id equals sd.ProductId
                                           select p.Product).ToList();

            var shoppingListDetails = new ShoppingListDetails();
            //shoppingListDetails.joinShoppingListDetails = joinShoppingListDetails;
           return View(joinShoppingListDetails);
        }


        public IActionResult AddToCart(int Id)
        {
            var product = _context.ProductList.FirstOrDefault(_ => _.Id == Id);
            var shoppingListDetails = new ShoppingListDetails();

            shoppingListDetails.ProductId = product.Id;
            shoppingListDetails.Quantity = 1;
            shoppingListDetails.Price = product.Price;
            shoppingListDetails.Product = product;

            _context.ShoppingListDetails.Add(shoppingListDetails);
            _context.SaveChanges();

            return View(product);
        }

        // GET: ProductLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = await _context.ProductList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productList == null)
            {
                return NotFound();
            }

            return View(productList);
        }

        // GET: ProductLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Price")] ProductList productList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productList);
        }

        // GET: ProductLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = await _context.ProductList.FindAsync(id);
            if (productList == null)
            {
                return NotFound();
            }
            return View(productList);
        }

        // POST: ProductLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Price")] ProductList productList)
        {
            if (id != productList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductListExists(productList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productList);
        }

        // GET: ProductLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = await _context.ProductList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productList == null)
            {
                return NotFound();
            }

            return View(productList);
        }

        // POST: ProductLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productList = await _context.ProductList.FindAsync(id);
            _context.ProductList.Remove(productList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductListExists(int id)
        {
            return _context.ProductList.Any(e => e.Id == id);
        }
    }
}