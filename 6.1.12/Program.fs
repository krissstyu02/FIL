// Learn more about F# at http://fsharp.org

open System

open System
let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail


let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail  

let Indmax list = 
    let rec Indmax2 lint max indM indEL=
        match lint with
        |[]->indM
        |h::t -> 
            let newMax = if h>=max then h else max
            let newInd = if h>=max then indEL else indM
            Indmax2 t newMax newInd (indEL+1)
    Indmax2 list list.Head 0 0 

let Indmin list = 
    let rec Indmin2 list min indM indEL=
        match list with
        |[]->indM
        |h::t -> 
            let newMin = if h<=min then h else min
            let newInd = if h<=min then indEL else indM
            Indmin2 t newMin newInd (indEL+1)
    Indmin2 list list.Head 0 0 


let find_min list =
    let rec find_min_r list current_min min_idx current_idx =
        match list with
        | [] -> (min_idx, current_min)
        | h::t ->
            let new_min = if h < current_min then h else current_min
            let new_min_idx = if h < current_min then current_idx else min_idx
            let new_idx = current_idx + 1
            find_min_r t new_min new_min_idx new_idx
    find_min_r list list.[0] 0 0
let turnl list=
    let rec turnl2 list new_list=
        match list with
        |[]->new_list
        |h::t->
            let newnew_list=[h] @ new_list
            turnl2 t newnew_list
    turnl2 list []
[<EntryPoint>]
let main argv =
   Console.WriteLine("Введите размерность списка:  ")
   let n=System.Convert.ToInt32(System.Console.ReadLine())
   Console.WriteLine("Введите список: ")
   let l = readList n
   let max=Indmax l
   let min= Indmin l
   let start=Math.Min(max,min)
   let finish=Math.Max(min,max)
   let piece=l.[start+1..finish-1]
   let otvet= l.[0..start]@ (turnl piece) @ l.[finish..n-1]
   Console.WriteLine("Новый список: ")
   writeList otvet
   0 // return an integer exit code
