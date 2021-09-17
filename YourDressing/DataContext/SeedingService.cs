using System;
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

            Employee e1 = new("Rosângela da Silva", new DateTime(2000, 3, 25), 1299);
            Employee e2 = new("Márcio de Souza", new DateTime(2000, 3, 17), 1299);
            Employee e3 = new("Robert Brown", new DateTime(1986, 12, 8), 1299);
            Employee e4 = new("Leandro Gonçalves", new DateTime(2000, 7, 22), 1299) { IsMonthEmployee = true };
            Employee e5 = new("Alexandre Dias Pereira", new DateTime(1995, 7, 28), 1299) { IsMonthEmployee = true };
            Employee e6 = new("Letícia Alves de Oliveira", new DateTime(2004, 2, 13), 1299);
            Employee e7 = new("Mario Alberto dos Anjos", new DateTime(1997, 9, 14), 1299);
            Employee e8 = new("Carlos Santana de Moura", new DateTime(1990, 2, 28), 1299);
            Employee e9 = new("Flávia Silva Dias", new DateTime(2002, 12, 1), 1299);
            Employee e10 = new("Sabrina Figueiredo", new DateTime(1998, 4, 19), 1299) { IsMonthEmployee = true};

            s1.AddEmployees(e1, e2);
            s2.AddEmployees(e3, e4);
            s3.AddEmployees(e5, e6);
            s4.AddEmployees(e7, e8);
            s5.AddEmployees(e9, e10);

            Product product1 = new("Kit 5 Bermudas moletom", 79) { SectionId = 1 };
            Product product2 = new("Saia Jeans em algodão", 79) { SectionId = 1 };
            Product product3 = new("Shorts Jeans Feminino", 279) { SectionId = 1 };
            Product product4 = new("Shorts Esportivos Masculino", 69) { SectionId = 1 };
            Product product5 = new("Camiseta Dry Vinho", 59) { SectionId = 1 };
            Product product6 = new("Kit 2 Camisetas esportivas", 65) { SectionId = 1 };
            Product product7 = new("Top Esportivo Mike preto e branco", 109) { SectionId = 1 };
            Product product8 = new("Vestido Camiseta Anidas", 249) { SectionId = 1 };
            Product product9 = new("Camisa Travel Juventus Anidas", 179) { SectionId = 1 };
            Product product10 = new("Camiseta Mike PSG 2021/22", 499) { SectionId = 1 };
            Product product11 = new("Casaco moletom Jacaré", 369) { SectionId = 2 };
            Product product12 = new("Calça moletom Anidas preta", 329) { SectionId = 2 };
            Product product13 = new("Blusa de frio - manga longa", 59) { SectionId = 2 };
            Product product14 = new("Moletom Segunda Pele Simple", 59) { SectionId = 2 };
            Product product15 = new("Moletom Classic FAZaFILA", 89) { SectionId = 2 };
            Product product16 = new("Moletom Anidas Feminina", 169) { SectionId = 2 };
            Product product17 = new("Jogger Moletom White com bolsos", 99) { SectionId = 2 };
            Product product18 = new("Calça Jeans cintura alta", 129) { SectionId = 2 };
            Product product19 = new("Calça Skinny básica Masculina", 109) { SectionId = 2 };
            Product product20 = new("Kit Moletons sortidos 6und (unissex)", 299) { SectionId = 2 };
            Product product21 = new("Tênis Mike preto e branco", 299) { SectionId = 3 };
            Product product22 = new("Tênis Anidas Feminino branco", 189) { SectionId = 3 };
            Product product23 = new("Tênis Bizuno 2 pares - cores distintas", 157);
            Product product24 = new("Tênis Dokley Modoc 2.0", 479) { SectionId = 3 };
            Product product25 = new("Chuteira Mike Unissex", 499) { SectionId = 3 };
            Product product26 = new("Tênis Olympiadas Masculino", 209) { SectionId = 3 };
            Product product27 = new("Tênis Esportivo Olympiadas Feminino", 179) { SectionId = 3 };
            Product product28 = new("Kit 2 botas Comfort Feminina", 129) { SectionId = 3 };
            Product product29 = new("Sandália Salto Grosso", 99) { SectionId = 3 };
            Product product30 = new("Chuteira Futsal Mike Vermelha", 159) { SectionId = 3 };
            Product product31 = new("Boné Aba Reta Mike", 119) { SectionId = 4 };
            Product product32 = new("Óculos de Sol Romeu&Julieta 2.0", 361) { SectionId = 4 };
            Product product33 = new("Par de luvas motociclistas", 179) { SectionId = 4 };
            Product product34 = new("Kit 3 pares de luvas de frio", 199) { SectionId = 4 };
            Product product35 = new("Óculos inteligente multifocal", 99) { SectionId = 4 };
            Product product36 = new("Aliança de casamento em ouro (4.7mm)", 4750) { SectionId = 5 };
            Product product37 = new("Corrente de ouro 5k", 5799) { SectionId = 5 };
            Product product38 = new("Brinco de ouro infantil com pérolas", 199) { SectionId = 5 };
            Product product39 = new("Argolas de prata Feminina", 199) { SectionId = 5 };
            Product product40 = new("Colar feminino com pérolas (réplica)", 149) { SectionId = 5 };

            s1.AddProducts(product1, product2, product3, product4, product5, product6, product7, product8,
                product9, product10);
            s2.AddProducts(product11, product12, product13, product14, product15, product16, product17, product18,
                product19, product20);
            s3.AddProducts(product21, product22, product23, product24, product25, product26, product27, product28,
                product29, product30);
            s4.AddProducts(product31, product32, product33, product34, product35);
            s5.AddProducts(product36, product37, product38, product39, product40);

            OrderProducts orderProducts1 = new(5, product5, 2);
            OrderProducts orderProducts2 = new(6, product6, 1);
            OrderProducts orderProducts3 = new(3, product3, 1);
            OrderProducts orderProducts4 = new(13, product13, 1);
            OrderProducts orderProducts5 = new(11, product11, 1);
            OrderProducts orderProducts6 = new(12, product12, 1);
            OrderProducts orderProducts7 = new(13, product13, 1);
            OrderProducts orderProducts8 = new(20, product20, 1);
            OrderProducts orderProducts9 = new(24, product24, 1);
            OrderProducts orderProducts10 = new(26, product26, 1);
            OrderProducts orderProducts11 = new(29, product29, 2);
            OrderProducts orderProducts12 = new(28, product28, 1);
            OrderProducts orderProducts13 = new(31, product31, 2);
            OrderProducts orderProducts14 = new(34, product34, 1);
            OrderProducts orderProducts15 = new(38, product38, 1);
            OrderProducts orderProducts16 = new(38, product38, 2);
            OrderProducts orderProducts17 = new(40, product40, 1);
            OrderProducts orderProducts18 = new(40, product40, 1);

            Sale sale1 = new();
            Sale sale2 = new();
            Sale sale3 = new();
            Sale sale4 = new();
            Sale sale5 = new();
            Sale sale6 = new();
            Sale sale7 = new();
            Sale sale8 = new();
            Sale sale9 = new();
            Sale sale10 = new();
            Sale sale11 = new();
            Sale sale12 = new();
            Sale sale13 = new();

            sale1.AddOrderProduct(orderProducts1);
            sale1.AddOrderProduct(orderProducts2);
            sale2.AddOrderProduct(orderProducts3);
            sale3.AddOrderProduct(orderProducts4);
            sale4.AddOrderProduct(orderProducts5);
            sale4.AddOrderProduct(orderProducts6);
            sale4.AddOrderProduct(orderProducts7);
            sale5.AddOrderProduct(orderProducts8);
            sale6.AddOrderProduct(orderProducts9);
            sale6.AddOrderProduct(orderProducts10);
            sale7.AddOrderProduct(orderProducts11);
            sale8.AddOrderProduct(orderProducts12);
            sale9.AddOrderProduct(orderProducts13);
            sale10.AddOrderProduct(orderProducts14);
            sale11.AddOrderProduct(orderProducts15);
            sale12.AddOrderProduct(orderProducts16);
            sale12.AddOrderProduct(orderProducts17);
            sale13.AddOrderProduct(orderProducts18);

            sale1.SetTotalPrice();
            e1.AddSale(sale1);

            sale2.SetTotalPrice();
            e2.AddSale(sale2);

            sale3.SetTotalPrice();
            e3.AddSale(sale3);

            sale4.SetTotalPrice();
            sale5.SetTotalPrice();
            e4.AddSales(sale4, sale5);

            sale6.SetTotalPrice();
            sale7.SetTotalPrice();
            e5.AddSales(sale6, sale7);

            sale8.SetTotalPrice();
            e6.AddSale(sale8);

            sale9.SetTotalPrice();
            e7.AddSale(sale9);

            sale10.SetTotalPrice();
            e8.AddSale(sale10);

            sale11.SetTotalPrice();
            e9.AddSale(sale11);

            sale12.SetTotalPrice();
            sale13.SetTotalPrice();
            e10.AddSales(sale12, sale13);

            _context.AddRange(s1, s2, s3, s4, s5);
            _context.AddRange(e1, e2, e3, e4, e5, e6, e7, e8, e9, e10);
            _context.AddRange(product1, product2, product3, product4, product5, product6, product7, product8, 
                product9, product10, product11, product12, product13, product14, product15, product16, product17, 
                product18, product19, product20, product21, product22, product23, product24, product25, product26, 
                product27, product28, product29, product30, product31, product32, product33, product34, product35, 
                product36, product37, product38, product39, product40);
            _context.AddRange(orderProducts1, orderProducts2, orderProducts3, orderProducts4, orderProducts5, 
                orderProducts6, orderProducts7, orderProducts8, orderProducts9, orderProducts10, orderProducts11, 
                orderProducts12, orderProducts13, orderProducts14, orderProducts15, orderProducts16, 
                orderProducts17, orderProducts18);
            _context.AddRange(sale1, sale2, sale3, sale4, sale5, sale6, sale7, sale8, sale9, sale10, sale11, sale12,
                sale13);
            _context.SaveChanges();
        }
    }
}
