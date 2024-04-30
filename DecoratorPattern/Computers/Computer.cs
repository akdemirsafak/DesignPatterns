using System.Diagnostics;

namespace DecoratorPattern.Computers;

//1950'lerde böyle olduğunu varsayalım.
public class Computer
{
    public void Start()
    {
        System.Console.WriteLine($"{GetType().Name} is starting...");
    }
    public void Stop()
    {
        System.Console.WriteLine($"{GetType().Name} is stopping...");
    }
}
//1970'lerde ise laptop'un geliştirildiğini varsayalım.Laptop da bir bilgisayar olduğu için Computer sınıfından türetiyoruz.
public class Laptop : Computer
{
    public void OpenLid()
    {
        Debug.WriteLine($"{GetType().Name}'s lid is opening...");
    }
    public void CloseLid()
    {
        Debug.WriteLine($"{GetType().Name}'s lid is closing...");
    }
}
//1990'larda ise Dell

public class LaptopDecorator : Laptop
{
    public virtual void OpenLidExtended() //Burada önemli olan laptop'daki method'a gidiyor olmak çünkü bu method'u genişletiyoruz.
    {
        //more codes
        base.OpenLid();
    }
    public virtual void CloseLidExtended()
    {
        base.CloseLid();
        //more
    }
}
public class DellLaptop : LaptopDecorator
{
    //openlidExtend çağırıldığında laptopDecorator'daki çalışacak.
    public override void CloseLidExtended()
    {
        Debug.WriteLine("CloseLid extended. Decorator pattern is working.Dell laptop sleeping.");
        base.CloseLidExtended();
        
    }
    public void OpenDellSupportAssist()
    {
        Debug.WriteLine($"{GetType().Name}'s Dell Support Assist is opening...");
    }
    public void CloseDellSupportAssist()
    {
        System.Console.WriteLine($"{GetType().Name}'s Dell Support Assist is closing...");
    }
}

public class AppleLaptop : LaptopDecorator
{
    public override void OpenLidExtended()
    {
        Debug.WriteLine("Openlid extended. Decorator pattern is working.Apple laptop opening.");
        base.OpenLidExtended();
    }
}