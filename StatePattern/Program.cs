// State Design Pattern - Behavioral Design Patterns //
// OOP ile oluşturulan objenin kendi iç durumlarını kendi statusune göre yapması.
// Bir objenin durumlarını değiştirmek için kullanılır. Yürümek -> koşmaya
// State'ler arasındaki sıra(adımlar) belirliyse kullanılabilir. x-> y-> z şeklinde

//State Design Pattern'in Avantajları :
// Esneklik ve genişletebilirlik kazandırır. Bakım yapmasını kolaylaştırır.


/*
    Yeni Sipariş
    İşleniyor
    Yolda/Gönderimde
    Teslim Edildi
*/

var order = new Order();
order.PrintOrderState();
order.NextState();
order.PrintOrderState();
order.NextState();
order.PrintOrderState();



record DeliveredState : IOrderState
{
    public void Next(Order order)
    {
        System.Console.WriteLine("This is the final state.");
    }

    public void Previous(Order order)
    {
        //İstenildiği durumda buralarda düzenlemelere gidilebilir kod yazılabilir.
        order.State = new OnTheWayState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is delivered.");
    }
}

record OnTheWayState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new DeliveredState();
    }

    public void Previous(Order order)
    {
        order.State = new ProcessingState();
    }

    public void PrintStatus()
    {
        System.Console.WriteLine("Order is on the way.");
    }
}

record ProcessingState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new OnTheWayState();
    }

    public void Previous(Order order)
    {
        order.State = new NewOrderState();
    }

    public void PrintStatus()
    {
        System.Console.WriteLine("Order is being processed.");
    }
}
record NewOrderState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new ProcessingState();
    }

    public void Previous(Order order)
    {
        System.Console.WriteLine("this is the initial state."); //Öncesi yok
    }

    public void PrintStatus()
    {
        System.Console.WriteLine("Order is placed.");
    }
}

interface IOrderState
{
    void Next(Order order);
    void Previous(Order order);
    void PrintStatus();
}

class Order
{
    public IOrderState State { get; set; }
    public Order()
    {
        State = new NewOrderState();
    }
    public void NextState()
    {
        State.Next(this);
    }
    public void PreviousState()
    {
        State.Previous(this);
    }
    public void PrintOrderState()
    {
        State.PrintStatus();
    }
}