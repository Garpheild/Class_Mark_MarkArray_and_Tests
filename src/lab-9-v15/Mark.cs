namespace lab_9_v15;

public class Mark
{
    private string name = "Название предмета";
    private int mark = 0;
    static string[] markArray = new string[11] { "неудовлетворительно", "неудовлетворительно", "неудовлетворительно", "неудовлетворительно", "удовлетворительно", "удовлетворительно", "хорошо", "хорошо", "отлично", "отлично", "отлично" };
    public static int CollectionCount { get; private set; } = 0;

    public int Mark_
    {
        get { return mark; }
        set
        {
            if (value < 0 || value > 10) throw new Exception("Оценка должна быть от 0 до 10");
            mark = value;
        }
    }
    public string Name_
    {
        get { return name; }
        set 
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Имя не может быть null");

            if (value == string.Empty)
                throw new ArgumentException("Имя не может быть пустой строкой");

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Имя не может состоять только из пробелов");

            bool hasLetter = false;
            foreach (char c in value)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                    break;
                }
            }

            if (!hasLetter)
                throw new ArgumentException("Имя должно содержать хотя бы одну букву");

            name = value;
        }

    }
    public Mark()
    {
        string name = "Название предмета";
        int mark = 0;
        CollectionCount++;
    }
    public Mark(string name, int mark)
    {
        Name_ = name;
        Mark_ = mark;
        CollectionCount++;
    }
    public Mark(Mark mark)
    {
        Name_ = mark.name;
        Mark_ = mark.mark;
        CollectionCount++;
    }
    public string ToFivePointScale() => markArray[this.Mark_];
    public static string ToFivePointScale(Mark mark) => markArray[mark.Mark_];
    public static int CountObjects() => CollectionCount;
    public bool Equals(Mark mark) => mark.Name_ == this.Name_ && mark.Mark_ == this.Mark_;

    public static Mark operator !(Mark mark) => new Mark(mark.Name_.ToUpper(), mark.Mark_);
    public static Mark operator -(Mark mark) => new Mark(mark.Name_, 0);

    public static explicit operator int(Mark m)
    {
        int count = 0;
        foreach (char c in m.Name_)
            if (char.IsLetter(c))
                count++;
        return count;
    }

    public static implicit operator bool(Mark m) => m.Mark_ >= 4;

    public static Mark operator /(Mark m, string newName) => new Mark(newName, m.Mark_);

    public static bool operator >=(Mark m1, Mark m2) => m1.Mark_ >= m2.Mark_;

    public static bool operator <=(Mark m1, Mark m2) => m1.Mark_ <= m2.Mark_;

    public string Show() => $"{this.Name_}, {this.Mark_}";
}
