using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class Response
    {
        public string Message { get; set; }
        public int StatusCode { get; set; } 

        public Response Success()
        {
            var response = new Response
            {
                Message = "All good",
                StatusCode = 200
            };
            return response;
        }

        public Response Error() 
        {
            var response = new Response
            {
                Message = "Something wrong",
                StatusCode = 409
            };
            return response;
        }

    }
}
