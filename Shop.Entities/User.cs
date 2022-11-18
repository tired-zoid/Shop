using Microsoft.EntityFrameworkCore;
using System;   

namespace Shop.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

    }
}
