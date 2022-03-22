// Learn more about F# at http://fsharp.org

open System

let obh x func init=
    let rec obh2 x func init del=
        if del=0 then init else
        let init2= if x%del=0 then func init del else init
        let del2=del-1
        obh2 x func init2 del2 
    obh2 x func init x
[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число")
    let x=System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Сумма делителей числа:{0}", obh x (fun x y -> x+y ) 0)
    0 // return an integer exit codet code
