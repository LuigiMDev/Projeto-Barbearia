﻿using Barbearia;
using System.Data;
using System.Xml;
class Program
{
    static List<Barbeiro> barbeiros = new List<Barbeiro>
        {
            new Barbeiro { Id = "0", Nome = "Qualquer um"},
            new Barbeiro { Id = "1", Nome = "Solaire"},
            new Barbeiro { Id = "2", Nome = "Siegmeyer"},
            new Barbeiro { Id = "3", Nome = "Patches"}
        };

    static List<Cabelo> cortesCabelo = new List<Cabelo>
        {
            new Cabelo { Nome = "Nenhum", Preco = 0},
            new Cabelo { Nome = "Americano", Preco = 30},
            new Cabelo { Nome = "Mid Fade", Preco = 30 },
            new Cabelo { Nome = "Low Fade", Preco = 30 }
        };

    static List<Barba> cortesBarba = new List<Barba>
        {
            new Barba { Nome = "Nenhum", Preco = 0},
            new Barba { Nome = "Lenhador", Preco = 40},
            new Barba { Nome = "Cavanhaque", Preco = 25 },
            new Barba { Nome = "Alinhamento", Preco = 20 }
        };

    static List<Outros> outrosTipos = new List<Outros>
        {
            new Outros { Nome = "Nenhum", Preco = 0},
            new Outros { Nome = "Sobrancelha", Preco = 10},
            new Outros { Nome = "Corte Navalhado", Preco = 10 },
            new Outros { Nome = "Tirar pelos do nariz e orelhas", Preco = 5 }
        };


    public static void AgendarCorte()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome do cliente:");
        string nomeCliente = Console.ReadLine();
        Console.WriteLine("Digite o CPF do cliente:");
        string cpfCliente = Console.ReadLine();
        Console.WriteLine("Digite o telefone do cliente:");
        string telCliente = Console.ReadLine();
        Cliente cliente = new Cliente { Nome = nomeCliente, Cpf = cpfCliente, Telefone = telCliente };

        Console.WriteLine("Qual Barbeiro o cliente deseja ser atendido?");
        foreach (var barbeiro in barbeiros)
        {
            Console.WriteLine($"{barbeiro.Id}) {barbeiro.Nome}");
        }
        Console.WriteLine($"{barbeiros.Count}) Para voltar para a tela inicial");

        string idBarbeiro = Console.ReadLine();
        if (int.Parse(idBarbeiro) == barbeiros.Count)
        {
            TelaInicial();
            return;
        }

        Barbeiro barbeiroEscolhido = barbeiros.Find(b => b.Id == idBarbeiro);

        Cabelo cabeloEscolhido = null;
        Barba barbaEscolhida = null;
        List<Outros> outroEscolhido = new List<Outros>();

        Console.WriteLine();
        Console.WriteLine("Gostaria de fazer um corte de cabelo? (sim ou não)");
        string cortarCabelo = Console.ReadLine();
        List<Cabelo> listaAuxiliarCabelo = new List<Cabelo>(cortesCabelo);
        listaAuxiliarCabelo.RemoveAt(0);

        if (cortarCabelo.ToLower() == "sim" || cortarCabelo.ToLower() == "s")
        {
            Console.WriteLine("Escolha o tipo de corte de cabelo:");
            foreach (var cabelo in listaAuxiliarCabelo)
            {
                Console.WriteLine($"{listaAuxiliarCabelo.IndexOf(cabelo)}) {cabelo.Nome} - R${cabelo.Preco}");
            }
            Console.WriteLine($"{listaAuxiliarCabelo.Count}) Para voltar para a tela inicial");
            int rCortesCabelo = int.Parse(Console.ReadLine());
            if (rCortesCabelo == listaAuxiliarCabelo.Count)
            {
                TelaInicial();
                return;
            }
            cabeloEscolhido = listaAuxiliarCabelo[rCortesCabelo];
        }
        else
        {
            cabeloEscolhido = new Cabelo();
            cabeloEscolhido.Nome = "Nenhum";
            cabeloEscolhido.Preco = 0;
        }

        Console.WriteLine();
        Console.WriteLine("Gostaria de fazer a barba? (sim ou não)");
        string cortarBarba = Console.ReadLine();
        List<Barba> listaAuxiliarBarba = new List<Barba>(cortesBarba);
        listaAuxiliarBarba.RemoveAt(0);

