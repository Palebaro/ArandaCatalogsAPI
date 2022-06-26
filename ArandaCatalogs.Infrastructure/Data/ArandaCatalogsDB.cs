using ArandaCatalogs.Infrastructure.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ArandaCatalogs.Infrastructure.Data
{
    public class ArandaCatalogsDB : DbContext
    {
        public ArandaCatalogsDB() : base("name=ArandaCatalogsDB")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        public static ArandaCatalogsDB Create()
        {
            return new ArandaCatalogsDB();
        }
    }
}
