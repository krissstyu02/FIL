// Learn more about F# at http://fsharp.org

open System

//задача 2

let ordered str=
    let new_string=String.filter(fun ch->Char.IsLower(ch)) str      //переводим символы сьроки на нижний регистр
    let make_list=Seq.toList(new_string)
    let check=List.map2(fun ch1 ch2-> ch1<=ch2) make_list.[0..make_list.Length-2] make_list.[1..make_list.Length-1]   //проверка на упорядоченность двух элементов
    if (List.fold (fun s x-> if x=false then s+1 else s) 0 check) = 0 then Console.WriteLine("Символы строки упорядочены")   
    else Console.WriteLine("Символы строки  не упорядочены")

//задача 10

let letterA str=
    let new_string=String.filter(fun ch->ch='A') str
    Console.WriteLine(new_string.Length)

//задача 17

let find_file str=
    let rec file2 (str: string) check ind =
        if (ind = -1) then str     //дошли до начала строки
        else
            if (int(str.[ind]) = check) then str.[(ind+1)..]  //добавляем название файла
            else file2 str check (ind-1)
    let rec file3 (str: string) check ind =
        if (ind = str.Length) then str      //дошли до конца строки
        else
            if (int(str.[ind]) = check) then str.[..(ind-1)]  //добавляем название файла 
            else file3 str check (ind+1)
    let file_name1= file2 str (int('\\')) (str.Length-1)
    let file_name2=file3 file_name1 (int('.')) 0
    Console.WriteLine(file_name2)

let function_sellection n=
    Console.WriteLine("Введите строку: ")
    let str= Console.ReadLine()
    match n with
    |"1"-> ordered str
    |"2"-> letterA str
    |"3"->find_file str
[<EntryPoint>]
let main argv =
    Console.WriteLine("Выберите одну из трех предложенных программ:
    1.Проверить, упорядочены ли строчные символы этой строки по возрастанию
    2.Дана строка. Необходимо подсчитать количество букв А в строке.
    3.Дана строка в которой записан путь к файлу. Необходимо найти
    имя файла без расширения.")
    let n=Console.ReadLine()|>function_sellection
    0


