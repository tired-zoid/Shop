using System;

namespace Shop.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public int Rate { get; set; }   

        public int ProductId { get; set; }

        public DateTime Date { get; set; }

        

    }
}
