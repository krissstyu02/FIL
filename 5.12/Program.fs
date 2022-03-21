// Learn more about F# at http://fsharp.org

open System

let Otvet (k:string) =    
   match k with 
   |"F#"|"Prolog" -> "Поздравляю, Вы - подлиза!"
   | _ -> "Как можно не любить F#!? "
[<EntryPoint>]
let main argv =
   System.Console.WriteLine("Какой ваш любимый язык программирования?")
   //Случай суперпозиции
   (Console.ReadLine>>Otvet>>Console.WriteLine)()
   System.Console.WriteLine("Какой ваш любимый язык программирования?")
  // Случай каррирования
   let F y x z =z(x(y()))
   F Console.ReadLine Otvet Console.WriteLine
   0 
