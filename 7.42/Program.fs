// Learn more about F# at http://fsharp.org

open System

let rec readlistdouble n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToDouble
    let Tail = readlistdouble (n-1)
    Head::Tail
let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readlistdouble n

//элементы, которые меньше среднего арифметического элементов массива.
let resh list = List.filter (fun x->x<List.average list) list
[<EntryPoint>]
let main argv =
    let list=readData
    Console.WriteLine("Элементы, которые меньше среднего арифметического элементов массива:")
    Console.WriteLine(resh list)
    0 