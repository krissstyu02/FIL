// Learn more about F# at http://fsharp.org

open System

//нод
let rec nod a b =
    if a=b then a
    else 
        if a>b then nod (a-b) b 
        else nod a (b-a) 

//операции с  взаимно-простыми числами
let obh x func init =
    let rec obh2 x func init del =
        if del=0 then init
        else 
            let init2 = if (nod x del) =1 then func init del else init
            let del2= del - 1
            obh2 x func init2 del2
    obh2 x func init x

//количество
let inc x = 
    obh x (fun x y-> x + 1) 0

//кратный 3
let check1 x=x%3=0

//сумма цифр,удовлетворяющая условию
let sum3 x с = 
    let rec sum3 x sum = 
        if x = 0 then sum
        else
            if  с (x%10) then
                let sum1 = sum + x%10
                let x1 = x/10
                sum3 x1 sum1
            else 
                let x1 = x/10
                sum3 x1 sum
    sum3 x 0

//количество цифр данного числа взаимно-простых с делителем
let countnum x del = 
    let rec countnum2 x del count = 
        if x = 0 then count
        else 
            if nod (x%10) del = 1 then //взаимно-простые
                let x = x/10
                let count = count + 1
                countnum2 x del count
            else 
                let x = x/10
                countnum2 x del count
    countnum2 x del 0

//Нахождения делителя
let finddel x = 
    let rec findDel2 x del maxCount maxdel = 
        if del = 0 then maxdel
        else 
            if countnum x del > maxCount && x%del=0 then
                let maxCount = countnum x del    
                let maxCount1 = maxCount
                let maxdel = del
                findDel2 x (del-1) maxCount maxdel
            else 
                findDel2 x (del-1) maxCount maxdel
    findDel2 x x 0 0

let menu b c =
    match b with 
    | 1-> inc c
    | 2-> sum3 c check1
    | _-> finddel c    
    
[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите два числа: номер команды и аргумент
    1 Колличество взаимно-простых чисел с введенным
    2 Сумма цифр числа, делящихся на 3
    3 Делитель числа, являющийся взаимно простым с наибольшим количеством цифр введенного числа")
    let x = (Console.ReadLine() |> Int32.Parse, Console.ReadLine() |> Int32.Parse)
    let b = (fst x)
    let c = (snd x)    
    let result = menu b c
    System.Console.WriteLine("Полученный результат:{0}",result)
    0
