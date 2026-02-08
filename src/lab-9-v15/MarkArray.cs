namespace lab_9_v15;

public class MarkArray
{
    private Mark[] marks;
    public static int CollectionCount { get; private set; } = 0;

    public MarkArray()
    {
        marks = new Mark[0];
        CollectionCount++;
    }



    public MarkArray(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Размер должен быть положительным числом", nameof(size));

        Random random = new Random();
        marks = new Mark[size];

        for (int i = 0; i < size; i++)
        {
            marks[i] = new Mark();
        }
        CollectionCount++;
    }


    public MarkArray(MarkArray other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        //if (other.marks == null)
        //{
        //    marks = null;
        //    return;
        //}

        marks = new Mark[other.marks.Length];
        for (int i = 0; i < other.marks.Length; i++)
        {
            if (other.marks[i] != null)
            {
                marks[i] = new Mark(other.marks[i]);
            }
        }
        CollectionCount++;
    }


    public void Display()
    {
        if (marks == null || marks.Length == 0)
        {
            Console.WriteLine("Коллекция пуста");
            return;
        }

        Console.WriteLine("Элементы коллекции:");
        for (int i = 0; i < marks.Length; i++)
        {
            if (marks[i] != null)
            {
                Console.WriteLine($"marks[{i}] = {marks[i].Show()}");
            }
            else
            {
                Console.WriteLine($"marks[{i}] = null");
            }
        }
        Console.WriteLine();
    }



    public int Length
    {
        get { return marks?.Length ?? 0; }
    }

    public Mark this[int index]
    {
        get
        {
            if (index < 0 || index >= marks.Length)
                throw new IndexOutOfRangeException();
            return marks[index];
        }
        set
        {
            if (index < 0 || index >= marks.Length)
                throw new IndexOutOfRangeException();
            marks[index] = value;
        }
    }
}