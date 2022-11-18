using Shop.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Interfaces
{
    public interface IEmailService
    {
        void Send(Product product);
    }
}
