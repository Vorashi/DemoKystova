﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoKystova
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DemoEntities : DbContext
    {
        public DemoEntities()
            : base("name=DemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<PartnerProduct> PartnerProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
