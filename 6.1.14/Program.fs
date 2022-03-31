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

//найти количество элементов  в интервале.

let count list a b=
   let rec count2 list a b init=
    match list with
    |[]->init
    |h::t->
         if(h>a && h<b) then 
         count2 t a b init+1
         else 
         count2 t a b init
   count2 list a b 0


[<EntryPoint>]
let main argv =
    let l=readData
    Console.WriteLine("Введите значение начала и конца интервала")
    let a=System.Convert.ToInt32(System.Console.ReadLine())
    let b=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Количество элементов в интервале. :{0}", count l a b)

    
    0 // return an integer exit code
