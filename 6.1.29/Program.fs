// Learn more about F# at http://fsharp.org

open System

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

//проверить наличие максимального элемента массива в этом интервале.

// максимум
let Indmax list = 
    let rec Indmax2 list max indM indEL=
        match list with
        |[]->(max)
        |h::t -> 
            let newMax = if h>=max then h else max
            let newInd = if h>=max then indEL else indM
            Indmax2 t newMax newInd (indEL+1)
    Indmax2 list list.Head 0 0 



[<EntryPoint>]
let main argv =
    let list=readData 
    Console.WriteLine("Введите значение начала и конца интервала")
    let a=System.Convert.ToInt32(System.Console.ReadLine())
    let b=System.Convert.ToInt32(System.Console.ReadLine())
    let max= Indmax list
    Console.WriteLine("Максимум={0} ",max)
    if(max>a && max<b) then Console.WriteLine("Принадлежит")
    else Console.WriteLine("Не принадлежит")
    0 // return an integer exit code