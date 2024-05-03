
//-- Factory Method Design Pattern - Creational Design Patterns --//

// Bir nesnenin örneklendirilmesi ile ilgilidir.
// Nesne örneklendirme işlemini alt sınıflara bırakır.(Alt sınıfların nesne oluşturma yetkisinin verilmesi.)
// Abstract Factory ile çok karıştırılan Pattern'dir.

// Pizza franchise örneği üzerinden gideceğiz. Pizzanın nasıl olacağının belirlenmesi her franchise'ın kendisinin belirlemesidir. 
// Her mağazadaki peynirli pizza aynı olmayabilir gibi..



var ankaraPizzaStore = new AnkaraPizzaStore();

var nyPizzaStore = new NYPizzaStore();

IPizza cheesePizza = ankaraPizzaStore.OrderPizza("cheese");
System.Console.WriteLine("Cheese pizza ordered in Ankara Store.");

IPizza veggiePizza = nyPizzaStore.OrderPizza("veggi");
System.Console.WriteLine("Veggi pizza ordered in NY City Store.");







interface IPizza
{
    void Prepare();
    void Bake();
    void Cut();
}
class VeggiPizza : IPizza
{
    public void Bake()
    {
        Console.WriteLine("Veggi Pizza is Baked");
    }

    public void Cut()
    {
        Console.WriteLine("Veggi Pizza is Cut");
    }

    public void Prepare()
    {
        Console.WriteLine("Veggi Pizza is Prepared");
    }
}
class CheesePizza : IPizza
{
    public void Bake()
    {
        Console.WriteLine("Cheese Pizza is Baked");
    }

    public void Cut()
    {
        Console.WriteLine("Cheese Pizza is Cut");
    }

    public void Prepare()
    {
        Console.WriteLine("Cheese Pizza is Prepared");
    }
}


abstract class PizzaStore
{
    protected abstract IPizza CreatePizza(string type); //Oluşturulacak alt sınıflarda pizzanın yapılma işlemi o sınıfa devredilecek/o sınıf tarafından üstlenecek. 
    public IPizza OrderPizza(string type) //Herhangi bir mağazada pizza sipariş edildiğinde yapılacakları temsil ediyor.
    {
        IPizza pizza = CreatePizza(type);
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        return pizza;
    }
}

class AnkaraPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggi" => new VeggiPizza(),
            _ => throw new ArgumentException("Invalid pizza type.", nameof(type))
        };
    }
}

class NYPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggi" => new VeggiPizza(),
            _ => throw new ArgumentException("Invalid pizza type.", nameof(type))
        };
    }
}