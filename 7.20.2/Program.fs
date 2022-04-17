// Learn more about F# at http://fsharp.org

open System

//В порядке увеличения среднего веса ASCII-кода символа строки

let firstsort arrStr =
    let rec firstsort2 (str:string) ind (acc:int)=
        if (ind = str.Length) then Convert.ToDouble(acc)/Convert.ToDouble(str.Length) //(сумма кодов/кол-во символов)
        else
            let new_acc = acc + Convert.ToInt32(str.[ind]) //прибавляем  ASCII-код
            firstsort2 str (ind+1) new_acc

    Array.sortBy 
        (fun (str:string) -> 
            firstsort2 str 0 0) 
        arrStr

 (*В порядке увеличения квадратичного отклонения частоты встре-
 чаемости самого часто встречаемого в строке символа от частоты его встре-
 чаемости в текстах на этом алфавите*)
let secondsort arrStr =           //частота встречаемости английских букв
    let AlphabetFrequensy = [|
                        8.17
                        ;8.17
                        ;1.49
                        ;2.78
                        ;4.25
                        ;12.70
                        ;2.23
                        ;2.02
                        ;6.09
                        ;6.97
                        ;0.15
                        ;0.77
                        ;4.03
                        ;2.41
                        ;6.75
                        ;7.51
                        ;1.93
                        ;0.10
                        ;5.99
                        ;6.33
                        ;9.06
                        ;2.76
                        ;0.98
                        ;2.36
                        ;0.15
                        ;1.97
                        ;0.07
                    |]
    let square_deviation str =

        let rec mostfrequency (str:string) ind (frequency:int) (letter:char)=  
            if (ind = str.Length) then (frequency,letter)
            else
                let letter_frequency = (String.filter (fun c -> c = str.[ind]) str).Length   //частота встречаемости буквы в строке
                if (letter_frequency > frequency) then mostfrequency str (ind+1) letter_frequency str.[ind]
                else mostfrequency str (ind+1) frequency letter
        
        let frequency_and_letter =mostfrequency str 0 0 ' '  //смая частая ьуква и ее встречаемость
        let text_frequency =                            //процент встречаемости буквы в строке
            ((fst(frequency_and_letter)|> Convert.ToDouble) 
                / ( str.Length |> Convert.ToDouble))
            * 100.0

        let alphabet_frequency2 = 
            if (Char.IsLower (snd(frequency_and_letter)))   //Показывает, относится ли указанный символ Юникода к категории букв нижнего регистра.
            then AlphabetFrequensy.[(Convert.ToInt32(snd(frequency_and_letter)) - 97)]  //ASCII-код-97=номер в алфавите для нижнего регистра
            else AlphabetFrequensy.[(Convert.ToInt32(snd(frequency_and_letter))- 65)]

        (text_frequency-alphabet_frequency2)*(text_frequency-alphabet_frequency2) //квадратичное отклонение

    Array.sortBy 
           (fun (str:string) -> 
               square_deviation str) 
           arrStr


let writeArray arr = 
    let rec WriteArray2 (arr : 'T [] ) (ind : int)=
        if (ind = arr.Length) then ()
        else
            System.Console.WriteLine( arr.[ind] )
            WriteArray2 arr (ind+1)
    WriteArray2 arr 0

let functionsellection n str =
    match n with
    |1 -> writeArray (firstsort str)
    |_ -> writeArray (secondsort str)

[<EntryPoint>]
let main argv =
    System.Console.WriteLine( "Введите количество строк: " )
    let num = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine( "Введите строки: " )
    let arrStr = [| for i in 1..num -> System.Convert.ToString(System.Console.ReadLine()) |]
    System.Console.WriteLine( "Введите номер задачи: " )
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    functionsellection n arrStr
    0
