namespace UnitTests;
using lab_9_v15;


[TestClass]
public sealed class MarkTests
{
    [TestMethod]
    public void TestDefaultConstructor()
    {
        // Arrange & Act
        Mark m = new Mark();

        // Assert
        Assert.AreEqual(string.Empty, m.Name_);
        Assert.AreEqual(0, m.Mark_);
    }

    [TestMethod]
    public void TestParameterizedConstructor()
    {
        // Arrange & Act
        Mark m = new Mark("Математика", 8);

        // Assert
        Assert.AreEqual("Математика", m.Name_);
        Assert.AreEqual(8, m.Mark_);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Должно быть исключение при оценке < 0")]
    public void TestParameterizedConstructor_NegativeMark_ThrowsException()
    {
        // Arrange & Act & Assert
        Mark m = new Mark("Физика", -5);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Должно быть исключение при оценке > 10")]
    public void TestParameterizedConstructor_MarkGreaterThan10_ThrowsException()
    {
        // Arrange & Act & Assert
        Mark m = new Mark("Физика", 15);
    }

    [TestMethod]
    public void TestMarkProperty_ValidValues()
    {
        // Arrange
        Mark m = new Mark("Тест", 5);

        // Act
        m.Mark_ = 9;

        // Assert
        Assert.AreEqual(9, m.Mark_);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestMarkProperty_NegativeValue_ThrowsException()
    {
        // Arrange
        Mark m = new Mark("Тест", 5);

        // Act & Assert
        m.Mark_ = -1;
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestMarkProperty_ValueGreaterThan10_ThrowsException()
    {
        // Arrange
        Mark m = new Mark("Тест", 5);

        // Act & Assert
        m.Mark_ = 11;
    }

    [TestMethod]
    public void TestToFivePointScale_InstanceMethod()
    {
        // Arrange
        Mark m1 = new Mark("Тест1", 3);
        Mark m2 = new Mark("Тест2", 5);
        Mark m3 = new Mark("Тест3", 7);
        Mark m4 = new Mark("Тест4", 9);
        Mark m5 = new Mark("Тест5", 10);

        // Act & Assert
        Assert.AreEqual("неудовлетворительно", m1.ToFivePointScale());
        Assert.AreEqual("удовлетворительно", m2.ToFivePointScale());
        Assert.AreEqual("хорошо", m3.ToFivePointScale());
        Assert.AreEqual("отлично", m4.ToFivePointScale());
        Assert.AreEqual("отлично", m5.ToFivePointScale());
    }

    [TestMethod]
    public void TestToFivePointScale_StaticMethod()
    {
        // Arrange
        Mark m1 = new Mark("Тест1", 2);
        Mark m2 = new Mark("Тест2", 6);

        // Act & Assert
        Assert.AreEqual("неудовлетворительно", Mark.ToFivePointScale(m1));
        Assert.AreEqual("хорошо", Mark.ToFivePointScale(m2));
    }

    [TestMethod]
    public void TestCountObjects()
    {
        // Arrange
        int initialCount = Mark.CollectionCount;

        // Act
        Mark m1 = new Mark();
        Mark m2 = new Mark("Тест", 5);

        // Assert
        Assert.AreEqual(initialCount + 2, Mark.CollectionCount);
        Assert.AreEqual(initialCount + 2, Mark.CountObjects());
    }

    [TestMethod]
    public void TestEquals()
    {
        // Arrange
        Mark m1 = new Mark("Предмет", 7);
        Mark m2 = new Mark("Предмет", 7);
        Mark m3 = new Mark("Другой", 7);
        Mark m4 = new Mark("Предмет", 4);

        // Act & Assert
        Assert.IsTrue(m1.Equals(m2));
        Assert.IsFalse(m1.Equals(m3));
        Assert.IsFalse(m1.Equals(m4));
    }

    [TestMethod]
    public void TestShow()
    {
        // Arrange
        Mark m = new Mark("Информатика", 8);

        // Act & Assert
        Assert.AreEqual("Информатика, 8", m.Show());
    }

    [TestMethod]
    public void TestNotOperator()
    {
        // Arrange
        Mark m = new Mark("математика", 6);

        // Act
        Mark result = !m;

        // Assert
        Assert.AreEqual("МАТЕМАТИКА", result.Name_);
        Assert.AreEqual(6, result.Mark_);
    }

    [TestMethod]
    public void TestUnaryMinusOperator()
    {
        // Arrange
        Mark m = new Mark("Физика", 8);

        // Act
        Mark result = -m;

        // Assert
        Assert.AreEqual("Физика", result.Name_);
        Assert.AreEqual(0, result.Mark_);
    }

    [TestMethod]
    public void TestDivisionOperator()
    {
        // Arrange
        Mark m = new Mark("СтароеИмя", 5);

        // Act
        Mark result = m / "НовоеИмя";

        // Assert
        Assert.AreEqual("НовоеИмя", result.Name_);
        Assert.AreEqual(5, result.Mark_);
    }

    [TestMethod]
    public void TestExplicitIntConversion()
    {
        // Arrange
        Mark m1 = new Mark("C# Programming", 8);
        Mark m2 = new Mark("123 Test 456", 5);
        Mark m3 = new Mark("", 3);

        // Act
        int count1 = (int)m1;
        int count2 = (int)m2;
        int count3 = (int)m3;

        // Assert
        Assert.AreEqual(12, count1); 
        Assert.AreEqual(4, count2); 
        Assert.AreEqual(0, count3); 
    }

    [TestMethod]
    public void TestImplicitBoolConversion()
    {
        // Arrange
        Mark passing1 = new Mark("Тест1", 4);
        Mark passing2 = new Mark("Тест2", 7);
        Mark failing1 = new Mark("Тест3", 3);
        Mark failing2 = new Mark("Тест4", 0);

        // Act & Assert
        Assert.IsTrue(passing1);
        Assert.IsTrue(passing2);
        Assert.IsFalse(failing1);
        Assert.IsFalse(failing2);
    }

    [TestMethod]
    public void TestGreaterOrEqualOperator()
    {
        // Arrange
        Mark m1 = new Mark("Предмет1", 7);
        Mark m2 = new Mark("Предмет2", 7);
        Mark m3 = new Mark("Предмет3", 4);
        Mark m4 = new Mark("Предмет4", 9);

        // Act & Assert
        Assert.IsTrue(m1 >= m2);
        Assert.IsTrue(m1 >= m3);
        Assert.IsFalse(m3 >= m1);
        Assert.IsTrue(m1 >= m1); 
    }

    [TestMethod]
    public void TestLessOrEqualOperator()
    {
        // Arrange
        Mark m1 = new Mark("Предмет1", 7);
        Mark m2 = new Mark("Предмет2", 7);
        Mark m3 = new Mark("Предмет3", 4);
        Mark m4 = new Mark("Предмет4", 9);

        // Act & Assert
        Assert.IsTrue(m1 <= m2);
        Assert.IsTrue(m3 <= m1);
        Assert.IsFalse(m4 <= m1);
        Assert.IsTrue(m1 <= m1); 
    }

    [TestMethod]
    public void TestAllFivePointMarks()
    {
        // Arrange
        string[] expected = {
            "неудовлетворительно",
            "неудовлетворительно",
            "неудовлетворительно",
            "неудовлетворительно",
            "удовлетворительно",
            "удовлетворительно",
            "хорошо",
            "хорошо",
            "отлично",
            "отлично",
            "отлично"
        };

        // Act & Assert
        for (int i = 0; i <= 10; i++)
        {
            Mark m = new Mark($"Тест{i}", i);
            Assert.AreEqual(expected[i], m.ToFivePointScale());
        }
    }
}

