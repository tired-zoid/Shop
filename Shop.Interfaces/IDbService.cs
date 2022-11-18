using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using System.Linq;

namespace Shop.Interfaces   
{
    public interface IDbService 
    {
        IActionResult CreateProduct(Product product);

        void DeleteProduct(int id );
        
        void UpdateProduct(Product product);

#nullable enable
        IQueryable<Product> GetSelected(PageParameters pageParameters, string? name, string? category, int? price);    

        IQueryable<Review> GetProductReviews(int id);

        IActionResult AddNewUser(User user);

        IQueryable<Product> GetAll(PageParameters pageParameters);

        //   void SendEmail(Product product);

        void AddFile(IFormFile uploadedFile);
    }
}
