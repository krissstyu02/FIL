// Learn more about F# at http://fsharp.org

open System

 
 //функция НОД
let rec nod a b =
    if a=b then a
    else 
        if a>b then nod (a-b) b 
        else nod a (b-a) 

let check1 x=x%2<>0  //nechet
let check2 x=x%2=0   //chet
  //взаимно-простые
let obh x func init c =
    let rec obh2 x func init del  =
        if del=0 then init
        else 
            let init2 = if (nod x del) =1 && c del then func init del else init
            let del2= del - 1
            obh2 x func init2 del2
    obh2 x func init x
    //делители
let obhdel x func init c =
    let rec obhdel2  x  func init del =
        if del=0 then init
        else 
            let init2 = if x%del=0 && c del then func init del else init
            let del2= del - 1
            obhdel2 x func init2 del2
    obhdel2 x func init x   
 
 
[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Произведение нечетных делителей числа:{0}", obhdel x  (fun x y -> x*y) 1 check1)
    System.Console.WriteLine("Сумма четных делителей числа:{0}", obhdel x  (fun x y -> x+y) 0 check2)
    System.Console.WriteLine("Произведение четных чисел, простых с данным:{0}",   obh x (fun x y -> x*y) 1 check2) 
    System.Console.WriteLine("Сумма нечетных чисел, простых с данным:{0}",   obh x (fun x y -> x+y) 0 check1) 
    0 
