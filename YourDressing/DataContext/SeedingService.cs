using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDressing.Models;

namespace YourDressing.DataContext
{
    public class SeedingService
    {
        private readonly AppDbContext _context;

        public SeedingService(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Employees.Any() || _context.Sections.Any() || _context.Sales.Any())
                return;

            Section s1 = new("Roupas de verão", "Setor de vendas destinado à roupas frescas usadas em dias quentes.");
            Section s2 = new("Roupas de inverno", "Setor de vendas destinado à roupas quentes usadas em dias frios.");
            Section s3 = new("Calçados", "Setor de vendas destinado à qualquer tipo de calçado: masculinos e femininos.");
            Section s4 = new("Acessórios", "Setor de vendas destinado a acessórios como óculos, bonés, etc.");
            Section s5 = new("Jóias", "Setor de vendas destinado a artigos de luxo, tais como: anéis, correntes, etc");

            Employee e1 = new("Rosângela da Silva", new DateTime(2000, 3, 25), 1299);
            Employee e2 = new("Márcio de Souza", new DateTime(2000, 3, 17), 1299);
            Employee e3 = new("Robert Brown", new DateTime(1986, 12, 8), 1299);
            Employee e4 = new("Leandro Gonçalves", new DateTime(2000, 7, 22), 1299) { IsMonthEmployee = true };
            Employee e5 = new("Alexandre Dias Pereira", new DateTime(1995, 7, 28), 1299) { IsMonthEmployee = true };
            Employee e6 = new("Letícia Alves de Oliveira", new DateTime(2004, 2, 13), 1299);
            Employee e7 = new("Mario Alberto dos Anjos", new DateTime(1997, 9, 14), 1299);

            s1.AddEmployee(e1);
            s1.AddEmployee(e2);
            s2.AddEmployee(e3);
            s2.AddEmployee(e4);
            s3.AddEmployee(e5);
            s4.AddEmployee(e6);
            s5.AddEmployee(e7);

            Product product1 = new("Casaco moletom Lacoste", 369) { SectionId = 2 };
            Product product2 = new("Calça moletom Adidas preta", 329) { SectionId = 2 };
            Product product3 = new("Blusa de frio - manga longa", 59) { SectionId = 2 };
            Product product4 = new("Tênis Nike preto e branco", 299) { SectionId = 3 };
            Product product5 = new("Tênis Adidas Feminino branco", 189) { SectionId = 3 };
            Product product6 = new("Tênis Mizuno 2 pares - cores distintas", 157);
            Product product7 = new("Tênis Oakley Modoc 2.0", 479) { SectionId = 3 };
            Product product8 = new("Aliança de casamento em ouro (4.7mm)", 4750);
            Product product9 = new("Corrente de ouro 5k", 5799) { SectionId = 5 };
            Product product10 = new("Brinco de ouro infantil com pérolas", 199) { SectionId = 5 };

            s2.AddProduct(product1);
            s2.AddProduct(product2);
            s2.AddProduct(product3);
            s3.AddProduct(product4);
            s3.AddProduct(product5);
            s3.AddProduct(product6);
            s3.AddProduct(product7);
            s5.AddProduct(product8);
            s5.AddProduct(product9);
            s5.AddProduct(product10);

            OrderProducts orderProducts1 = new(1, 1) { Product = product1};
            OrderProducts orderProducts2 = new(3, 3) { Product = product3 };
            OrderProducts orderProducts3 = new(4, 1) { Product = product4 };
            OrderProducts orderProducts4 = new(6, 1) { Product = product6 };
            OrderProducts orderProducts5 = new(7, 1) { Product = product7 };
            OrderProducts orderProducts6 = new(8, 1) { Product = product8 };
            OrderProducts orderProducts7 = new(10, 2) { Product = product10 };

            Sale sale1 = new();
            Sale sale2 = new();
            Sale sale3 = new();

            sale1.AddOrderProduct(orderProducts1);
            sale1.AddOrderProduct(orderProducts2);
            sale2.AddOrderProduct(orderProducts3);
            sale2.AddOrderProduct(orderProducts4);
            sale2.AddOrderProduct(orderProducts5);
            sale3.AddOrderProduct(orderProducts6);
            sale3.AddOrderProduct(orderProducts7);

            sale1.TotalPrice = 546.0;
            sale2.TotalPrice = 935.0;
            sale3.TotalPrice = 5148.0;

            e4.AddSale(sale1);
            e5.AddSale(sale2);
            e7.AddSale(sale3);

            _context.AddRange(s1, s2, s3, s4, s5);
            _context.AddRange(e1, e2, e3, e4, e5, e6, e7);
            _context.AddRange(product1, product2, product3, product4, product5, product6,
                product7, product8, product9, product10);
            _context.AddRange(orderProducts1, orderProducts2, orderProducts3, orderProducts4, orderProducts5, 
                orderProducts6, orderProducts7);
            _context.AddRange(sale1, sale2, sale3);
            _context.SaveChanges();
        }
    }
}
