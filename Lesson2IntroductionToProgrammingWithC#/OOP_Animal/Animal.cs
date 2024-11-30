public abstract class Animal : IAnimal
{
    public abstract void Eat();

    public virtual void MakeSound()
    {
        Console.WriteLine("Some animal sound");
    }
}