using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserAuthApi.Models;

namespace UserAuthApi.Context
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Metrics>().HasData(
                new Metrics
                {
                    Id = 1,
                    Orders = 100,
                    Total = 100,
                    Stock = 2,
                    Users = 10
                }
            );

            modelBuilder.Entity<Orders>().HasData(
                new Orders 
                {
                    Id = 1,
                    Value = "200",
                    Date = "31/08/2024",
                    PaymentMethod = "Dinheiro",
                    Status = "Em Preparação"
                },new Orders 
                {
                    Id = 2,
                    Value = "200",
                    Date = "28/08/2024",
                    PaymentMethod = "Pix",
                    Status = "Em preparação"
                },new Orders 
                {
                    Id = 3,
                    Value = "200",
                    Date = "28/08/2024",
                    PaymentMethod = "Cartão de crédito",
                    Status = "Em entrega"
                },new Orders 
                {
                    Id = 4,
                    Value = "200",
                    Date = "27/08/2024",
                    PaymentMethod = "Cartão de crédito",
                    Status = "Entregue"
                },new Orders 
                {
                    Id = 5,
                    Value = "200",
                    Date = "24/08/2024",
                    PaymentMethod = "Dinheiro",
                    Status = "Em entrega"
                },new Orders 
                {
                    Id = 6,
                    Value = "200",
                    Date = "22/08/2024",
                    PaymentMethod = "Cartão de Débito",
                    Status = "Entregue"
                },new Orders 
                {
                    Id = 7,
                    Value = "200",
                    Date = "15/08/2024",
                    PaymentMethod = "Cartão de crédito",
                    Status = "Entregue"
                },new Orders 
                {
                    Id = 8,
                    Value = "200",
                    Date = "14/08/2024",
                    PaymentMethod = "Cartão de Débito",
                    Status = "Entregue"
                },new Orders 
                {
                    Id = 9,
                    Value = "200",
                    Date = "08/08/2024",
                    PaymentMethod = "Pix",
                    Status = "Entregue"
                },new Orders 
                {
                    Id = 10,
                    Value = "200",
                    Date = "15/07/2024",
                    PaymentMethod = "Pix",
                    Status = "Entregue"
                },new Orders 
                {
                    Id = 11,
                    Value = "200",
                    Date = "02/07/2024",
                    PaymentMethod = "Cartão de Débito",
                    Status = "Entregue"
                },new Orders 
                {
                    Id = 12,
                    Value = "200",
                    Date = "24/04/2024",
                    PaymentMethod = "Dinheiro",
                    Status = "Entregue"
                },new Orders 
                {
                    Id = 13,
                    Value = "200",
                    Date = "01/01/2024",
                    PaymentMethod = "Dinheiro",
                    Status = "Inativo"
                }
            );
        }
    }
}

