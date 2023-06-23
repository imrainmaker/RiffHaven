using RiffHaven.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.DAL.Repositories
{
    public interface IProductRepository
    {
        public void AddProduct(Products product);
        public GuitarParts GetParts();
    }
}
