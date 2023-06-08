public class Dog : Animal
{
    private int _legs;
    public Dog() : base (4)
    {
    }
    public void SetLegs(int legs)
    {
        if(legs > 1000)
        {
            throw new ArgumentException("Animals can not have more then 1000 legs!");
        }
    }
    public void speak()
    {
        System.Console.WriteLine($"Woof, Woof!");
    }
}