using SOAPTest;
Console.WriteLine("Program started. Enter a \"end\" keyword to end session");

while (true)
{
    Console.WriteLine("Введите Id продукта");

    var readedKey = Console.ReadLine().ToLower();

    if (readedKey == "end")
        break;

    Console.WriteLine();

    int.TryParse(readedKey, out int id);

    if (id > 0)
    {
        var product = SoapHelper.CallGetProductDetailsService(id);

        if (product != null)
            Console.WriteLine(product);
        else
            Console.WriteLine("Продукт с указанным Id не найден");
    }
    else
        Console.WriteLine("Введите валидный Id");
}

Console.WriteLine("Program Ended");
Console.ReadLine();


