// Learn more about F# at http://fsharp.org

open System
//Два целых числа a и b называются взаимно простыми, если их наибольший общий делитель равен единице
 
 //функция НОД
let rec nod a b =
    if a=b then a
    else 
        if a>b then nod (a-b) b 
        else nod a (b-a) 
 
let obh x func init =
    let rec obh2 x func init del =
        if del=0 then init
        else 
            let init2 = if (nod x del) =1 then func init del else init
            let del2= del - 1
            obh2 x func init2 del2
    obh2 x func init x
 
 
[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Сумма взаимно-простых делителей числа:{0}", obh x (fun x y -> x+y) 0)
    0 
