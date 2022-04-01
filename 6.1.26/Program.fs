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

//найти кол-во элементов,расположеннх между первым и вторым минимальным

//первый минимум
let Indmin list = 
    let rec Indmin2 list min indM indEL=
        match list with
        |[]->(indM,min)
        |h::t -> 
            let newMin = if h<min then h else min
            let newInd = if h<min then indEL else indM
            Indmin2 t newMin newInd (indEL+1)
    Indmin2 list list.Head 0 0 

//второй минимум
let Indmin2 list min=
    let rec newIndmin2 list min min2 indM2 indEl =
        match list with
        | [] -> (indM2, min2)
        | h::t ->
            let new_min = if (h < min2 && h<>min) then h else min2
            let new_min_idx = if (h < min2 && h<>min) then indEl else indM2
            newIndmin2 t min new_min new_min_idx (indEl+1)
    newIndmin2 list min list.Head 0 0 

[<EntryPoint>]
let main argv =
    let list=readData 
    let min1el=snd(Indmin list)
    let min1ind=fst (Indmin list)
    let min2el= snd(Indmin2 list min1el)
    let min2ind=fst (Indmin2 list min1el)
    Console.WriteLine("Первый минимум:{0} ",min1el)
    Console.WriteLine("Второй минимум:{0} ",min2el)
    let start=Math.Min(min1ind,min2ind)
    let finish=Math.Max(min1ind,min2ind)
    let otvet=finish-start-1 
    Console.WriteLine("Количество  элементов между первым и последним минимальным={0}", otvet )
    0 // return an integer exit code
