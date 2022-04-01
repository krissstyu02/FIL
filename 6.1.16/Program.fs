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

//найти элементы,расположенные между первым и вторым максимальным

//первый максимум
let Indmax list = 
    let rec Indmax2 list max indM indEL=
        match list with
        |[]->(indM,max)
        |h::t -> 
            let newMax = if h>=max then h else max
            let newInd = if h>=max then indEL else indM
            Indmax2 t newMax newInd (indEL+1)
    Indmax2 list list.Head 0 0 

//второй максимум
let Indmax2 list max=
    let rec newIndmax2 list max max2 indM2 indEl =
        match list with
        | [] -> (indM2, max2)
        | h::t ->
            let new_max = if (h > max2 && h<>max) then h else max2
            let new_max_idx = if (h > max2 && h<>max) then indEl else indM2
            newIndmax2 t max new_max new_max_idx (indEl+1)
    newIndmax2 list max list.Head 0 0 

[<EntryPoint>]
let main argv =
    let list=readData 
    let maxel=snd (Indmax list)
    let max1ind=fst (Indmax list)
    let max2el=snd (Indmax2 list maxel)
    let max2ind=fst (Indmax2 list maxel)
    Console.WriteLine("Первый максимум:{0} ",maxel)
    Console.WriteLine("Второй максимум:{0} ",max2el)
    let start=Math.Min(max1ind,max2ind)
    let finish=Math.Max(max1ind,max2ind)
    Console.WriteLine("Получившийся список из элементов, расположенных между первым и вторым максимальным.: ")
    let otvet=list.[start+1..finish-1]      //выбираем элементы
    writeList(otvet)
    0 // return an integer exit code