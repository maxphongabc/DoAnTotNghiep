using Common.Model;
using Common.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interface
{
    public interface IProduct
    {
        Task<int> AddNewProduct(Product model);
        Task<int> UpdateProduct(int id, ProductModel model);
        List<string> ListName(string keyword);
        ProductModel ViewDetail(int id);
        void UpdateImages(int ProductId, string images);
    }
}
