namespace ReturnSwitchWithLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            var grade = program.CalculateStudentGrade(85);
            Console.WriteLine($"Student grade: {grade}");
        }

        public char CalculateStudentGrade(int score)
        {
            return score switch
            {
                >= 90 => 'A',
                >= 80 => 'B',
                >= 70 => 'C',
                >= 60 => 'D',
                _ => 'F'
            };
        }
    }
}