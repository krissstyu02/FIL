(*С использованием класса MailboxProcessor реализуйте агента, 
который реагирует на внешние события и выполняет различные действия 
(например, выдает результаты в консоль)*)


open System

// Агент выводит лишь большие буквы сообщения
let printerAgent = MailboxProcessor.Start(fun inbox->
    // обработка сообщений
    let rec messageLoop() = async{
        // чтение сообщения
        let! msg = inbox.Receive()
        // печать сообщения
        Console.WriteLine("Строка после преобразования: " + String.filter (fun x -> Char.IsUpper x) msg)
        return! messageLoop()
        }
        // запуск обработки сообщений
    messageLoop()

    )

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите строку для преобразования")
    let k=System.Convert.ToString(System.Console.ReadLine())
    let arg1 = printerAgent.Post(k)
    Console.ReadKey()
    0 // return an integer exit code
