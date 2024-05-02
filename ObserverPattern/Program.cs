// Observer Pattern --- Behavioral Pattern //
//Hayatımızın bir çok alanında/ en sık kullanılan design pattern'lerden birisidir.
//Bir nesnenin durumu değiştiğinde bağımlı olan diğer nesnelerin otomatik olarak haberdar olmasını sağlar.
//Sürekli olarak bir şeyi kontrol etmekten ise karşıda olan şeyin kendine haber verilmesini bekliyor.

//Örneğin ürün stokta yoksa stoğa gelince beni haberdar et. En sık kullanılan örneklerinden birisidir.

//Observer Pattern'de 3 ana yapı vardır.
//1- Subject: Gözlemciye haber vermek isteyen nesne.
//2- Observer: Haber almak isteyen nesne.
//3- Concrete Observer: Observer'ın somut hali.



var samsung = new Product("Samsung S21", 10000);
var iphone = new Product("Iphone 12", 15000);

var observer = new ObserverUser("Ali");
var observer2 = new ObserverUser2("Şafak");

var amazon = new Amazon();

amazon.Register(observer, samsung); //Ali samsung ürününün stoğa girmesini takip ediyor.
//amazon.NotifyForProductName(samsung.Name);
amazon.Register(observer2, iphone); //Şafak iphone ürününün stoğa girmesini takip ediyor.
//amazon.NotifyForProductName(iphone.Name);

amazon.NotifyAll(); //Bütün ürünlerin stoğa girmesini takip eden kullanıcılara bildirim gitmesi için.
Console.ReadLine();

public class Amazon
{
    private Dictionary<IObserver, Product> _observers = new Dictionary<IObserver, Product>();
    public void Register(IObserver observer, Product product)
    {
        _observers.TryAdd(observer, product);
        //ürün stoğa gelince bildirim almak isteyen kullanıcılar Observer'lara denk gelir.

    }
    public void UnRegister(IObserver observer) //Yukarıdaki Dictionary'de 1 observer 1 product'ı kontrol edebilir şekilde tanımlama yaptığımız için Product'ı parametre olarak almamıza gerek kalmadı.
    {
        _observers.Remove(observer);
        //ürün stoğa gelince bildirim almak istemeyen kullanıcılar Observer'lardan çıkarılır.
    }
    public void NotifyAll() //Bütün product'ların aynı anda stoğa girmesi durumunda bütün kullanıcılara bildirim gitmesi için.
    {
        foreach (var observer in _observers)
        {
            observer.Key.StockUpdate(observer.Value); //Herhangi bir şey olduğunda observer'larını haberdar ediyor.
        }
    }
    public void NotifyForProductName(string productName) //Bir ürün stoğa girdiğinde sadece o ürünü takip eden kullanıcılara bildirim gitmesi için.
    {
        foreach (var observer in _observers)
        {
            if (observer.Value.Name == productName)
            {
                observer.Key.StockUpdate(observer.Value);
            }
        }
    }
}


public class ObserverUser : IObserver
{
    public string FullName { get; set; }
    public ObserverUser(string fullName)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
    }
    public void StockUpdate(Product product)
    {
        System.Console.WriteLine($"{FullName} {product.Name} ürünü {product.Price} Tl fiyatıyla stoğa geldi.");
    }
}

public class ObserverUser2 : IObserver
{
    public string FullName { get; set; }
    public ObserverUser2(string fullName)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
    }
    public void StockUpdate(Product product)
    {
        System.Console.WriteLine($"{FullName} {product.Name} ürünü {product.Price} Tl fiyatıyla stoğa geldi.");
    }
}

public interface IObserver
{
    public void StockUpdate(Product product);
}


public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}




