using System.ComponentModel;

Dictionary<int, string> produtosEstoque = new Dictionary<int, string>
{
    { 1, "Filtro de óleo" },
    { 2, "Kit Amortecedores" },
    { 3, "Velas de Ignição" },
    { 4, "Disco de Freio" }
};

void ExibirLogo()
{
    Console.WriteLine("===============================================");
    Console.WriteLine(@"▄▀▄ █░█ ▀█▀ ▄▀▄     █▀▀ ▄▀▀ ▀█▀ ▄▀▄ ▄▀█ █░█ █▀▀ 
█▀█ █░█ ░█░ █░█     █▀▀ ░▀▄ ░█░ █░█ █░█ █░█ █▀▀ 
▀░▀ ░▀░ ░▀░ ░▀░     ▀▀▀ ▀▀░ ░▀░ ░▀░ ░▀█ ░▀░ ▀▀▀");
    Console.WriteLine("===============================================");
}

void ExibirMenu()
{
    ExibirLogo();

    Console.WriteLine("\nBoas vindas!\n");
    Console.WriteLine("Digite 1 para adicionar um item ao estoque.");
    Console.WriteLine("Digite 2 para exibir os itens em estoque.");
    Console.WriteLine("Digite 3 para editar o nome de um item do estoque.");
    Console.WriteLine("Digite 4 para deletar um item do estoque.");
    Console.WriteLine("Digite 5 para sair.");

    Console.Write("\nSua opção: ");
    int opcao = int.Parse(Console.ReadLine()!);

    switch (opcao)
    {
        case 1:
            AdicionarItem();
            break;
        case 2:
            ExibirItens();
            break;
        case 3:
            EditarItem();
            break;
        case 4:
            ExcluirItem();
            break;
    }
}

void VoltarAoMenu()
{
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void ExibirTitulo(string subMenu)
{
    Console.Clear();
    Console.WriteLine($"|{subMenu}|\n");
}

void AdicionarItem()
{
    ExibirTitulo("Adicionar Item");

    Console.Write("Digite o id do item que deseja adicionar ao estoque: ");
    int idItem = int.Parse(Console.ReadLine()!);
    Console.Write("Digite o nome do item que deseja adicionar ao estoque: ");
    string nomeItem = Console.ReadLine()!;

    if (produtosEstoque.ContainsValue(nomeItem))
    {
        Console.Write($"\nO produto '{nomeItem}' já existe no estoque. Aperte qualquer tecla para voltar ao menu principal...");
        VoltarAoMenu();
    }
    else if (produtosEstoque.ContainsKey(idItem))
    {
        Console.Write($"\nO produto de id '{idItem}' já existe no estoque. Aperte qualquer tecla para voltar ao menu principal...");
        VoltarAoMenu();
    }

    produtosEstoque.Add(idItem, nomeItem);
    Console.Write("\nItem adicionado com sucesso! Aperte qualquer tecla para voltar ao menu principal...");
    VoltarAoMenu();
}

void ExibirItens()
{
    ExibirTitulo("Exibir Itens");

    foreach (var item in produtosEstoque)
    {
        Console.WriteLine($"Id: {item.Key} - Nome: {item.Value}");
    }

    Console.Write($"\nAperte qualquer tecla para voltar ao menu principal...");
    VoltarAoMenu();
}

void EditarItem()
{
    ExibirTitulo("Editar Item");

    Console.Write("Digite o id do item que deseja alterar: ");
    int idItem = int.Parse(Console.ReadLine()!);

    if (produtosEstoque.ContainsKey(idItem))
    {
        Console.Write($"Digite o novo nome para '{produtosEstoque[idItem]}': ");
        string novoNome = Console.ReadLine()!;

        produtosEstoque[idItem] = novoNome;

        Console.Write("\nItem alterado com sucesso! Aperte qualquer tecla para voltar ao menu principal...");
        VoltarAoMenu();
    }
    else
    {
        Console.Write($"\nO item de id '{idItem}' não existe. Aperte qualquer tecla para voltar ao menu principal...");
        VoltarAoMenu();
    }
}

void ExcluirItem()
{
    ExibirTitulo("Excluir Item");

    Console.Write("Digite o id do item que deseja excluir: ");
    int idItem = int.Parse(Console.ReadLine()!);

    if (produtosEstoque.ContainsKey(idItem))
    {
        Console.WriteLine($"\nTem certeza que deseja excluir o item '{produtosEstoque[idItem]}'?");
        Console.Write("Digite S para 'sim' ou N para 'não': ");
        string escolha = Console.ReadLine()!;

        switch (escolha)
        {
            case "S":
                produtosEstoque.Remove(idItem);
                Console.Write("\nItem excluído com sucesso! Aperte qualquer tecla para voltar ao menu principal...");
                VoltarAoMenu();
                break;
            case "N":
                Console.WriteLine("\nAção cancelada. Aperte qualquer tecla para voltar ao menu principal...");
                VoltarAoMenu();
                break;
        }

    }
    else
    {
        Console.Write($"\nO item de id '{idItem}' não existe. Aperte qualquer tecla para voltar ao menu principal...");
        VoltarAoMenu();
    }
}

ExibirMenu();