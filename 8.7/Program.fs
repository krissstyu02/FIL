// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

(*Задание 7 Реализовать сравнение документов по 2м категориям*)

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
    member this.Number
      with get() = number
      and set(value) = number <- value
    member this.Country_export
      with get() = country_export
      and set(value) = country_export <- value
    member this.Body_color
      with get() = body_color
      and set(value) = body_color <- value
    member this.Year_of_manufacture
      with get() = year_of_manufacture
      and set(value) = year_of_manufacture <- value
    member this.Model
      with get() = model
      and set(value) = model <- value
    member this.Mass
      with get() = mass
      and set(value) = mass <- value
    member this.EnginePower
      with get() = enginePower
      and set(value) = enginePower <- value
    member this.Category
      with get() = category
      and set(value) = category <- value
    member this.Name
      with get() = name
      and set(value) = name <- value
    override this.ToString() = "Наименование: " + name +  ", категория: "+ Convert.ToString(category) + ", мощность двигателя: "+ Convert.ToString(enginePower) + ", масса: "+ Convert.ToString(mass)+ ", модель: "+ Convert.ToString(model)+ ", год изготовления: "+ Convert.ToString(year_of_manufacture)+ ", цвет кузова: "+ Convert.ToString(body_color)+ ", страна вывоза: "+ Convert.ToString(country_export)+",номер: " + number
    member this.Print() = Console.WriteLine(this.ToString())

    override this.Equals(b) =
        match b with
        | :? TSpasport as p -> ((this.Number) = (p.Number) && (this.Model) = (p.Model))
        | _ -> false
    override this.GetHashCode() = ( this.Model+this.Number).GetHashCode()
    interface System.IComparable with
        member this.CompareTo (obj:Object) =
            match obj with
              | :? TSpasport as o -> if ((this.Model) > (o.Model)) then 1 else if ((this.Model) = (o.Model) && (this.Number) > (o.Number)) then 1 else 0
              | _ -> invalidArg "obj" "This diferent types" 
        end


[<EntryPoint>]
let main argv =
    let p1 = TSpasport(Number="X7D21070030017580", Name="Легковой седан", Category='B', EnginePower=71.2, Mass=1060,Model="ВАЗ-2103 7142261",Year_of_manufacture=2003,Body_color="Сине-зеленый",Country_export="ОТСУТСВУЕТ")
    let p2 = TSpasport(Number="JACDJ68X9X7929830", Name="Легковой", Category='B', EnginePower=215.0, Mass=2275,Model="ISUZU TROOPER",Year_of_manufacture=1999,Body_color="СЕРЫЙ",Country_export="ОТСУТСВУЕТ")
    Console.WriteLine(p1>p2)
    0