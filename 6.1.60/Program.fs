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
                       
let rec frequency list elem count =  //сколько раз элемент встречается в списке
    match list with
    |[] -> count
    | h::t -> 
                    let count1 = count + 1
                    if h = elem then frequency t elem count1 
                    else frequency t elem count

let check list =
    let rec m1  list countlist newlist index =
        match list with
        | []-> newlist
        | h::t->
            if ((h% index=0) && ((frequency countlist h 0)=1)) then m1  t countlist (newlist @[h]) (index+1)
            else m1  t countlist  newlist (index+1)
    m1 list list [] 1

[<EntryPoint>]
let main argv =
    let list = readData 
    let newlist = check list
    Console.WriteLine("Получившийся список:")
    writeList  newlist
    0 // return an integer exit code
