namespace SingletonPattern.Models;

public  class CountryProvider
{
    private new List<Country> Countries { get; set; }
    private static CountryProvider instance=null; //Singleton Design Pattern

    //public static CountryProvider Instance 
    //{ 
    //get
    //  {
    //if (instance is null) 
    //{
    //    instance = new CountryProvider();
    //    //need create an instance
    //}

    //      instance= instance ?? new CountryProvider();  //simplyfied version of the above code
    //      return instance;

    //    } 
    //    set => instance = value; 
    //}
    //public static CountryProvider Instance //more simplified version of the above code
    //{
    //    get => instance ?? (instance=new CountryProvider()); //Singleton Design Pattern
    //    set => instance = value;
    //}

    public static CountryProvider Instance => instance ?? (instance=new CountryProvider());//more simplified version of the above code


    //C# içerisindeki atama işlemleri bize bir sonuç döndürür. 


    //-- Yöntem 1
    //public async Task<List<Country>> GetCountries() //Singleton pattern içinde singleton pattern kullanmış olduk.
    //{
    //    if (Countries is  null)
    //    {
    //        await Task.Delay(2000);
    //        Countries=new List<Country>
    //        {
    //            new Country { Name = "India" },
    //            new Country { Name = "USA" },
    //            new Country { Name = "UK" }
    //        };
    //    }
    //    return Countries;
    //}

    //Yöntem 2 eğer get country nin çalıştığı durumda instance in bir kere oluşturulduğunu varsaydığımız durumda kullanılabilir:

    private CountryProvider() //Bu const dışında başka bir yerde instance oluşturulamaz.Private olmasının sebebi de bu.
    {
        Task.Delay(2000).GetAwaiter().GetResult();
        Countries = new List<Country>
                {
                    new Country { Name = "India" },
                    new Country { Name = "USA" },
                    new Country { Name = "UK" }
                };
    }
    public async Task<List<Country>> GetCountries() => Countries;
    public int GetCountryCount => Countries.Count;
}