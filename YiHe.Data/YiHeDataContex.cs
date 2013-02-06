using System.Data.Entity;
using YiHe.Model.Library;
using YiHe.Model.Material;
using YiHe.Model.Navigation;
using YiHe.Model.Security;


namespace YiHe.Data
{
    public class YiHeDataContex : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<OuterLink> OuterLinks { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Part> Parts { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<OfficePhoto> Photos { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<User> Users { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}