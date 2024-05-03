//Strategy Design Pattern -- Behavioral Design Pattern

//Çok sık kullanılan desgin patternlerinden biridir.
//Yaratılmış bir nesne üzerinden kullanmış olduğu aksiyonları değiştirebildiğimiz pattern'dir.



//Gerçek hayat örneği  : Bir ödeme sistemi kullanıldığını düşünelim. Ödeme işlemleri sırasında ödeme tipi seçilebilir.
//Ödeme tipi seçildiğinde ödeme tipine göre işlem yapılır.
//Örneğin kredi kartı ile ödeme yapılacaksa kredi kartı bilgileri girilir ve ödeme yapılır.
//Eğer havale ile ödeme yapılacaksa havale bilgileri girilir ve ödeme yapılır. Bu durumda Strategy Pattern kullanılabilir.
//Ödeme tipine göre işlem yapılacaksa Strategy Pattern kullanılabilir.


var paymentOptions = new PaymentOptions
{
    CardNumber = "123456789",
    CardHolderName = "Ali Veli",
    CardExpirationDate = "12/22",
    CardCvv = "123",
    Amount = 100
};

var paymentService = new PaymentService();


do
{
    Console.Write("Ödeme yapılacak bankayı seçiniz : (1: Ziraat, 2: Garanti, 3: İş Bankası");
    var bank = Console.ReadLine();

    IPaymentService bankPaymentService = null;

    switch (bank)
    {
        case "1":
            bankPaymentService = new ZiraatBankPaymentService();
            break;
        case "2":
            bankPaymentService = new GarantiBankPaymentService();
            break;
        case "3":
            bankPaymentService = new IsBankPaymentService();
            break;
        default:
            Console.WriteLine("Geçersiz banka seçimi");
            break;
    }
    paymentService.SetPaymentService(bankPaymentService);
    paymentService.PayViaStrategy(paymentOptions);
    
} while(Console.ReadKey().Key != ConsoleKey.Escape);


class PaymentService
{
    private IPaymentService _paymentService;

    public PaymentService()
    {
        
    }
    public PaymentService(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    public void SetPaymentService(IPaymentService paymentService) //Anlık strategy değişikliği yapabilmek için sadece ctor olmamalı
    {
        _paymentService = paymentService;
    }

    public bool PayViaStrategy(PaymentOptions paymentOptions)
    {
        return _paymentService.Pay(paymentOptions);
    }
}


interface IPaymentService
{
    bool Pay(PaymentOptions paymentOptions);
}

class PaymentOptions
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string CardExpirationDate { get; set; }
    public string CardCvv { get; set; }
    public decimal Amount { get; set; }
}

class ZiraatBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("Ziraat Bank Payment Service");
        return true;
    }
}
class GarantiBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("Garanti Bank Payment Service");
        return true;
    }
}
class IsBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("Is Bank Payment Service");
        return true;
    }
}
