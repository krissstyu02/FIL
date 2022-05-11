open System
open FParsec

type Expr =
 | Num of float
 | Plus of Expr * Expr
 | Minus of Expr * Expr

(*А >>. B разбирает последовательность элементов A и B
после чего возвращает B. Нам гарантируется что A и B идут 
последовательно, но при этом результат А не важен.
Комбинатор А .>> B *)

let pstring_ws s = spaces >>. pstring s .>> spaces // получение знака или скобки
let float_ws = spaces >>. pfloat .>> spaces // получение числа

let parseExpression, implementation =
    createParserForwardedToRef<Expr, unit>()  // создание парсера, что строку преобразует в алгебраический тип
let parsePlus = 
    tuple2 (parseExpression .>> pstring_ws "+") parseExpression |>> Plus // Парсит строку с +
let parseMinus = 
    tuple2 (parseExpression .>> pstring_ws "-") parseExpression |>> Minus // Парсит строку с -
let parseOp = 
    between (pstring_ws "(") (pstring_ws ")") (attempt parsePlus <|> parseMinus) // Парсит строку, что является выражение
let parseNum = 
    float_ws |>> Num
    // Парсит строку, что является числом  
implementation := parseNum <|> parseOp// основные элементы, с которыми работает парсер

let rec EvalExpr(e:Expr):float =   // считает полученный алгебраический тип(Функция упрощения выражения)
    match e with
    | Num(num) -> num
    | Plus(a,b) ->
        let left =
            match a with
            | Num(num) -> num
            | _ -> EvalExpr(a)
        let right =
            match b with
            | Num(num) -> num
            | _ -> EvalExpr(b)
        let res1 = left + right
        printfn "%f + %f = %f" left right res1
        res1
    | Minus(a,b) ->
        let left =
            match a with
            | Num(num) -> num
            | _ -> EvalExpr(a)
        let right =
            match b with
            | Num(num) -> num
            | _ -> EvalExpr(b)
        let res2 = left - right
        printfn "%f - %f = %f" left right res2
        res2


[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите выражение: ")
    let (k:string) = Console.ReadLine()
    let expr1Parser = run parseExpression k
    printfn "%A" expr1Parser
    match expr1Parser with
    | Success(result, _, _) ->
        let eval1 = EvalExpr(result)
        printfn "Результат вычислений: %f" eval1
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg
    0
