using System;
using System.Collections.Generic;

namespace Varejo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> produtos = new Dictionary<string, double>
            {
                { "Açúcar", 3.99 },
                { "Arroz", 6.09 },
                { "Biscoito Maizena", 9.00 },
                { "Bolacha Passatempo", 3.50 },
                { "Bombril", 3.04 },
                { "Café", 8.74 },
                { "Caixa de cotonete", 9.90 },
                { "Detergente", 8.95 },
                { "Farinha", 3.79 },
                { "Feijão", 7.38 },
                { "Leite líquido", 4.89 },
                { "Macarrão", 9.90 },
                { "Massa de cuscuz", 2.85 },
                { "Maçã com caramelo", 7.98},
                { "Nescau", 8.55 },
                { "Óleo de cozinha", 8.00 },
                { "Pão de forma", 7.00 },
                { "Pasta de dente", 2.49 },
                { "Placa de ovos", 15.99 },
                { "Sabão em pó", 8.35 },
                { "Shampoo Clear", 24.49 }
            };
            List<string> recibo = new List<string>();
            List<double> total = new List<double>();

            Console.Write("Escreva seu nome: ");
            string nome = Console.ReadLine().Trim().Insert(0, "Sr(a) ");
            int inicio = 1;
            while (inicio == 1)
            {
                Console.Clear();
                Console.WriteLine($"Bem-vindo ao Mercado Dois Irmãos, {nome}.\n\nEscolha o que você deseja:\n1- Lista de produtos\n2- Adicionar ao carrinho\n3- Ver carrinho\n4- Finalizar compra\n5- Sobre o mercado");
                int menu = verify(Console.ReadLine());
                Console.WriteLine("");
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Nome Produto - Preço");
                        foreach (var item in produtos)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value:C}");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        string continuar = "s";
                        while (continuar == "s")
                        {
                            Console.Write("Escolha o nome do produto: ");
                            string produto = Console.ReadLine().Trim();
                            if (produtos.ContainsKey(produto))
                            {
                                double preco = produtos[produto];
                                Console.Write("Escolha a quantidade de produtos: ");
                                int q = verify(Console.ReadLine());
                                if (q > 0)
                                {
                                    Console.WriteLine($"Você selecionou {q} {produto}. Deseja confirmar? (s/n)");
                                    string c = Console.ReadLine().ToLower().Trim().Substring(0, 1);
                                    if (c == "s")
                                    {
                                        total.Add(preco * q);
                                        recibo.Add($"{q}X - {produto} - {preco:C} = {(preco * q):C}");

                                        Console.WriteLine("Deseja adicionar outro produto? (s/n)");
                                        continuar = Console.ReadLine().ToLower().Trim().Substring(0, 1);
                                    }
                                    else if (c == "n")
                                    {
                                        continuar = "n";
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção inválida. Tente novamente.\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Valor Inválido. Tente novamente.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado. Tente novamente.\n");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Carrinho de Compras\n");
                        if (recibo.Count > 0)
                        {
                            foreach (var item in recibo)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Deseja remover algum produto do carrinho? (s/n)");
                            string remover = Console.ReadLine().ToLower().Trim().Substring(0, 1);
                            switch (remover)
                            {
                                case "s":
                                    Console.Write("Digite a posição do produto no carrinho: ");
                                    int posicao = verify(Console.ReadLine()) - 1;
                                    if (posicao > 0 && posicao < recibo.Count)
                                    {
                                        recibo.RemoveAt(posicao);
                                        total.RemoveAt(posicao);
                                        Console.WriteLine("Produto removido do carrinho.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Posição inválida");
                                    }
                                    break;
                                case "n":
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida. Tente novamente.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Seu carrinho de compras está vazio.");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        if (recibo.Count > 0)
                        {
                            double valorTotal = 0;
                            foreach (var item in total)
                            {
                                valorTotal += item;
                            }
                            Console.WriteLine("Mercado Dois Irmãos\nPraça 15 de Abril, 47\nPlataforma, Salvador - BA\nCEP: 40717-634\nCNPJ: 18.732.377/0001-09\n\n===== NOTA FISCAL =====\nQuant. - Produto - Valor Uni. - Valor Item\n");
                            foreach (var item in recibo)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine($"\nPreço Final: {valorTotal:C}\nAgradecemos a preferência, {nome}.");
                            Console.ReadKey();
                            inicio = 0;
                        }
                        else
                        {
                            Console.WriteLine("Você não selecionou nenhum produto para comprar.\nPressione qualquer tecla para continuar...\n");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Mercado Dois Irmãos\nPraça 15 de Abril, 47 - Plataforma, Salvador - BA\nCEP: 40717-634\nCNPJ: 18.732.377/0001-09\nNúmero: 71 92338-4456\nEmail: mercadodoisirmaos@gmail.com\nInstagram: \nFacebook: \nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static int verify(string d)
        {
            int n;
            if (int.TryParse(d, out n))
            {
                return n;
            }
            return -1;
        }
    }
}
