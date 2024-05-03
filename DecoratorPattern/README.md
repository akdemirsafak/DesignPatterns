Çok fazla kullanmamıza rağmen adını bilmediğimiz bir tasarım kalıbıdır.
Bu kalıbı kullanarak nesnelerimize dinamik olarak yeni özellikler ekleyebiliriz.
Bu design patterndeki asıl amaç görselde var olan IComponent içerisindekki operation 'u biraz daha genişletebilmek(kapsamını)
var olanı değiştirmek değil kullanım alanını biraz daha genişletmek amaçlıdır.

Ef core DbContext içerisinde override onmodelCreating, override SaveChanges gibi metotlar vardır.Bu methodlar base'e gönderim yapar.Burada yaptığımız ekstra işlemler aslında decorate pattern'in uygulanmasıdır.
Bu sayede kapsamı genişletmiş olduk.
Aynı şekilde ActionFilterlarve middleware'ler de bu pattern kullanılmaktadır. (await next() metodu ile base'e gönderim yapılır.)

