using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobac3.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkout { get; }

        void SaveCheckout(Checkout checkout);
    }
}
