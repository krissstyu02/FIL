// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print

(*Для произвольно выбранного типа данных (например, Maybe)
реализуйте функции функтора, аппликативного функтора, монады.
Проверьте для Вашей реализации справедливость соответствующих 
законов для функтора и аппликативного функтора (тех законов, которые 
можно проверить с использованием F#). Некоторые законы могут не 
выполняться. Это означает что данный тип не является в полной мере 
функтором, аппликативным функтором, монадой*)

open System
 //Тип данных Maybe определяет два связанных контекста

type Maybe<'a> =
    | Just of 'a
    | Nothing

//Функторы позволяют примерять функции к элементам внутри  контекста.
let functor f p =
    match p with
    | Just a -> Just (f a)
    | Nothing -> Nothing

(*Внесение вычисления (функции) в контекст называется «поднятием
(или подъемом) в контекст»
Закон 1.
Пусть id – функция, которая возвращает неизменным значение 
аргумента.
Тогда подъем этой функции в контекст не влияет на вычисление
Закон 2.
Для двух функций f и g композиция их подъемов эквивалентна 
подъему композиции.
*)

let functorCheck a =
    if ((functor (fun x -> x) a) = a  //1 свойство
    && (functor (fun x -> x*4) (functor (fun x -> x*2) a)) = (functor ((fun x -> x*2) >> (fun x -> x*4)) a))
        then "Функтор удовлетворяет законам"
        else "Функтор не удовлетворяет законам"

 (*Аппликативный функтор.В этом случае значение упаковано в контекст:
 Но в контекст также упакована и сама функция:*)

 //Функция take поднимает возвращает функцию
let take a =
    match a with
    Just (f:'a) -> f

//Функция return поднимает возвращает значение
let returnApply a =
    Just a

//Функция apply применяет поднятую функцию к поднятым аргументам
let applyFunctor p1 p2 =
    match p1, p2 with
    Just f, Just a -> Just (f a)
    | _ -> Nothing  

(*Закон 1.
Применение поднятой функции id к поднятому значению 
эквивалентно применению неподнятой функции id к неподнятому 
значению.
Закон 2
Если y=f(x), то подъем функции f и значения х и применение к ним 
функции apply приведет к такому же результату, что и подъем y
Законы 3 и 4-войство коммутативности и свойство ассоциативности невозможно доказать из-за свойств языка f#*)

let applyFunctorTest a b c d=
    if ( take (applyFunctor a b) = (take a) (take b) //1 закон
    && (applyFunctor (returnApply c) (returnApply d)) = returnApply (c d) // 2 закон
    )
        then "Аппликативный функтор удовлетворяет законам"
        else "Аппликативный функтор не удовлетворяет законам"

//Монада применяет к поднятому значению функцию от обычного  аргумента, которая возвращает поднятое значение.
let monada (f:'b->Maybe<'b>) (a:Maybe<'b>) =
    match a with
    Just r ->(f r)
    | _ -> Nothing

[<EntryPoint>]
let main argv =
    Console.WriteLine("Решение для контекста 5")
    let s = Just(5) //контекст
    Console.WriteLine(functorCheck s)
    let fs = Just(fun x -> x+3)
    let f = fun x -> x*2
    let n = 10
    Console.WriteLine( applyFunctorTest fs s f n)
    Console.WriteLine("Примеение монады:")
    Console.WriteLine( monada (fun x -> Just(x+3)) s)
    0