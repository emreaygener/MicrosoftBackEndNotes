public class Cat : Animal
{
    public override void Eat()
    {
        Console.WriteLine("Cat is eating");
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}