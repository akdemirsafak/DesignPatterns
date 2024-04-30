using BuilderPattern.Methods.Method1;
using System.Text;


//----------------------------------
// var sb = new StringBuilder(); //Builder pattern'e örnektir.

// sb.Append("Şafak"); //append methoduna bakarsak StringBuilder return ettiğini görürürüz.Bu da bize sb.Append("asd").Append("") gibi bir kullanım yapabilmemizi sağlar.
// sb.Append(" Akdemir");
// var fullName = sb.ToString(); // Şafak Akdemir

//Gereksinimleri oluşturduktan sonra nesneyi oluşturuyoruz. İsmi alsın soyadı alsın daha sonra da birleştirsin. Birleştirmesi için gerekli değişkenleri sağladık.

//---------------------

// var eb = new EndpointBuilder("https://localhost");
// eb
//     .Append("api")
//     .Append("v1")
//     .Append("user")
//     .AppendParam("id", "1")
//     .AppendParam("username", "şafak");

// var url = eb.Build(); //https://localhost/api/v1/user?id=1
// Console.WriteLine("Final url : " + url);

//------------------------ METHOD 1

var empBuilder = new EmployeeBuilderM1();

var emp = empBuilder
    .SetFullName("Şafak Akdemir")
    .SetEmail("akdemirsafak@gmail.com")
    .SetUserName("akdemirsafak")
    .BuildEmployee(); //builder pattern. BuildEmployee dedikten sonra EmployeeM1 dönecektir.

Console.WriteLine(emp);