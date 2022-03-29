// Learn more about F# at http://fsharp.org

// Learn more about F# at http://fsharp.org

open System
let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail  

//Дополнение списка
let Input lint = 
    if List.length lint % 3=0 then lint
    else 
        if List.length lint % 3=1 then lint @ [1] @ [1]
        else lint @ [1]
//функция создания нового списка
let Sum f lint =
    let rec Sum2 lint f newList = 
        match lint with
        |[]->newList
        |h::tail->
            let h2 = tail.Head
            let h3 = tail.Tail.Head 
            let resSum = f h h2 h3
            let NextList = newList @ [resSum]
            Sum2 tail.Tail.Tail f NextList
    Sum2 lint f []

[<EntryPoint>]
let main argv =
    let l = readData
    Console.WriteLine("Новый список: ")
    Input l|> Sum (fun x y z-> x+y+z) |> writeList
     // return an integer exit code
