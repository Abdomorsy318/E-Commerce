using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BasketNotFoundException:NotFoundExceptions
    {
        public BasketNotFoundException(string id) : base($"Basket with id {id} not found")
        {
        }
    }
}
