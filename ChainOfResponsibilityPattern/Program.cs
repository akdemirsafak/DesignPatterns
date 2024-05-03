// Chain of Responsibility Pattern - Behavioral Design Patterns //

// Birbirinden bağımsız ama peşpeşe gerçekleştirilen aksiyonlar için düşünülebilir.
// Amaç peşpeşe birçok aksiyonu yapabilmektir fakat bu aksiyonları gerçekleştirirken servisler arası iletişimi gerçekleştirirken bağımlılıkları ortadan kaldırmamızı sağlar.
// Bu patternde servislerimiz çalışan/çalışacak bir önceki ve bir sonraki servisin ne olduğunu bilmesine ihtiyaç duymuyor.

//Bu pattern'i kullanmanın avantajı "Seperation of Concern" bütün işlemleri birbirinden ayırdık ve hepsi kendi işlemini yapar hale geldi.
//Okunabilirlik de artmış oldu.

// Örneğimizde Order sürecini stok kontrol adımından itibaren gerçekleştireceğiz. 
// 1. Stock Control -> Payment -> Invoice -> Shipping

var order = new Order
{
    ProductName = "Laptop",
    Quantity = 1,
    Price = 5000
};

var stockControl = new StockControl();
var paymentControl = new PaymentControl();
var invoice = new Invoice();
var shipping = new Shipping();

stockControl.SetNext(paymentControl);
paymentControl.SetNext(invoice);
invoice.SetNext(shipping);

stockControl.Handle(order); //Sadece zincirin ilk halkasını kullanıyor olacağız.

// Her adımda handle'ı tetiklememize gerek kalmadı

class Shipping : IOrderHandler
{
    private IOrderHandler _next;
    public void SetNext(IOrderHandler next)
    {
        _next = next;
    }
    public bool Handle(Order order)
    {
        bool shippingSuccess = true; //Check shipping
        return _next is not null && shippingSuccess ? _next.Handle(order) : shippingSuccess;
    }
}

class Invoice : IOrderHandler
{
    private IOrderHandler _next;
    public void SetNext(IOrderHandler next)
    {
        _next = next;
    }
    public bool Handle(Order order)
    {
        bool isIncoiveSuccess = true; //Check stock service
        return _next is not null && isIncoiveSuccess ? _next.Handle(order) : isIncoiveSuccess;
    }
}

class PaymentControl : IOrderHandler
{
    private IOrderHandler _next;
    public void SetNext(IOrderHandler next)
    {
        _next = next;
    }
    public bool Handle(Order order)
    {
        bool paymentSuccess = true; //Check stock service
        return _next is not null && paymentSuccess ? _next.Handle(order) : paymentSuccess;
    }
}


class StockControl : IOrderHandler
{
    private IOrderHandler _next;
    public void SetNext(IOrderHandler next)
    {
        _next = next;
    }
    public bool Handle(Order order)
    {
        bool stockAvailable = true; //Check stock service
        if (_next is not null && stockAvailable)
        {
            Console.WriteLine("Stock is available.");
            return _next.Handle(order);
        }
        Console.WriteLine("Stock is not available.");
        return stockAvailable;
    }
}


public interface IOrderHandler
{
    bool Handle(Order order);
    void SetNext(IOrderHandler next); //bir iş başarılı şekilde tamamlanmışsa kendisinden sonra hangi adımın gerçekleşmesi gerektiğini göndereceğiz.
}

public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}