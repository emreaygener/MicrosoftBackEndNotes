public class AnimalFactory
{
    public static Animal CreateAnimal(string type)
    {
        if (type == "Dog")
        {
            return new Dog();
        }
        else if (type == "Cat")
        {
            return new Cat();
        }
        else
        {
            throw new ArgumentException("Invalid animal type");
        }
    }
}