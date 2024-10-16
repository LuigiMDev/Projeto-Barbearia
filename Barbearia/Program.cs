﻿using Barbearia;
using System.Data;
using System.Xml;
using System.Drawing;
using Console = Colorful.Console;
using System.Threading;
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

    public static void Say(string indice, string mensagem)
    {
        Console.Write("[");
        Console.Write(indice, Color.BlueViolet);
        Console.Write("]");
        Console.WriteLine(mensagem);
    }

    public static void AgendarCorte()
    {
        Console.Clear();
        string nomeCliente;
        while (true)
        {
            Console.WriteLine("Digite o nome do cliente:");
            nomeCliente = Console.ReadLine();
            if(nomeCliente.Length <= 0 )
            {
                Console.WriteLine("ERRO: Digite um nome!", Color.Red);
            }
            else
            {
                break;
            }
        }
        string cpfCliente;
        while (true)
        {
            Console.WriteLine("Digite o CPF do cliente:");
            cpfCliente = Console.ReadLine();
            if(cpfCliente.Length != 11)
            {
                Console.WriteLine("ERRO: Digite um CPF válido!", Color.Red);
            }
            else
            {
                break;
            }
        }
        string telCliente;
        while (true)
        {
            Console.WriteLine("Digite o telefone do cliente (9 dígitos):");
            telCliente = Console.ReadLine();
            if(telCliente.Length != 9)
            {
                Console.WriteLine("ERRO: Digite um número válido!", Color.Red);
            }
            else
            {
                break;
            }

        }
        Cliente cliente = new Cliente { Nome = nomeCliente, Cpf = cpfCliente, Telefone = telCliente };

        string idBarbeiro;
        while (true)
        {
            try
            {
                Console.WriteLine("Qual Barbeiro o cliente deseja ser atendido?");
                foreach (var barbeiro in barbeiros)
                {
                    Say(barbeiro.Id, barbeiro.Nome);
                }
                Say($"{barbeiros.Count}", "Para voltar para a tela inicial");

                idBarbeiro = Console.ReadLine();
                if (int.Parse(idBarbeiro) == barbeiros.Count)
                {
                    TelaInicial();
                    return;
                }
                else if (int.Parse(idBarbeiro) > barbeiros.Count)
                {
                    Console.WriteLine("ERRO: Barbeiro não encontrado!", Color.Red);
                }
                else
                {
                    break;
                }
            }
            catch
            {
                Console.WriteLine("ERRO: Digite um número válido!", Color.Red);
            }
        }

        Barbeiro barbeiroEscolhido = barbeiros.Find(b => b.Id == idBarbeiro);

        Cabelo cabeloEscolhido = null;
        Barba barbaEscolhida = null;
        List<Outros> outroEscolhido = new List<Outros>();

        string cortarCabelo;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Gostaria de fazer um corte de cabelo? (sim ou não)");
            cortarCabelo = Console.ReadLine();

            if (cortarCabelo.ToLower() == "sim" || cortarCabelo.ToLower() == "s")
            {
                List<Cabelo> listaAuxiliarCabelo = new List<Cabelo>(cortesCabelo);
                listaAuxiliarCabelo.RemoveAt(0);
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Escolha o tipo de corte de cabelo:");
                        foreach (var cabelo in listaAuxiliarCabelo)
                        {
                            Say($"{listaAuxiliarCabelo.IndexOf(cabelo)}", $"{cabelo.Nome} - R${cabelo.Preco}");
                        }
                        Say($"{listaAuxiliarCabelo.Count}", "Para voltar para a tela inicial");
                        int rCortesCabelo = int.Parse(Console.ReadLine());
                        if (rCortesCabelo == listaAuxiliarCabelo.Count)
                        {
                            TelaInicial();
                            return;
                        }
                        cabeloEscolhido = listaAuxiliarCabelo[rCortesCabelo];
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("ERRO: Digite um número válido!", Color.Red);
                    }
                }
                break;
            }
            else if (cortarCabelo.ToLower() == "não" || cortarCabelo.ToLower() == "n")
            {
                cabeloEscolhido = cortesCabelo[0];
                break;
            }
            else
            {
                Console.WriteLine("ERRO: Digite 'Sim' ou 'Não'", Color.Red);
            }
        }

        string cortarBarba;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Gostaria de fazer a barba? (sim ou não)");
            cortarBarba = Console.ReadLine();

            if (cortarBarba.ToLower() == "sim" || cortarBarba.ToLower() == "s")
            {
                List<Barba> listaAuxiliarBarba = new List<Barba>(cortesBarba);
                listaAuxiliarBarba.RemoveAt(0);
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Escolha o tipo de barba:");
                        foreach (var barba in listaAuxiliarBarba)
                        {
                            Say($"{listaAuxiliarBarba.IndexOf(barba)}", $"{barba.Nome} - R${barba.Preco}");
                        }
                        Say($"{listaAuxiliarBarba.Count}", "Para voltar para a tela inicial");
                        int rCortesBarba = int.Parse(Console.ReadLine());
                        if (rCortesBarba == listaAuxiliarBarba.Count)
                        {
                            TelaInicial();
                            return;
                        }
                        barbaEscolhida = listaAuxiliarBarba[rCortesBarba];
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("ERRO: Digite um valor válido!", Color.Red);
                    }
                }
                break;
            }
            else if (cortarBarba.ToLower() == "não" || cortarBarba.ToLower() == "n")
            {
                barbaEscolhida = cortesBarba[0];
                break;
            }
            else
            {
                Console.WriteLine("ERRO: Digite 'Sim' ou 'Não'", Color.Red);
            }
        }

        string pedidoAdicional;
        while(true)
        {
            Console.WriteLine();
            Console.WriteLine("Gostaria de fazer um pedido adicional? (sim ou não)");
            pedidoAdicional = Console.ReadLine();

            if (pedidoAdicional.ToLower() == "sim" || pedidoAdicional.ToLower() == "s")
            {
               Console.WriteLine("Escolha um pedido adicional:");
               List<Outros> listaAuxiliarOutros = new List<Outros>(outrosTipos);
                listaAuxiliarOutros.RemoveAt(0);
               for (int i = 0; i < 3; i++)
               {
                    int resposta;
                    while (true)
                    {
                        try
                        {
                            foreach (var outro in listaAuxiliarOutros)
                            {
                                Say($"{listaAuxiliarOutros.IndexOf(outro)}", $"{outro.Nome} - R${outro.Preco}");
                            }
                            Say($"{listaAuxiliarOutros.Count}", "Para voltar para a tela inicial");
                            resposta = int.Parse(Console.ReadLine());

                            if (resposta == listaAuxiliarOutros.Count)
                            {
                                TelaInicial();
                                return;
                            }

                            Console.WriteLine($"{listaAuxiliarOutros[resposta].Nome} Escolhido");
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("ERRO: Digite um valor válido!", Color.Red);
                        }
                    }
                    Console.WriteLine();

                    outroEscolhido.Add(listaAuxiliarOutros[resposta]);
                    listaAuxiliarOutros.RemoveAt(resposta);

                    if (listaAuxiliarOutros.Count >= 1)
                    {
                        while (true)
                        {
                            Console.WriteLine("Deseja escolher outro?");
                            string resposta2 = Console.ReadLine();
                            if (resposta2.ToLower() == "sim" || resposta2.ToLower() == "s")
                            {
                                break;
                            }
                            else if (resposta2.ToLower() == "não" || resposta2.ToLower() == "n")
                            {
                                i = 3;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ERRO: Digite 'Sim' ou 'Não'", Color.Red);
                            }
                        }
                    }
               }
               break;
            }
            else if (pedidoAdicional.ToLower() == "não" || pedidoAdicional.ToLower() == "n")
            {
                outroEscolhido.Add(outrosTipos[0]);
                break;
            }
            else
            {
                Console.WriteLine("ERRO: Digite 'Sim' ou 'Não'", Color.Red);
            }
        }

        DateTime dataHora;
        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Escolha a data e a hora do agendamento no formato: dd/MM/yyyy HH:mm");
                dataHora = DateTime.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("ERRO: Digite uma data válida", Color.Red);
            }
        }
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

        Console.WriteLine($"O agendamento foi realizado com sucesso! Preço total: R${agendamento.PrecoTotal}", Color.Green);
        Console.WriteLine("Digite qualquer tecla para voltar para a tela incial");
        Console.ReadKey();
        TelaInicial();
    }

    public static void VerAgenda()
    {
        Console.Clear();
        List<string> linhas = new List<string>();
        Directory.CreateDirectory("Pasta de Registros");
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

        Directory.CreateDirectory("Pasta de Registros");
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
            Console.WriteLine("Cliente não foi localizado.", Color.Red);
            Console.WriteLine("Pressione qualquer tecla para voltar a tela inicial!");
            Console.ReadKey();
            TelaInicial();
            return;
        }

        int escolha;
        while (true)
        {
            try
            {
                Console.WriteLine("O que você gostaria de alterar?");
                Say("1", "Nome");
                Say("2", "CPF");
                Say("3", "Telefone");
                Say("4", "Data e Hora");
                Say("5", "Corte de Cabelo");
                Say("6", "Barba");
                Say("7", "Pedido Adicional");
                Say("8", "Barbeiro");

                escolha = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Digite um valor válido!", Color.Red);
            }
        }

  
        switch (escolha)
        {
            case 1:
                string novoNome;
                while (true)
                {
                    Console.WriteLine("Digite o novo nome:");
                    novoNome = Console.ReadLine();
                    if (novoNome.Length <= 0)
                    {
                        Console.WriteLine("ERRO: Digite um nome!", Color.Red);
                    }
                    else
                    {
                        break;
                    }
                }
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
                string novoCPF;
                while (true)
                {
                    Console.WriteLine("Digite o novo CPF");
                    novoCPF = Console.ReadLine();
                    if (novoCPF.Length != 11)
                    {
                        Console.WriteLine("ERRO: Digite um CPF válido!", Color.Red);
                    }
                    else
                    {
                        break;
                    }
                }
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
                string novoTelefone;
                while (true)
                {
                    Console.WriteLine("Digite o novo telefone (9 dígitos):");
                    novoTelefone = Console.ReadLine();
                    if(novoTelefone.Length != 9)
                    {
                        Console.WriteLine("ERRO: Digite um número de telefone válido!", Color.Red);
                    }
                    else
                    {
                        break;
                    }
                }
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
                while (true)
                {
                    try
                    {
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
                    }
                    catch
                    {
                        Console.WriteLine("ERRO: Digite uma data válida!", Color.Red);
                    }
                }
                break;
            case 5:
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Escolha o novo corte de cabelo:");
                        foreach (var cabelo in cortesCabelo)
                        {
                            Say($"{cortesCabelo.IndexOf(cabelo)}", $"{cabelo.Nome} - R${cabelo.Preco}");
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
                    }
                    catch
                    {
                        Console.WriteLine("ERRO: Digite um número válido", Color.Red);
                    }
                }
                break;
            case 6:
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Escolha o novo corte de barba:");
                        foreach (var barba in cortesBarba)
                        {
                            Say($"{cortesBarba.IndexOf(barba)}", $"{barba.Nome} - R${barba.Preco}");
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
                    }
                    catch
                    {
                        Console.WriteLine("ERRO: Digite um valor válido!", Color.Red);
                    }
                }
                break;
            case 7:
                Console.WriteLine("Escolha o novo pedido adicional:");
                List<Outros> listaAuxiliar = new List<Outros>(outrosTipos);
                List<Outros> listaTemp = new List<Outros>();
                for (int i = 0; i < 3; i++)
                {
                    int resposta;
                    while (true)
                    {
                        try
                        {
                            foreach (var outro in listaAuxiliar)
                            {
                                Say($"{listaAuxiliar.IndexOf(outro)}", $"{outro.Nome} - R${outro.Preco}");
                            }
                            resposta = int.Parse(Console.ReadLine());

                            listaTemp.Add(listaAuxiliar[resposta]);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("ERRO: Digite um valor válido!", Color.Red);
                        }
                    }
                    listaAuxiliar.RemoveAt(resposta);

                    if (listaTemp[0] != outrosTipos[0])
                    {
                        if (listaAuxiliar.Count != 0)
                        {
                            if (listaAuxiliar[0] == outrosTipos[0])
                            {
                                listaAuxiliar.RemoveAt(0);
                            }
                        }
                        if (listaAuxiliar.Count >= 1)
                        {
                            while (true)
                            {
                                Console.WriteLine("Deseja escolher outro?");
                                string resposta2 = Console.ReadLine();
                                if (resposta2.ToLower() == "sim" || resposta2.ToLower() == "s")
                                {
                                    break;
                                }
                                else if (resposta2.ToLower() == "n" || resposta2.ToLower() == "não")
                                {
                                    i = 3;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("ERRO: Digite 'Sim' ou 'Não'", Color.Red);
                                }
                            }
                        }
                    }
                    else
                    {
                        i = 3;
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
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Escolha o novo barbeiro:");
                        foreach (var barbeiro in barbeiros)
                        {
                            Say($"{barbeiro.Id}", $"{barbeiro.Nome}");
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
                    }
                    catch
                    {
                        Console.WriteLine("ERRO: Digite um valor válido!", Color.Red);
                    }
                }
                break;
            default:
                Console.WriteLine("Escolha inválida!", Color.Red);
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

        Console.WriteLine("Alteração feita com sucesso!", Color.Green);
        Console.WriteLine("Pressione qualquer tecla para voltar a tela inicial!");
        Console.ReadKey();
        TelaInicial();
    }

    public static void ExcluirAgendamento()
    {
        Console.Clear();
        int idAgendamento;
        while (true)
        {
            try
            {
                Console.WriteLine("Qual o ID do agendamento que deseja excluir?");
                idAgendamento = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("ERRO: Digite um ID válido", Color.Red);
            }
        }
        List<string> linhas = new List<string>();
        using (StreamReader reader = new StreamReader("Pasta de Registros\\registrosBarbearia.txt"))
        {
            string linha;
            while ((linha = reader.ReadLine()) != null)
            {
                linhas.Add(linha);
            }
        }
        string arquivoTemp = Path.GetTempFileName();
        bool idEncontrado = false;
        foreach (var linha in linhas)
        {
            string[] partesLinhas = linha.Split(';');
            using (StreamWriter writerTemp = new StreamWriter(arquivoTemp, true))
            {
                if(idAgendamento != int.Parse(partesLinhas[0]))
                {
                    writerTemp.WriteLine(linha);
                }
                else
                {
                    idEncontrado = true;
                }
            }
        }
        File.Delete("Pasta de Registros\\registrosBarbearia.txt");
        File.Move(arquivoTemp, "Pasta de Registros\\registrosBarbearia.txt");
        if (idEncontrado)
        {
            Console.WriteLine("Exclusão feita com sucesso!", Color.Green);
            Console.WriteLine("Pressione qualquer tecla para voltar a tela inicial!");
            Console.ReadKey();
            TelaInicial();
        }
        else
        {
            Console.WriteLine("Registro não Encontrado", Color.Red);
            Console.WriteLine("Pressione qualquer tecla para voltar a tela inicial!");
            Console.ReadKey();
            TelaInicial();
        }
    }


    public static void TelaInicial()
    {
        Console.Clear();
        Console.Title = "Barbearia Artorias";
        Console.WriteLine(@"
     _         _             _           
    / \   _ __| |_ ___  _ __(_) __ _ ___ 
   / _ \ | '__| __/ _ \| '__| |/ _` / __|
  / ___ \| |  | || (_) | |  | | (_| \__ \
 /_/   \_\_|   \__\___/|_|  |_|\__,_|___/
                                         
", Color.BlueViolet);
        Console.WriteLine("Bem-vindo à Barbearia do Artorias!");
        Console.WriteLine();
        Console.WriteLine("Sistema de Agendamento");
        Console.WriteLine();
        Console.WriteLine("Você gostaria de:");
        Console.WriteLine();
        Say("1", "Agendar um Corte");
        Say("2", "Ver a agenda");
        Say("3", "Alterar um agendamento");
        Say("4", "Excluir um Agendamento");

        int escolha;
        while (true)
        {
            try
            {
                escolha = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("ERRO: Digite um valor válido!", Color.Red);
            }
        }


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
            case 4:
                ExcluirAgendamento();
                break;
            default:
                Console.WriteLine("ERRO: Digite um valor válido!", Color.Red);
                Thread.Sleep(1500);
                TelaInicial();
                break;
        }
    }
    public static void Main()
    {
        TelaInicial();
    }
}