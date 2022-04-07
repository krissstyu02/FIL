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

//количество минимальных элементов в этом интервале
let resh list a b= List.fold (fun s x -> if (x=List.min list && x>a && x<b) then s+1 else s) 0 list

[<EntryPoint>]
let main argv =
    let list=readData 
    Console.WriteLine("Введите значение начала и конца интервала")
    let a=System.Convert.ToInt32(System.Console.ReadLine())
    let b=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Количество минимальных элементов в этом интервале={0} ",resh list a b)
    0
