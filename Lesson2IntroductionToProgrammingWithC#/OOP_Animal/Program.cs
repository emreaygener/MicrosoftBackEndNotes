public class Program
{
    public static void Main(string[] args)
    {
        Dog myDog = new Dog();
        Cat myCat = new Cat();

        myDog.MakeSound();
        myCat.MakeSound();

        myDog.Eat();
        myCat.Eat();

        List<Animal> animals = new List<Animal>();
        animals.Add(new Dog());
        animals.Add(new Cat());

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }
}
