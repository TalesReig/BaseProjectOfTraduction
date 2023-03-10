using System;
using System.Threading;

namespace TesteTraducao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Idiomas idioma = new Idiomas(args[0]);
            Console.WriteLine(idioma.GetMensagem("Welcome"));
            Console.ReadKey();

            GerenciadorGenerico manager = new GerenciadorGenerico();

            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine(idioma.GetMensagem("Escolha uma opção:"));
                Console.WriteLine("1 - Adicionar objeto");
                Console.WriteLine("2 - Remover objeto");
                Console.WriteLine("3 - Listar objetos");
                Console.WriteLine("4 - Gerar PDF");
                Console.WriteLine("5 - Sair");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Digite o ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Digite o nome: ");
                            string name = Console.ReadLine();
                            manager.AddGenericClass(id, name);
                            Console.WriteLine("Objeto adicionado com sucesso!");
                            break;
                        case 2:
                            Console.Write("Digite o ID do objeto a ser removido: ");
                            int idToRemove = int.Parse(Console.ReadLine());
                            if (manager.RemoveGenericClass(idToRemove))
                            {
                                Console.WriteLine("Objeto removido com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Objeto não encontrado.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Lista de objetos:");
                            foreach (GenericClass obj in manager.AllInstances())
                            {
                                Console.WriteLine($"ID: {obj.id}, Nome: {obj.name}");
                            }
                            break;
                        case 4:
                            PdfGenerator pdf = new PdfGenerator();
                            Console.Write("Digite o nome do arquivo PDF a ser gerado: ");
                            string filename = Console.ReadLine();
                            pdf.GeneratePdf(manager.AllInstances(), filename);
                            Console.WriteLine($"PDF gerado com sucesso: {filename}");
                            break;
                        case 5:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }


                Console.WriteLine();
            }
        }
    }
}
