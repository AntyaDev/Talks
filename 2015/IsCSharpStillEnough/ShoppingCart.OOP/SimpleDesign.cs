using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.OOP.SimpleDesign
{
    public class CartItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }

        public CartItem(Guid id, Guid productId)
        {
            this.Id = id;
            this.ProductId = productId;            
        }
    }

    public class ShoppingCart
    {
        private readonly List<CartItem> items = new List<CartItem>();

        private decimal paidAmount = 0;

        public bool IsPaidFor 
        {
            get { return this.paidAmount > 0; }
        }

        public IEnumerable<CartItem> Items 
        {
            get { return this.items; } 
        }

        public void AddItem(CartItem item)
        {
            if (!this.IsPaidFor)
            {
                this.items.Add(item);
            }
        }

        public void RemoveItem(CartItem item)
        {
            if (!this.IsPaidFor)
            {
                this.items.Remove(item);
            }
        }

        public void Pay(decimal amount)
        {
            if (!this.IsPaidFor)
            {
                this.paidAmount = amount;
            }
        }
    }
}
