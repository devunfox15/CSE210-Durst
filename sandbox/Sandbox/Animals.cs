public class Animal
{
    private int _legs;
    public Animal(int legs)
    {
        _legs = legs;
    }

    public void Move()
    {
        System.Console.WriteLine($"I am moving on {_legs} legs");
    }
}