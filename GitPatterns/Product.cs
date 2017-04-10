using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{
    abstract class Product
    {
        public List<ProductObserver> Observers { get; set; }

        private int _Qty;
        private decimal _Price;

        public Product()
        {
            Observers = new List<ProductObserver>();
        }

        public int Qty {
            get
            {
                return _Qty; 
            }
            set
            {
                if (_Qty != value)
                {
                    _Qty = value;
                    QtyChange();
                }
            }
        }

        public decimal Price {
            get
            {
                return _Price;
            }
            set
            {
                if (_Price != value)
                {
                    _Price = value;
                    PriceChange();
                }
            }
        }

        public void Subscribe(ProductObserver Observer)
        {
            Observers.Add(Observer);
        }

        public void Unsubscribe(ProductObserver Observer)
        {
            Observers.Remove(Observer);
        }

        public void PriceChange()
        {
            foreach (ProductObserver Observer in Observers)
                Observer.OnPriceChange(Price);
        }

        public void QtyChange()
        {
            foreach (ProductObserver Observer in Observers)
                Observer.OnQtyChange(Qty);
        }

    }

    class SampleProduct : Product
    {
    }

    abstract class ProductObserver
    {
        public virtual int Qty { get; set; }
        public virtual decimal Price { get; set; }
        public abstract void OnQtyChange(int qty);
        public abstract void OnPriceChange(decimal price);
    }

    class SampleObserver : ProductObserver
    {
        public event EventHandler<int> QtyChanged;
        public event EventHandler<decimal> PriceChanged;

        public SampleObserver()
        {
        }

        public SampleObserver(EventHandler<int> QtyChangeHandler)
        {
            QtyChanged += QtyChangeHandler;
        }

        public SampleObserver(EventHandler<decimal> PriceChangeHandler)
        {
            PriceChanged += PriceChangeHandler;
        }

        public SampleObserver(EventHandler<int> QtyChangeHandler, EventHandler<decimal> PriceChangeHandler)
        {
            QtyChanged += QtyChangeHandler;
            PriceChanged += PriceChangeHandler;
        }

        public override void OnPriceChange(decimal price)
        {
            Price = price;
            if (PriceChanged != null)
                PriceChanged(this, Price);
        }

        public override void OnQtyChange(int qty)
        {
            Qty = qty;
            if (QtyChanged != null)
                QtyChanged(this, Qty);
        }
    }

}
