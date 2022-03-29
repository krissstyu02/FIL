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

// Найти кол-во элементов, расположенных после последнего максимального


//Индекс последнего максимального элемента
let Indmax lint = 
    let rec Indmax2 lint max indM indEL=
        match lint with
        |[]->indM
        |h::tail -> 
            let newMax = if h>=max then h else max
            let newInd = if h>=max then indEL else indM
            Indmax2 tail newMax newInd (indEL+1)
    Indmax2 lint lint.Head 0 0 

 //Ищем длину
let Lenght lint = 
    let rec Lenght2 lint count =
        match lint with 
        |[]->count
        |h::tail->
            let newCount = count+1
            Lenght2 tail newCount
    Lenght2 lint 0

//ищем колличество
let countNums lint = 
    let indexMax =Indmax lint 
    let result = Lenght lint - indexMax-1
    result


[<EntryPoint>]
let main argv =
    Console.WriteLine("Колличество элементов, расположенных после последнего максимального")
    readData|>countNums|>Console.WriteLine 
    //let list1 = [ 1; 2; 3;5;8;7;1 ]
    //list1|>countNums|>Console.WriteLine
    0 // return an integer exit code

