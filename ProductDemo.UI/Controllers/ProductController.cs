using Microsoft.AspNetCore.Mvc;
using ProductDemo.Data.Models;
using ProductDemo.Data.Repository;
using System;

namespace ProductDemo.UI.Controllers
{
    public class ProductController:Controller
    {
        private readonly IProductRepository _productsRepo;

        public ProductController(IProductRepository productsRepo)
        {
            _productsRepo = productsRepo;
        }

       
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                { 
                    return View(product);
                }

                bool addPersonResult = await _productsRepo.AddAsync(product);
                if (addPersonResult)
                {
                    TempData["msg"] = "Successfully added";
                }
                else
                {
                    TempData["msg"] = "Could not added";
                }
                    
            } 
           
        
            catch(Exception ex)
            {
                TempData["msg"] = "Could not added";
            }
            return RedirectToAction(nameof(Add));

        }


        public async Task<IActionResult> Edit(int id)
        { var product=await _productsRepo.GetIdAsync(id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(product);
                var updateResult = await _productsRepo.UpdateAsync(product);
                if (updateResult)
                {
                    TempData["msg"] = "Updated succesfully";
                    return RedirectToAction(nameof(DisplayAll));

                }
                    
                else
                {
                    TempData["msg"] = "Could not updated";
                    return View(product);
                }
                    

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not updated";
            }
            return View(product);
        }


        //public async task<iactionresult> getbyid(int id)
        //{
        //    return view();
        //}
        [HttpGet]
        public async Task<IActionResult> DisplayAll(int id)
        {
            var Products = await _productsRepo.GetAllAsync(id);
            return View(Products);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteResult = await _productsRepo.DeleteAsync(id);
            return RedirectToAction(nameof(DisplayAll));
        }

    }
}
