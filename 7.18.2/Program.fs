// Learn more about F# at http://fsharp.org

open System

(*Дан массив А [1; 2; 3;] и массив B [4; 5; 7] скопировать
последний элемент массива В в массив А.*)
[<EntryPoint>]
let main argv =
    let arrayA=[|1;2;3|]
    let arrayB=[|4;5;7|]
    let new_array=Array.append arrayA [|(Array.item(arrayB.Length-1) arrayB)|] 
    Console.WriteLine("arrayA=[|1;2;3|] arrayB=[|4;5;7|]
Новый массив=")
    printfn"%A"new_array

    0 // return an integer exit code



