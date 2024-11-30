public class Program
{
    public static void Main()
    {
        //! Singleton Design Pattern
        Database db1 = Database.GetInstance();
        Database db2 = Database.GetInstance();

        db1.Connect();  // Outputs: Connected to database
        Console.WriteLine(object.ReferenceEquals(db1, db2)); // Outputs: True
        //! Adapter Design Pattern
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee); // Outputs: SpecificRequest

        target.Request();
        //! Factory Design Pattern
        Animal dog = AnimalFactory.CreateAnimal("Dog");
        dog.Speak(); // Outputs: Woof!

        Animal cat = AnimalFactory.CreateAnimal("Cat");
        cat.Speak(); // Outputs: Meow!
        //! Observer Design Pattern
        Subject subject = new Subject();

        IObserver observer1 = new ConcreteObserver("Observer 1");
        IObserver observer2 = new ConcreteObserver("Observer 2");

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.Notify("Hello, Observers!"); // Outputs: "Observer 1 received message: Hello, Observers!"
                                             //          "Observer 2 received message: Hello, Observers!"

    }
}