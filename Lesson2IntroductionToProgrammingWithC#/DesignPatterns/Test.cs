public class Test
{
    public string Name { get; set; }
    public Test(string name)
    {
        Name = name;
    }
    public string ChangeName
    {
        get
        {
            return Name + " Getter";
        }
        set
        {
            Name = value + " Setter";
        }
    }
}