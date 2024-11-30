public class Dog : Animal
{
    public override void Eat()
    {
        Console.WriteLine("Dog is eating");
    }

    public override void MakeSound()
    {
        Console.WriteLine("Bark");
    }
}