        if (cortarBarba.ToLower() == "sim" || cortarBarba.ToLower() == "s")
        {
            Console.WriteLine("Escolha o tipo de barba:");
            foreach (var barba in listaAuxiliarBarba)
            {
                Console.WriteLine($"{listaAuxiliarBarba.IndexOf(barba)}) {barba.Nome} - R${barba.Preco}");
            }
            Console.WriteLine($"{listaAuxiliarBarba.Count}) Para voltar para a tela inicial");
            int rCortesBarba = int.Parse(Console.ReadLine());
            if (rCortesBarba == listaAuxiliarBarba.Count)
            {
                TelaInicial();
                return;
            }
            barbaEscolhida = listaAuxiliarBarba[rCortesBarba];
        }
        else
        {
            barbaEscolhida = new Barba();
            barbaEscolhida.Nome = "Nenhuma";
            barbaEscolhida.Preco = 0;
        }

        Console.WriteLine();
        Console.WriteLine("Gostaria de fazer um pedido adicional? (sim ou não)");
        string pedidoAdicional = Console.ReadLine();

        if (pedidoAdicional.ToLower() == "sim" || pedidoAdicional.ToLower() == "s")
        {
           Console.WriteLine("Escolha um pedido adicional:");
           List<Outros> listaAuxiliarOutros = new List<Outros>();
            listaAuxiliarOutros = outrosTipos;
            listaAuxiliarOutros.RemoveAt(0);
           for (int i = 0; i < 3; i++)
            {
                foreach (var outro in listaAuxiliarOutros)
                {
                    Console.WriteLine($"{listaAuxiliarOutros.IndexOf(outro)}) {outro.Nome} - R${outro.Preco}");
                }
                Console.WriteLine($"{listaAuxiliarOutros.Count}) Para voltar para a tela inicial");
                int resposta = int.Parse(Console.ReadLine());

                if (resposta == listaAuxiliarOutros.Count)
                {
                    TelaInicial();
                    return;
                }

                Console.WriteLine($"{listaAuxiliarOutros[resposta].Nome} Escolhido");
                Console.WriteLine();

                outroEscolhido.Add(listaAuxiliarOutros[resposta]);
                listaAuxiliarOutros.RemoveAt(resposta);

                if (listaAuxiliarOutros.Count >= 1)
                {
                    Console.WriteLine("Deseja escolher outro?");
                    string resposta2 = Console.ReadLine();
                    if (resposta2 != "sim" && resposta2 != "s")
                    {
                        i = 3;
                    }
                }
           }
        }
        else
        {
            Outros outros = new Outros();
            outros.Nome = "Nenhum";
            outros.Preco = 0;
            outroEscolhido.Add(outros);
        }

        Console.WriteLine("Escolha a data e a hora do agendamento no formato: dd/MM/yyyy HH:mm");
        DateTime dataHora = DateTime.Parse(Console.ReadLine());
        int id = Agendamento.GerarID();

        Agendamento agendamento = new Agendamento
        {
            Cliente = cliente,
            Barbeiro = barbeiroEscolhido,
            DataHora = dataHora,
            Cabelo = cabeloEscolhido,
            Barba = barbaEscolhida,
            Outros = outroEscolhido,
            Id = id
        };
        cliente.Agendamentos.Add(agendamento);
        barbeiroEscolhido.Agenda.Add(agendamento);

        string outrosJuntos = "";
        foreach (var outrosSeparados in agendamento.Outros)
        {
            outrosJuntos += outrosSeparados.Nome + ",";
        }
        outrosJuntos = outrosJuntos.TrimEnd(',');
        Directory.CreateDirectory("Pasta de Registros");
        using (StreamWriter writer = new StreamWriter("Pasta de Registros\\registrosBarbearia.txt", true))
        {
            writer.WriteLine($"{agendamento.Id};{agendamento.Cliente.Nome};{agendamento.Cliente.Cpf};{agendamento.Cliente.Telefone};{agendamento.DataHora};{agendamento.Cabelo.Nome};{agendamento.Barba.Nome};{outrosJuntos};{agendamento.Barbeiro.Id};{agendamento.PrecoTotal}");
        }

