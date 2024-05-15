﻿using Store.Models;

namespace Store.Pages.Admin.Products.Builder
{
    public interface IProductBuilder
    {
        IProductBuilder SetProductType(ProductType ProductType);
        IProductBuilder SetName(string name);
        IProductBuilder SetBrand(string name);
        IProductBuilder SetCategory(string category);
        IProductBuilder SetPrice(decimal price);
        IProductBuilder SetStockCount(int stockCount);
        IProductBuilder SetWarranty(int warranty);
        IProductBuilder SetDescription(string description);
        IProductBuilder SetImageFileName(string imageFileName);
        IProductBuilder SetProductDateTime(DateTime productDateTime);
        Product Build();
    }
}
