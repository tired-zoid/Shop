
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace Shop.DAL
{
    public class DbService : IDbService, IDisposable
    {
        private readonly DataContext _data; 

        public DbService(DataContext data)
        {
            _data = data;
        }

        public IActionResult CreateProduct(Product product)
        {
          var response =  new Response();
            
            try
            {
                _data.Set<Product>().Add(product);
                _data.SaveChanges();          
                return new OkObjectResult(response.Success());
            }

            catch (DbUpdateException e)
            {
                return new BadRequestObjectResult(response.Error());         
            }
        }

        public void DeleteProduct(int id)
        {
            var removing = _data.Products.Find(id);
            _data.Remove(removing);
            _data.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _data.Update(product);
            _data.SaveChanges();
        }

        public void Dispose()
        {
            _data.Dispose();
        }
#nullable enable
        public IQueryable<Product> GetSelected(PageParameters pageParameters, string? name, string? category, int? price)
        {
            IQueryable<Product> data = _data.Set<Product>();

            if (!String.IsNullOrEmpty(name))
            { data = data.Where(p => p.Name.StartsWith(name)); }

            if (!String.IsNullOrEmpty(category))
            {
                if (category.Contains("All"))
                { 
                    data = data.Where(p => p.Category.Name == "Man" || p.Category.Name == "Woman"); 
                }
                
                else
                {
                    data = data.Where(p => p.Category.Name == (category));
                }         
            }

            if (price != 0)
            { data = data.Where(p => p.Price <= (price)); }

            return data
               .OrderBy(on => on.Name)
               .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
               .Take(pageParameters.PageSize);
        }

        public IQueryable<Review> GetProductReviews(int id)
        {
            return _data.Set<Review>().Where(r => r.ProductId == id); 
        }

        public IActionResult AddNewUser(User user)
        {
            var response = new Response(); 
       
            try
            {
                _data.Add(user);
                _data.SaveChanges();
                return new OkObjectResult(response.Success());
            }

            catch (DbUpdateException e)
            {
                return new BadRequestObjectResult(response.Error());
            }
        }

        public IQueryable<Product> GetAll(PageParameters pageParameters)     
        {
            return _data.Set<Product>()
                .OrderBy(on => on.Name)
                .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                .Take(pageParameters.PageSize);
        }

        public void AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string guid = Guid.NewGuid().ToString();
                string path = @"C:/Users/rahim/source/repos/Shop/Shop/ClientApp/src/assets/";

                using (var fileStream = new FileStream(Path.Combine(path, guid + ".jpg"), FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
            }       
        }

        //добавим сюда коммент для гита 

    }
}
