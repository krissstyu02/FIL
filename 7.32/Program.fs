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

//Количество его локальных максимумов(локальный максимум-элемент, который больше любого из его соседних элементов
let resh (list:'int list)=List.fold (fun s x->if x then s+1 else s) 0 (List.map3 (fun x y z->(y>x)&&(y>z)) list.[0..list.Length-3] list.[1..list.Length-2] list.[2..list.Length-1]) 
[<EntryPoint>]
let main argv =
    let list=readData 
    Console.WriteLine("Количество его локальных максимумов={0}" ,resh list)
    0 // return an integer exit code
