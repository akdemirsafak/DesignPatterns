namespace StrategyPattern;

class CombatExample
{

    //Strategy Design Pattern -- Behavioral Design Pattern

    //Çok sık kullanılan desgin patternlerinden biridir.
    //Yaratılmış bir nesne üzerinden kullanmış olduğu aksiyonları değiştirebildiğimiz pattern'dir.


    //var ch= new Character(new AggressiveStrategy());
    //ch.ApplyAttackStrategy();

    //Console.WriteLine("---------");

    //ch.SetCombatStrategy(new DefensiveStrategy());
    //ch.ApplyAttackStrategy();

    //Console.ReadLine();

    //class Character
    //{
    //    private ICombatStrategy _combatStrategy;

    //    public Character(ICombatStrategy combatStrategy)
    //    {
    //        _combatStrategy = combatStrategy;
    //    }
    //    public Character()
    //    {

    //    }

    //    public void SetCombatStrategy(ICombatStrategy combatStrategy)
    //    {
    //        _combatStrategy = combatStrategy;
    //    }

    //    public void ApplyAttackStrategy()
    //    {
    //        _combatStrategy.Attack();
    //    }
    //}


    //interface ICombatStrategy
    //{
    //    void Attack();
    //}


    //class AggressiveStrategy : ICombatStrategy
    //{
    //    public void Attack()
    //    {
    //        Console.WriteLine("Aggressive Attack");
    //    }
    //}


    //class DefensiveStrategy : ICombatStrategy
    //{
    //    public void Attack()
    //    {
    //        Console.WriteLine("Defensive Attack");
    //    }
    //}
}
