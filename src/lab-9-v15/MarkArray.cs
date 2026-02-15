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

    public MarkArray(int size, int minMark, int maxMark)
    {
        if (size <= 0)
            throw new ArgumentException("Размер должен быть положительным числом");
        marks = new Mark[size];
        Random random = new Random();
        string[] subjects = {
                "Алгебра", "Физика", "Химия", "Биология",
                "История", "Литература", "Информатика", "Английский",
                "География", "Физкультура"
            };

        for (int i = 0; i < size; i++)
        {
            string subject = subjects[random.Next(subjects.Length)];
            int mark = random.Next(minMark, maxMark+1);
            marks[i] = new Mark(subject, mark);
        }
        CollectionCount++;
    }

    public MarkArray(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Размер должен быть положительным числом");

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
    public string Display()
    {
        string s = "";
        if (marks == null || marks.Length == 0)
        {
            s += ("Коллекция пуста");
            return s;
        }

        for (int i = 0; i < marks.Length; i++)
        {
            if (marks[i] != null)
            {
                s += ($"marks[{i}] = {marks[i].Show()}\n");
            }
        }
        return s;
    }

    public int Length
    {
        get { return marks.Length; }
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
