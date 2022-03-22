// Learn more about F# at http://fsharp.org

open System
//Рекурсии вверх:
 
//Произведение цифр
let rec pr2 x =
    match x with
    |x when x<>1->(x%10)*(pr2(x/10))
    |x->1
 
 //max
let rec max2 x =
    match x with
    |x when x<10-> x
    |x->max (x % 10) (max2 (x/10))
 
   //min
let rec min2 x =
    match x with
    |x when x<10-> x
    |x->min (x % 10) (min2 (x/10))
 
 //Рекурсии вниз(хвостовые):
 
//Произведение цифр
let rec pr x a =
    match x with 
    | x when x=0 ->a
    | x->pr(x/10)a*(x%10)
 
//max
let rec max x a =
     match x with 
    |x when (x%10)>a->max(x/10)(x%10)
    |x when x=0 ->a
    |x->max(x/10)a
 
//min
let rec min x a =
     match x with 
    | x when (x<>0)&&((x%10)<a)->min(x/10)(x%10)
    |x when x=0 ->a
    | x->min(x/10)a
 
 
[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Рекцурсии вверх:")
    System.Console.WriteLine("Произведение:{0}", pr2 x)
    System.Console.WriteLine("Максимум:{0}", max2 x)
    System.Console.WriteLine("Минимум:{0}", min2 x)
    System.Console.WriteLine("Рекцурсии вниз(хвостовые):")
    System.Console.WriteLine("Произведение:{0}", pr x 1)
    System.Console.WriteLine("Максимум:{0}", max x 0)
    System.Console.WriteLine("Минимум:{0}", min x 9)
    0 
