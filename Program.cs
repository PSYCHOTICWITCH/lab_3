using lab_3;

internal class Program
{
    public static void Main(string[] args)
    {

        FileClass.FillFile("jopa");
        FileClass.ShowFile("jopa");
        Console.WriteLine($"Среднее арифметическое {FileClass.FindAvg("jopa")}");

    }
}