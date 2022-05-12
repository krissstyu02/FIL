// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.
open System
open System.Diagnostics
open System.Text.RegularExpressions

(*Задание 9 Реализовать абстрактный класс коллекция документов с
абстрактным методом searchDoc(doc : <Doc>). В качестве <Doc> Ваш
класс. Реализовать наследников указанного класса для коллекций Array,
List, BinaryList(для двоичного поиска), Set. Реализовать метод
searchDoc(doc : <Doc>) в каждом классе.
Задание 10 Протестировать время работы метода в каждом классе,
сделать выводы.*)
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

[<AbstractClass>]
type Collection() =
    abstract member searchDoc:(TSpasport)  -> (bool)

type ArrayTS(list:'TSpasport list)=
    inherit Collection()
    member this.Arr = Array.ofList list
    override this.searchDoc(obj) = 
        Array.exists (fun (x:TSpasport)-> x = obj) this.Arr

type ListTS(list:'TSpasport list)=
    inherit Collection()
    member this.list = list
    override this.searchDoc(obj) = 
        List.exists (fun (x:TSpasport)-> x = obj) this.list


type SetTS(list:'TSpasport list)=   //набор
    inherit Collection()
    member this.set = Set.ofList list
    override this.searchDoc(obj) = 
        Set.contains obj this.set

    override this.ToString() = "Записей: " + this.set.Count.ToString()

type BinaryListTS(list:'TSpasport list)=
    inherit Collection()
    let rec binSearch (l:'TSpasport list) (el:TSpasport) =
        match (List.length l) with
        |0->false
        |i->
            let mid = i/2
            match sign <| compare el l.[mid] with
            |0->true
            |1->binSearch l.[..mid - 1] el
            |_->binSearch l.[mid + 1..] el     

    member this.binaryList = List.sortBy (fun (x:TSpasport)-> x.Number+x.Model) list 
    override this.searchDoc(obj) = 
        binSearch this.binaryList obj



[<EntryPoint>]
let main argv =
    let random = System.Random()
    let listOfP = [ for i in 1 .. 10 -> TSpasport( Number="ABCDHRYO"+Convert.ToString(random.Next(100000000,999999999)),Name="Легковой", Category='A', EnginePower=104.15, Mass=1375,Model="ВАЗ-2103 7142261",Year_of_manufacture=2002,Body_color="Черный",Country_export="ОТСУТСВУЕТ") ]
    
    let Ap = ArrayTS(listOfP)
    let Lp = ListTS(listOfP)
    let Sp = SetTS(listOfP)
    let BLp = BinaryListTS(listOfP)
    let randomp = TSpasport(Number="ABCDHRYO"+Convert.ToString(random.Next(100000000,999999999)),Name="Легковой", Category='A', EnginePower=104.15, Mass=1375,Model="ВАЗ-2103 7142261",Year_of_manufacture=2002,Body_color="Черный",Country_export="ОТСУТСВУЕТ")

    let watch = new Stopwatch()
    watch.Start()
    Ap.searchDoc(randomp)
    watch.Stop()
    Console.WriteLine("Массив ARRAY: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    Lp.searchDoc(randomp)
    watch.Stop()
    Console.WriteLine("Массив LIST: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    Sp.searchDoc(randomp)
    watch.Stop()
    Console.WriteLine("Массив SET: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    BLp.searchDoc(randomp)
    watch.Stop()
    Console.WriteLine("Массив BinaryList: {0}", watch.Elapsed)
    watch.Restart()

    Console.WriteLine("Наиболее эффективен класс Лист")

    0