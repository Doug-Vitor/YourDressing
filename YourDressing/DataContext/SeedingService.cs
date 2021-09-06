using System;
using System.Collections.Generic;
using System.Linq;
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

            Employee e1 = new("Rosângela da Silva", new DateTime(2000, 3, 25), s1);
            Employee e2 = new("Márcio de Souza", new DateTime(2000, 3, 17), s1);
            Employee e3 = new("Robert Brown", new DateTime(1986, 12, 8), s2);
            Employee e4 = new("Leandro Gonçalves", new DateTime(2000, 7, 22), s2) { IsMonthEmployee = true };
            Employee e5 = new("Alexandre Dias Pereira", new DateTime(1995, 7, 28), s3) { IsMonthEmployee = true };
            Employee e6 = new("Letícia Alves de Oliveira", new DateTime(2004, 2, 13), s4);
            Employee e7 = new("Mario Alberto dos Anjos", new DateTime(1997, 9, 14), s5);

            Product product1 = new("Casaco moletom Lacoste", 369, s1);
            Product product2 = new("Calça moletom Adidas preta", 329, s1);
            Product product3 = new("Blusa de frio - manga longa", 59, s1);
            Product product4 = new("Tênis Nike preto e branco", 299, s3);
            Product product5 = new("Tênis Adidas Feminino branco", 189, s3);
            Product product6 = new("Tênis Mizuno 2 pares - cores distintas", 157, s3);
            Product product7 = new("Tênis Oakley Modoc 2.0", 479, s3);
            Product product8 = new("Aliança de casamento em ouro (4.7mm)", 4750, s5);
            Product product9 = new("Corrente de ouro 5k", 5799, s5);
            Product product10 = new("Brinco de ouro infantil com pérolas", 199, s5);

            List<Product> products1 = new()
            {
                product1, product2, product3
            };

            List<Product> products2 = new()
            {
                product4, product5, product6, product7
            };

            List<Product> products3 = new() {
                product8, product9, product10
            };

            OrderProducts orderProducts1 = new(product1, 1);
            OrderProducts orderProducts2 = new(product3, 3);
            OrderProducts orderProducts3 = new(product4, 1);
            OrderProducts orderProducts4 = new(product6, 1);
            OrderProducts orderProducts5 = new(product7, 1);
            OrderProducts orderProducts6 = new(product8, 1);
            OrderProducts orderProducts7 = new(product10, 2);

            List<OrderProducts> order1 = new()
            {
                orderProducts1, orderProducts2
            };

            List<OrderProducts> order2 = new()
            {
                orderProducts3, orderProducts4, orderProducts5
            };

            List<OrderProducts> order3 = new()
            {
                orderProducts6, orderProducts7
            };

            Sale sale1 = new() { OrderProducts = order1, Employee = e4 };
            Sale sale2 = new() { OrderProducts = order2, Employee = e5 };
            Sale sale3 = new() { OrderProducts = order3, Employee = e7 };

            e4.AddSale(sale1);
            e5.AddSale(sale2);
            e7.AddSale(sale3);

            _context.AddRange(s1, s2, s3, s4, s5);
            _context.AddRange(e1, e2, e3, e4, e5, e6, e7);
            _context.AddRange(product1, product2, product3, product4, product5, product6,
                product7, product8, product9, product10);
            _context.AddRange(sale1, sale2, sale3);
            _context.SaveChanges();
        }
    }
}
