using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace WebApiApp.Models
{
    public class Product
    {
    
        public int Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
      
        public string Name { get; set; }
       
        public string Category { get; set; }
       
        public decimal Price { get; set; }
    }
}