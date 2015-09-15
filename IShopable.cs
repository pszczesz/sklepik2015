using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuchProstokata1
{
    interface IShopable
    {
        decimal Price { get; set; }
        double Quantity { get; set; }
        bool IsForShooping { get; set; }
    }
}
