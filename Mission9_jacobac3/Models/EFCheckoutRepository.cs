﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobac3.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Checkout> Checkout => context.checkouts
            .Include(x => x.Lines)
            .ThenInclude(x => x.Book);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));

            if (checkout.CheckoutId == 0)
            {
                context.checkouts.Add(checkout);
            }
            context.SaveChanges();
        }
    }
}
