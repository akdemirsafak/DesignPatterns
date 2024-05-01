// Singleton Design Pattern
// Kullanması bir miktar tehlike yaratabilecek(tam anlamıyla anlaşılmadığı durumlarda) bir pattern'dir.
// Adı tekillikten gelir.

//Avantajları : 
// 1- Tek bir nesne oluşturulur ve bu nesne üzerinden işlemler yapılır. Ensure single instance of a class.(can be used for logging, driver objects, caching, thread pool, database connections)
// 2- Tek bir nesne üzerinden işlemler yapılacağı için bellek kullanımı daha az olacaktır.
// 3- Tek bir nesne üzerinden işlemler yapılacağı için işlemler daha hızlı olacaktır.
// 4- Global erişim sağlar. Globally accessible object. (Aynı instance'ı kullanacak şekilde)
// 5- Created only when needed. (Lazy initialization) (Nesne sadece ihtiyaç duyulduğunda oluşturulur.) Bu pattern'de kullanmadığımız bir obje kullanılmadıysa memory'de yer kaplamaz.

//Dezaavantajları :
// 1- Unit test yapılması zorlaşır. (mocking yapılması zorlaşır)
// 2- In multi-threaded environment, it may lead to issues. (Çoklu threadlerde sorunlara yol açabilir.) Her thread'in ayrı ayrı instance oluşturmasını engellemek için lock kullanılabilir.


using SingletonPattern.Models;


///////---- -------------Singleton Pattern Uygulamadan Önce -----------------///////

//Console.WriteLine(DateTime.Now.ToLongTimeString());
//var countryProvider= new CountryProvider(); //Burada tanımladık fakat başka bir yerde ihtiyaç duyduğumuzda tekrar tekrar tanımlamamız gerekecek.
//var countries = await countryProvider.GetCountries();

//foreach (var country in countries)
//{
//    Console.WriteLine(country.Name);
//}

////another service
//var countryProvider2= new CountryProvider();
//var countries2 = await countryProvider2.GetCountries();

//Console.WriteLine(DateTime.Now.ToLongTimeString()); //Burada işlemin başladığı ve bittiği süreçte 4 saniye var fakat burada yeni bir instance almasak 2 saniye olacaktı.

///////---- -------------Singleton Pattern Uygulandıktan Sonra -----------------///////

Console.WriteLine(DateTime.Now.ToLongTimeString());
var countries= await CountryProvider.Instance.GetCountries();
foreach (var country in countries)
{
    Console.WriteLine(country.Name);
}
//Another service
var countries2= await CountryProvider.Instance.GetCountries();
Console.WriteLine(DateTime.Now.ToLongTimeString());

Console.WriteLine(CountryProvider.Instance.GetCountryCount);


//singleton'ı program'ı çalıştırdığımızda oluşan main thread'in tek instance'ını oluşturur.
//webapi geliştirdiğimizde oradaki bir çok obje request geldiğinde oluşturulur oluyor.
//DI ile bir obje singleton olarak belirlendiyse avantajı tek instance alınmasıdır.
//Eğer her requestte yeniden tanımlanması gereken bir obje singleton olarak belirlenirse uygulamanın ömrü boyunca aynı instance alınır.

//Örneğin bir veritabanı bağlantısı singleton olarak belirlenirse/tanımlanırsa uygulamanın ömrü boyunca sadece tek bir db ye bağlanacağı anlamına gelir.
//Bu durumda veritabanı bağlantısı açık kalır ve her requestte yeniden bağlantı açılmaz.Aynı anda birden fazla request geldiğinde aynı connection üzerinden işlem yapılır.
//Tek connection kullanıldığı durumda aynı anda tek bir işlem yapılabileceği için diğer tüm istekler onun işlemi bitmesini bekler.
//Bu sebeplerden Ef core kullanırken scoped olarak kullanırız. 