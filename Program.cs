using System;
using System.Collections.Generic;
using System.IO;

class DesafioLista {
    public static void Main(string[] args) {
        List<string> tarefas = new List<string>();
        string arquivoSalvo = "tarefas.txt";
        int opcao = 0;

        // Carrega as tarefas na inicialização
        if (File.Exists(arquivoSalvo)) {
            tarefas.AddRange(File.ReadAllLines(arquivoSalvo));
            Console.WriteLine("📄 Tarefas carregadas com sucesso!\n");
        }

        while (opcao != 4) {
            Console.WriteLine("===== GERENCIADOR DE TAREFAS =====");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1 - Adicionar Tarefa");
            Console.WriteLine("2 - Listar Tarefas");
            Console.WriteLine("3 - Remover Tarefa");
            Console.WriteLine("4 - Sair");
            Console.ResetColor();
            Console.Write("Escolha uma opção: ");

            string? entrada = Console.ReadLine(); // String não nula
            if (string.IsNullOrEmpty(entrada)) {
                Console.WriteLine("🚫 Entrada inválida! Tente novamente.\n");
                continue;
            }

            try {
                opcao = int.Parse(entrada);

                switch (opcao) {
                    case 1:
                        Console.Write("Digite a nova tarefa: ");
                        string? tarefa = Console.ReadLine();
                        if (!string.IsNullOrEmpty(tarefa)) {
                            tarefa = char.ToUpper(tarefa[0]) + tarefa.Substring(1);
                            tarefas.Add(tarefa);
                            Console.WriteLine("✅ Tarefa adicionada!");
                            SalvarTarefas(tarefas, arquivoSalvo);
                        } else {
                            Console.WriteLine("🚫 Tarefa inválida!\n");
                        }
                        break;

                    case 2:
                        if (tarefas.Count == 0) {
                            Console.WriteLine("⚠️ Nenhuma tarefa cadastrada.\n");
                        } else {
                            Console.WriteLine("\n📋 Lista de Tarefas:");
                            for (int i = 0; i < tarefas.Count; i++) {
                                Console.WriteLine($"{i + 1}. {tarefas[i]}");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case 3:
                        if (tarefas.Count == 0) {
                            Console.WriteLine("⚠️ Nenhuma tarefa para remover.\n");
                        } else {
                            Console.Write("Informe o número da tarefa para remover: ");
                            string? indexInput = Console.ReadLine();

                            if (!string.IsNullOrEmpty(indexInput) && int.TryParse(indexInput, out int index)) {
                                index--;
                                if (index >= 0 && index < tarefas.Count) {
                                    Console.WriteLine($"❌ Tarefa '{tarefas[index]}' removida!");
                                    tarefas.RemoveAt(index);
                                    SalvarTarefas(tarefas, arquivoSalvo);
                                } else {
                                    Console.WriteLine("🚫 Número inválido!\n");
                                }
                            } else {
                                Console.WriteLine("🚫 Entrada inválida! Digite apenas números.\n");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("🚪 Saindo... Até mais!");
                        break;

                    default:
                        Console.WriteLine("❌ Opção inválida! Tente novamente.\n");
                        break;
                }
            }
            catch (Exception) {
                Console.WriteLine("🚫 Entrada inválida! Digite apenas números.");
            }
        }
    }

    static void SalvarTarefas(List<string> lista, string caminho) {
        File.WriteAllLines(caminho, lista);
        Console.WriteLine("💾 Tarefas salvas com sucesso!");
    }
}
