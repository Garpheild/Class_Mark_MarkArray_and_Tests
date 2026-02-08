namespace lab_9_v15;

public class Mark
{
    public string name = string.Empty;
    public int mark = 0;
    static string[] markArray = new string[11] { "неудовлетворительно", "неудовлетворительно", "неудовлетворительно", "неудовлетворительно", "удовлетворительно", "удовлетворительно", "хорошо", "хорошо", "отлично", "отлично", "отлично" };
    public static int CollectionCount { get; private set; } = 0;

    public int Mark_
    {
        get { return mark; }
        set
        {
            if (value < 0 || value > 10) throw new Exception("ОШИБКА!!! ОЦЕНКА МЕНЬШЕ НУЛЯ!!!!!!!");
            mark = value;
        }
    }
    public Mark()
    {
        string name = string.Empty;
        int mark = 0;
        CollectionCount++;
    }
    public Mark(string name, int mark)
    {
        this.name = name;
        Mark_ = mark;
        CollectionCount++;
    }
    public Mark(Mark mark)
    {
        this.name = mark.name;
        Mark_ = mark.mark;
        CollectionCount++;
    }
    public string ToFivePointScale() => markArray[this.mark];
    public static string ToFivePointScale(Mark mark) => markArray[mark.mark];
    public static int CountObjects() => CollectionCount;
    public bool Equals(Mark mark) => mark.name == this.name && mark.mark == this.mark;

    public static Mark operator !(Mark mark) => new Mark(mark.name.ToUpper(), mark.mark);
    public static Mark operator -(Mark mark) => new Mark(mark.name, 0);

    public static explicit operator int(Mark m)
    {
        int count = 0;
        foreach (char c in m.name)
            if (char.IsLetter(c))
                count++;
        return count;
    }

    public static implicit operator bool(Mark m) => m.mark >= 4;

    public static Mark operator /(Mark m, string newName) => new Mark(newName, m.mark);

    public static bool operator >=(Mark m1, Mark m2) => m1.mark >= m2.mark;

    public static bool operator <=(Mark m1, Mark m2) => m1.mark <= m2.mark;

    public string Show() => $"{this.name}, {this.mark}";
}
