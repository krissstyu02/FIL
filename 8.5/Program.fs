
//Паспорт транспортного средства.


open System
(*Задание 5 Создать класс, содержащий информацию о документе.*)

type TSpasport(n:string, na:string, c: char, e: float, m: int, md:string,y:int,b:string,cn:string) =
    let mutable number = n
    let mutable name = na
    let mutable category = c
    let mutable enginePower = e
    let mutable mass = m
    let mutable model = md
    let mutable year_of_manufacture = y
    let mutable body_color = b
    let mutable country_export = cn
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

[<EntryPoint>]
let main argv =
    let p1 = TSpasport("X7D21070030017580","Легковой седан", 'B', 71.2, 1060,"ВАЗ-2103 7142261",2003,"Сине-зеленый","ОТСУТСВУЕТ")
    p1.Print()
    0 // return an integer exit code
