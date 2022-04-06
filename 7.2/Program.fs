// Learn more about F# at http://fsharp.org

open System
let rec readList n =
    List.init(n) (fun index->Console.ReadLine()|>Int32.Parse)

let readData() = 
   Console.WriteLine("Введите размерность списка:  ")
   let n=System.Convert.ToInt32(System.Console.ReadLine())
   Console.WriteLine("Введите список: ") 
   readList n

let rec writelist list=
    List.iter(fun x->printfn "%O" x) list

//найти индекс минимального элемента.
let min list=List.findIndex(fun x->x=List.min list) list

[<EntryPoint>]
let main argv =
    Console.WriteLine("Индекс минимального элемента")
    readData() |> min |>Console.WriteLine;
    

    0 // return an integer exit code
