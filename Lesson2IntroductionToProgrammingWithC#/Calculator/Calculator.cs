class Calculator
{
    int number1;
    int number2;
    public int Add()
    {
        return number1 + number2;
    }
    static void Main()
    {
        Calculator calculator = new Calculator();
        calculator.number1 = 10;
        calculator.number2 = 20;
        Console.WriteLine(calculator.Add());
    }
}