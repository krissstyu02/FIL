﻿// Learn more about F# at http://fsharp.org

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

(*Дан список, построить кортеж, содержащий пять списков, при этом
- первый список содержит результат деления на два только четных
элементов исходного,
- второй список содержит результат деления на три только тех элементов
первого, которые делятся на три,
- третий список содержит квадраты значений второго списка,
- четвертый список содержит только те элементы третьего, которые
встречаются в первом,
- пятый список содержит все элементы второго, третьего и четвертого
списков.*)
let result list=
    (List.map (fun x->x/2) (List.filter (fun x->x%2=0) list) , List.map (fun x->x/2/3) (List.filter (fun x->x%3=0&&x%2=0) list) ,
        List.map (fun x-> x*x )(List.map (fun x->x/2/3) (List.filter (fun x->x%3=0&&x%2=0) list)), 
            List.filter (fun x-> List.contains(x) (List.map (fun x->x/2) (List.filter (fun x->x%2=0) list))) (List.map (fun x-> x*x )(List.map (fun x->x/2/3) (List.filter (fun x->x%3=0&&x%2=0) list))),
                List.map (fun x->x/2/3) (List.filter (fun x->x%3=0&&x%2=0) list) @ List.map (fun x-> x*x )(List.map (fun x->x/2/3) (List.filter (fun x->x%3=0&&x%2=0) list)) @ List.filter (fun x-> List.contains(x) (List.map (fun x->x/2) (List.filter (fun x->x%2=0) list))) (List.map (fun x-> x*x )(List.map (fun x->x/3/2) (List.filter (fun x->x%3=0&&x%2=0) list))))
let kortezh lists id =
    match id, lists with
    | 1, (a,_,_,_,_) -> a
    | 2, (_,b,_,_,_) -> b
    | 3, (_,_,c,_,_) -> c
    | 4, (_,_,_,d,_) -> d
    | 5, (_,_,_,_,e) -> e
    | _, _ -> failwith (sprintf "Несуществующий индекс %i" id) 

let write lists= 
    let rec write2 lists id=
        if id<=5 then 
            Console.WriteLine("Список номер {0}:",id)
            writeList(kortezh lists id)
            write2 lists (id+1)
    write2 lists 1
[<EntryPoint>]
let main argv =
    let list= readData
    let l=result list
    write l
    0
