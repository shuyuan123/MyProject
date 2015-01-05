using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    /// <summary>
    /// 产品相关操作类
    /// </summary>
    public class ProductController : ApiController
    {
        private static readonly IProductRepository respository = new ProductRepository();

        /// <summary>
        /// 获取所有产品
        /// </summary>
        public IEnumerable<Product> GetAllProduct() 
        {
            return respository.GetAll();
        }

        /// <summary>
        /// 根据Id获取产品
        /// </summary>
        /// <param name="id">产品id</param>
     
        public Product GetProduct(int id)
        {
            Product item = respository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        /// <summary>
        /// 根据分类获取产品信息
        /// </summary>
        /// <param name="category">分类</param>
        public IEnumerable<Product> GetProductByCategory(string category)
        {
            return respository.GetAll().Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="item">产品实体</param>
        public HttpResponseMessage PostProduct(Product item)
        {
            item = respository.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        /// <summary>
        /// 根据id修改产品
        /// </summary>
        /// <param name="id">要修改的产品id</param>
        /// <param name="product">产品实体</param>
        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!respository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// 根据id删除产品
        /// </summary>
        /// <param name="id">产品id</param>
        public void DeleteProduct(int id)
        {
            Product item = respository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            respository.Remove(id);
        }
    }
}
