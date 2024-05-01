//Structural Design patterns kategorisindendir.

//Ülkelerdeki prizlerin farklı olması durumunda, bir ülkede kullanılan prizi başka bir ülkede kullanabilmek için adaptör kullanılır.
//Burada kullandığımız dönüştürücü adaptör tasarım desenine örnektir.
//Voltaj farkı gibi durumları göz önünde bulundurarak güncellememizi yaparız.

//Bir banka uygulaması geliştirdiğimizi düşünelim.Hesaplar arası transfer işlemi yaptığımızı düşünelim.



//Senaryomuzda bir bankanın xml ile diğerinin ise json ile çalışacaktır



var trans= new TransferTransaction
{
    Amount= 100,
    FromIBAN= "TR123456",
    ToIBAN= "TR654321"
};
var jsonAdapter= new JsonBankApiAdapter();
var jsonAdapterResult = jsonAdapter.ExecuteTransaction(trans);

Console.WriteLine($"Result : "+jsonAdapterResult);

//var xmlAdapter= new XmlBankApiAdapter();
//var xmlAdapterResult = xmlAdapter.ExecuteTransaction(trans);




interface IBankApi
{
    bool ExecuteTransaction(TransferTransaction transaction);
}


class JsonBankApiAdapter : IBankApi
{
    private readonly JsonBankApi _jsonBankApi;
    public JsonBankApiAdapter()
    {
        _jsonBankApi = new();
    }

    public bool ExecuteTransaction(TransferTransaction transaction)
    {
        //JsonBankApi sınıfı ile çalışacak olan JsonBankApiAdapter sınıfı
        // More code here
        return _jsonBankApi.ExecuteTransaction(transaction);
    }
}

class XmlBankApiAdapter : IBankApi
{
    private readonly XmlBankApi _xmlBankApi;
    public XmlBankApiAdapter()
    {
        _xmlBankApi = new();
    }

    public bool ExecuteTransaction(TransferTransaction transaction)
    {
        //XmlBankApi sınıfı ile çalışacak olan XmlBankApiAdapter sınıfı
        // More code here
        return _xmlBankApi.ExecuteTransaction(transaction);
    }
}

class JsonBankApi : IBankApi
{
    public bool ExecuteTransaction(TransferTransaction transaction)
    {
        // Banka API'si ile transfer işlemi yapılır.
        var json= $$"""
                {
                    ""Amount""{{transaction.Amount}}""
                    ""FromIBAN""{{transaction.FromIBAN}}""
                    ""ToIBAN""{{transaction.ToIBAN}}""
                }
                """;
        Console.WriteLine($"{GetType().Name} worked.");
        Console.WriteLine(json);
        return true;
    }
}

class XmlBankApi
{
    public bool ExecuteTransaction(TransferTransaction transaction)
    {
        // Banka API'si ile transfer işlemi yapılır.
        // """ """ ile çok satırlı string tanımlayabiliriz. .Net7 ile gelen bir özelliktir.
        var xml= $"""
                <TransferTransaction>
                    <Amount>{transaction.Amount}</Amount>
                    <FromIBAN>{transaction.FromIBAN}</FromIBAN>
                    <ToIBAN>{transaction.ToIBAN}</ToIBAN>
                </TransferTransaction>
                """;
        Console.WriteLine($"{GetType().Name} worked.");
        Console.WriteLine(xml);
        return true;
    }
}







class TransferTransaction
{
    public decimal Amount { get; set; }
    public string FromIBAN { get; set; }
    public string ToIBAN { get; set; }
}