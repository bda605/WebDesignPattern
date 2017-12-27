using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using CHAP3.Model;
using CHAP3.Repository;
namespace CHAP3.User_Experience
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ProductRegistry>();

            });
        }
    }

    public class ProductRegistry : Registry
    {
        public ProductRegistry()
        {
            ForRequestedType<IProductRepository>().TheDefaultIsConcreteType<ProductRepository>();
        }

    }

}