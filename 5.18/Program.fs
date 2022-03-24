open System
// а
let nod x y =
    let rec nod1 x y z newnod= 
        if x+1 = z || y+1 = z then newnod
        else 
            if x%z <> 0 || y%z <> 0 then nod1 x y (z+1) newnod
            else 
                let nod = z
                nod1 x y (z+1) nod
    nod1 x y 1 1

let obh x func init =
    let rec obh2 x func init del =
        if del=0 then init
        else 
            let init2 = if (nod x del) =1 then func init del else init
            let del2= del - 1
            obh2 x func init2 del2
    obh2 x func init x

let inc x = 
    obh x (fun x y-> x + 1) 0

[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Сумма взаимно-простых с x:{0}", inc x )
    0 
