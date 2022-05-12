// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

(*Задание 8 Реализовать валидацию полей класса с помощью регулярных
выражений*)
open System
open System.Diagnostics
open System.Text.RegularExpressions

type TSpasport() =
    let mutable number = ""
    let mutable name = " "
    let mutable category = ' '
    let mutable enginePower = 0.0
    let mutable mass = 0
    let mutable model = " "
    let mutable year_of_manufacture = 0
    let mutable body_color = " "
    let mutable country_export = " "

    member this.Name
     with get() = name
     and set(value) =
     if (Regex.IsMatch (value, @"[А-Я]+"))
     then name <- value
     else Console.WriteLine("Ошибка формата ввода")

    member this.Year_of_manufacture
      with get() = year_of_manufacture
      and set(value:int) =
      if (Regex.IsMatch (Convert.ToString(value), @"[0-9]+"))
      then year_of_manufacture <- value
      else Console.WriteLine("Ошибка формата ввода")

    member this.Country_export
      with get() = country_export
      and set(value) =
      if (Regex.IsMatch (value, @"[А-Я]+"))
      then country_export <- value
      else Console.WriteLine("Ошибка формата ввода")

    member this.Body_color
      with get() = body_color
      and set(value) =
      if (Regex.IsMatch (value, @"[А-Я]+"))
      then body_color <- value
      else Console.WriteLine("Ошибка формата ввода")

    member this.Model
      with get() = model
      and set(value) =
        if (Regex.IsMatch (value, @"[A-ZА-Я0-9]+"))
        then model <- value
        else Console.WriteLine("Ошибка формата ввода")

    member this.Mass
        with get() = mass
        and set(value:int) =
            if (Regex.IsMatch (Convert.ToString(value), @"[0-9]+"))
            then mass <- value
            else Console.WriteLine("Ошибка формата ввода")
    member this.EnginePower
        with get() = enginePower
        and set(value:float) = 
            if (Regex.IsMatch (Convert.ToString(value), @"[0-9]+.[0-9]+"))
            then enginePower <- value
            else Console.WriteLine("Ошибка формата ввода")
    member this.Category
        with get() = category
        and set(value:char) =
            if (Regex.IsMatch (Convert.ToString(value), @"(A|B|C|D|E)"))
            then category <- value
            else Console.WriteLine("Ошибка формата ввода")
    member this.Number
        with get() = number
        and set(value) =
            if (Regex.IsMatch (value, @"[A-Z0-9]{17}"))
            then number <- value
            else Console.WriteLine("Ошибка формата ввода")
     override this.ToString() = "Наименование: " + name +  ", категория: "+ Convert.ToString(category) + ", мощность двигателя: "+ Convert.ToString(enginePower) + ", масса: "+ Convert.ToString(mass)+ ", модель: "+ Convert.ToString(model)+ ", год изготовления: "+ Convert.ToString(year_of_manufacture)+ ", цвет кузова: "+ Convert.ToString(body_color)+ ", страна вывоза: "+ Convert.ToString(country_export)+",номер: " + number
     member this.Print() = Console.WriteLine(this.ToString())

[<EntryPoint>]
let main argv =
    let random = System.Random()
    let p1 =  TSpasport(Number="X7D21070030017580", Name="Легковой седан", Category='B', EnginePower=71.2, Mass=1060,Model="ВАЗ-2103 7142261",Year_of_manufacture=2003,Body_color="Сине-зеленый",Country_export="ОТСУТСВУЕТ")
    let p2=  TSpasport(Number="X7D21070030017580", Name="111", Category='1', EnginePower=71.2, Mass=1060,Model="ВАЗ-2103 7142261",Year_of_manufacture=2003,Body_color="Сине-зеленый",Country_export="123")
    p1.Print()
    p2.Print()
    0