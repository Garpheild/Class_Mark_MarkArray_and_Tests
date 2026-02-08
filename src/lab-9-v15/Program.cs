namespace lab_9_v15;

internal abstract class Program
{
    static void Main()
    {
        Mark mark1 = new Mark();
        Mark mark2 = new Mark("Программирование", 10);
        Mark mark3 = !mark2;
        mark1.Show();
        mark2.Show();
        mark3.Show();
        Console.WriteLine(mark1.ToFivePointScale());
        Console.WriteLine(Mark.ToFivePointScale(mark2));
        Console.WriteLine(Mark.CountObjects());
    }

    /// <summary>
    /// Найти все дисциплины с оценкой выше средней.
    /// </summary>
    static MarkArray FindMarksAboveAverage(MarkArray collection)
    {
        throw new NotImplementedException();
    }
}