        Console.WriteLine($"O agendamento foi realizado com sucesso! Preço total: R${agendamento.PrecoTotal}");
        Console.WriteLine("Digite qualquer tecla para voltar para a tela incial");
        Console.ReadKey();
        TelaInicial();
    }

    public static void VerAgenda()
    {
        Console.Clear();
        List<string> linhas = new List<string>();
        using (StreamWriter writer = new StreamWriter("Pasta de Registros\\registrosBarbearia.txt", true)) { }
        using (StreamReader reader = new StreamReader("Pasta de Registros\\registrosBarbearia.txt"))
        {
            string linha;
            while((linha = reader.ReadLine()) != null)
            {
                linhas.Add(linha);
            }
        }
        foreach (var barbeiroAgendamento in barbeiros)
        {
            Console.WriteLine($"Agenda do barbeiro {barbeiroAgendamento.Nome}:");
            Console.WriteLine();
            foreach (var linha in linhas)
            {
                string[] partesLinha = linha.Split(';');
                string idBarbeiro = (partesLinha[8]);
                if(barbeiroAgendamento.Id == idBarbeiro)
                {
                    Console.WriteLine($"ID Agendamento: {partesLinha[0]}, Cliente: {partesLinha[1]}, CPF: {partesLinha[2]}, Telefone: {partesLinha[3]}, Data/Hora: {partesLinha[4]}, Corte: {partesLinha[5]}, Barba: {partesLinha[6]}, Outros: {partesLinha[7]}, Preço: R${partesLinha[9]}");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("Pressione qualquer tecla para voltar a tela inicial!");
        Console.ReadKey();
        TelaInicial();
    }

    public static void AlterarAgendamento() 
    {
        Console.Clear();
        Console.WriteLine("Digite o ID do Agendamento:");
        string idAgendamento = Console.ReadLine();

        List<string> linhas = new List<string>();
        using (StreamReader reader = new StreamReader("Pasta de Registros\\registrosBarbearia.txt"))
        {
            string linha;
            while ((linha = reader.ReadLine()) != null)
            {
                linhas.Add(linha);
            }
        }
        Cliente cliente = null;
        Barbeiro barbeiroEscolhido = null;
        Agendamento agendamentoEscolhido = null;

        foreach (var linha in linhas)
        {
            string[] linhasPartes = linha.Split(";");
            if (linhasPartes[0] == idAgendamento)
            {
                cliente = new Cliente();
                cliente.Nome = linhasPartes[1];
                cliente.Cpf = linhasPartes[2];
                cliente.Telefone = linhasPartes[3];

                barbeiroEscolhido = new Barbeiro();
                barbeiroEscolhido.Id = linhasPartes[8];
                barbeiroEscolhido.Nome = (barbeiros.Find(b => b.Id == linhasPartes[8])).Nome;

                agendamentoEscolhido = new Agendamento();
                agendamentoEscolhido.Id = int.Parse(linhasPartes[0]);
                agendamentoEscolhido.Cliente = cliente;
                agendamentoEscolhido.Barbeiro = barbeiroEscolhido;
                agendamentoEscolhido.DataHora = DateTime.Parse(linhasPartes[4]);
                agendamentoEscolhido.Cabelo = cortesCabelo.Find(c => c.Nome == linhasPartes[5]);
                agendamentoEscolhido.Barba = cortesBarba.Find(c => c.Nome == linhasPartes[6]);
                string[] outrosAux = (linhasPartes[7].Split(","));
                foreach (string x in outrosAux)
                {
                    Outros teste = outrosTipos.Find(o => o.Nome == x);
                    agendamentoEscolhido.Outros.Add(teste);
                }
                agendamentoEscolhido.PrecoTotal = int.Parse(linhasPartes[9]);

            }
        }
        
        if (cliente == null)
        {
            Console.WriteLine("Cliente não foi localizado.");
            Console.WriteLine("Pressione qualquer tecla para voltar a tela inicial!");
            Console.ReadKey();
            TelaInicial();
            return;
        }

        Console.WriteLine("O que você gostaria de alterar?");
        Console.WriteLine(@"1) Nome 
2) CPF
3) Telefone
4) Data e Hora
5) Corte de Cabelo
6) Barba
7) Pedido Adicional
8) Barbeiro");

        int escolha = int.Parse(Console.ReadLine());

  
        switch (escolha)
        {
            case 1:
                Console.WriteLine("Digite o novo nome:");
                string novoNome = Console.ReadLine();
                string arquivoTemp = Path.GetTempFileName();
                using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
                    foreach(var linha in linhas)
                    {
                        string[] partesLinhas = (linha.Split(";"));
                        if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                        {
                            string linhaTemp = linha.Replace(partesLinhas[1], novoNome);
                            writerTemp.WriteLine(linhaTemp);
                        }
                        else
                        {
                            writerTemp.WriteLine(linha);
                        }
                    }
                File.Delete("Pasta de Registros\\registrosBarbearia.txt");
                File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");
                cliente.Nome = novoNome;
                break;
            case 2:
                Console.WriteLine("Digite o novo CPF");
                string novoCPF = Console.ReadLine();
                arquivoTemp = Path.GetTempFileName();
                using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
                {
                    foreach (var linha in linhas)
                    {
                        string[] partesLinhas = linha.Split(";");
                        if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                        {
                            string linhaTemp = linha.Replace(partesLinhas[2], novoCPF);
                            writerTemp.WriteLine(linhaTemp);
                        }
                        else
                        {
                            writerTemp.WriteLine(linha);
                        }
                    }
                }
                File.Delete("Pasta de Registros\\registrosBarbearia.txt");
                File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");
                break;
            case 3:
                Console.WriteLine("Digite o novo telefone:");
                string novoTelefone = Console.ReadLine();
                arquivoTemp = Path.GetTempFileName();
                using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
                {
                    foreach(var linha in linhas)
                    {
                        string[] partesLinhas = linha.Split(";");
                        if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                        {
                            string linhaTemp = linha.Replace(partesLinhas[3], novoTelefone);
                            writerTemp.WriteLine(linhaTemp);
                        }
                        else
                        {
                            writerTemp.WriteLine(linha);
                        }
                    }
                }
                File.Delete("Pasta de Registros\\registrosBarbearia.txt");
                File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");
                cliente.Telefone = novoTelefone;
                break;
            case 4:
                Console.WriteLine("Digite a nova data e hora no formato: dd/MM/yyyy HH:mm");
                string novaData = (Console.ReadLine());
                arquivoTemp = Path.GetTempFileName();
                using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
                {
                    foreach (var linha in linhas)
                    {
                        string[] partesLinhas = linha.Split(";");
                        if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                        {
                            string linhaTemp = linha.Replace(partesLinhas[4], novaData);
                            writerTemp.WriteLine(linhaTemp);
                        }
                        else
                        {
                            writerTemp.WriteLine(linha);
                        }
                    }
                }
                File.Delete("Pasta de Registros\\registrosBarbearia.txt");
                File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");
                agendamentoEscolhido.DataHora = DateTime.Parse(novaData);
                break;
            case 5:
                Console.WriteLine("Escolha o novo corte de cabelo:");
                foreach (var cabelo in cortesCabelo)
                {
                    Console.WriteLine($"{cortesCabelo.IndexOf(cabelo)}) {cabelo.Nome} - R${cabelo.Preco}");
                }
                int rCortesCabelo = int.Parse(Console.ReadLine());
                arquivoTemp = Path.GetTempFileName();
                using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
                {
                    foreach (var linha in linhas)
                    {
                        string[] partesLinhas = linha.Split(";");
                        if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                        {
                            string linhaTemp = linha.Replace(partesLinhas[5], (cortesCabelo[rCortesCabelo].Nome));
                            writerTemp.WriteLine(linhaTemp);
                        }
                        else
                        {
                            writerTemp.WriteLine(linha);
                        }
                    }
                }
                File.Delete("Pasta de Registros\\registrosBarbearia.txt");
                File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");
                agendamentoEscolhido.Cabelo = cortesCabelo[rCortesCabelo];
                break;
            case 6:
                Console.WriteLine("Escolha o novo corte de barba:");
                foreach (var barba in cortesBarba)
                {
                    Console.WriteLine($"{cortesBarba.IndexOf(barba)}) {barba.Nome} - R${barba.Preco}");
                }
                int rCortesBarba = int.Parse(Console.ReadLine());
                arquivoTemp = Path.GetTempFileName();
                using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
                {
                    foreach (var linha in linhas)
                    {
                        string[] partesLinhas = linha.Split(";");
                        if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                        {
                            string linhaTemp = linha.Replace(partesLinhas[6], (cortesBarba[rCortesBarba].Nome));
                            writerTemp.WriteLine(linhaTemp);
                        }
                        else
                        {
                            writerTemp.WriteLine(linha);
                        }
                    }
                }
                File.Delete("Pasta de Registros\\registrosBarbearia.txt");
                File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");
                agendamentoEscolhido.Barba = cortesBarba[rCortesBarba];
                break;
            case 7:
                Console.WriteLine("Escolha o novo pedido adicional:");
                List<Outros> listaAuxiliar = new List<Outros>(outrosTipos);
                List<Outros> listaTemp = new List<Outros>();
                for (int i = 0; i < 3; i++)
                {
                    foreach (var outro in listaAuxiliar)
                    {
                        Console.WriteLine($"{listaAuxiliar.IndexOf(outro)}) {outro.Nome} - R${outro.Preco}");
                    }
                    int resposta = int.Parse(Console.ReadLine());

                    listaTemp.Add(listaAuxiliar[resposta]);
                    listaAuxiliar.RemoveAt(resposta);

                    if (listaAuxiliar.Count >= 1)
                    {
                        Console.WriteLine("Deseja escolher outro?");
                        string resposta2 = Console.ReadLine();
                        if (resposta2 != "sim" && resposta2 != "s")
                        {
                            break;
                        }
                    }
                }
                string outrosJuntos = "";
                foreach (var outrosSeparados in listaTemp)
                {
                    outrosJuntos += outrosSeparados.Nome + ',';
                }
                outrosJuntos = outrosJuntos.TrimEnd(',');
                arquivoTemp = Path.GetTempFileName();
                using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
                {
                    foreach (var linha in linhas)
                    {
                        string[] partesLinhas = linha.Split(";");
                        if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                        {
                            string linhaTemp = linha.Replace(partesLinhas[7], outrosJuntos);
                            writerTemp.WriteLine(linhaTemp);
                        }
                        else
                        {
                            writerTemp.WriteLine(linha);
                        }
                    }
                }
                agendamentoEscolhido.Outros.Clear();
                foreach (var adicionarAgendamentos in listaTemp)
                {
                    agendamentoEscolhido.Outros.Add(adicionarAgendamentos);
                }
                File.Delete("Pasta de Registros\\registrosBarbearia.txt");
                File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");
                break;
            case 8:
                Console.WriteLine("Escolha o novo barbeiro:");
                foreach (var barbeiro in barbeiros)
                {
                    Console.WriteLine($"{barbeiro.Id}) {barbeiro.Nome}");
                }
                string idBarbeiro = Console.ReadLine();
                arquivoTemp = Path.GetTempFileName();
                using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
                {
                    foreach (var linha in linhas)
                    {
                        string[] partesLinhas = linha.Split(";");
                        if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                        {
                            string linhaTemp = linha.Replace(partesLinhas[8], idBarbeiro);
                            writerTemp.WriteLine(linhaTemp);
                        }
                        else
                        {
                            writerTemp.WriteLine(linha);
                        }
                    }
                }
                File.Delete("Pasta de Registros\\registrosBarbearia.txt");
                File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");

                barbeiroEscolhido.Agenda.Remove(agendamentoEscolhido);
                barbeiroEscolhido = barbeiros.Find(b => b.Id == idBarbeiro);
                agendamentoEscolhido.Barbeiro = barbeiroEscolhido;
                barbeiroEscolhido.Agenda.Add(agendamentoEscolhido);
                break;
            default:
                Console.WriteLine("Escolha inválida.");
                Console.WriteLine("Pressione qualquer tecla para voltar a tela inicial!");
                Console.ReadKey();
                TelaInicial();
                break;
        }
        linhas.Clear();
        using (StreamReader reader = new StreamReader("Pasta de Registros\\registrosBarbearia.txt"))
        {
            string linha;
            while ((linha = reader.ReadLine()) != null)
            {
                linhas.Add(linha);
            }
        }
        string arquivoTempPreco = Path.GetTempFileName();
        using (StreamWriter writerTemp = new StreamWriter(arquivoTempPreco, true))
        {
            foreach (var linha in linhas)
            {
                string[] partesLinhas = linha.Split(";");
                if (agendamentoEscolhido.Id == int.Parse(partesLinhas[0]))
                {
                    string linhaTemp = linha.Replace(partesLinhas[9], ($"{agendamentoEscolhido.PrecoTotal}"));
                    writerTemp.WriteLine(linhaTemp);
                }
                else
                {
                    writerTemp.WriteLine(linha);
                }
            }
        }
        File.Delete("Pasta de Registros\\registrosBarbearia.txt");
        File.Move(arquivoTempPreco, "Pasta de Registros\\registrosBarbearia.txt");

        Console.WriteLine("Alteração feita com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar a tela inicial!");
        Console.ReadKey();
        TelaInicial();
    }

    public static void TelaInicial()
    {
        Console.Clear();
        Console.WriteLine("Bem-vindo à Barbearia do Artorias!");
        Console.WriteLine();
        Console.WriteLine("Sistema de Agendamento");
        Console.WriteLine(@"Você gostaria de: 
1) Agendar um corte 
2) Ver a agenda
3) Alterar um agendamento");

        int escolha = int.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 1:
                AgendarCorte();
                break;
            case 2:
                VerAgenda();
                break;
            case 3:
                AlterarAgendamento();
                break;
            default:
                Console.WriteLine("Escolha inválida.");
                break;
        }
    }
    public static void Main()
    {
        TelaInicial();
    }
}