// Learn more about F# at http://fsharp.org

open System
let obhod x =
    let rec obh num del =
        if num <= 1 then []
        else 
            let new_del = del+1
            if num % del =0 then List.append[del] (obh (num/del) del)                        
            else obh num new_del  
    obh x 2 


//Для введенного числа построить список всех его простых делителей,причем если введенное число делится на простое число p в степени α , то витоговом списке число p должно повторятся α раз. 
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine(obhod x)
    0 // return an integer exit code
