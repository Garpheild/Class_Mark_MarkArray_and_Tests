using lab_9_v15;

namespace UnitTests;

[TestClass]
public sealed class MarkArrayTests
{
    [TestMethod]
    public void TestMarkArrayDefaultConstructor()
    {
        // Arrange & Act
        MarkArray array = new MarkArray();

        // Assert
        Assert.IsNotNull(array);
        Assert.AreEqual(0, array.Length);
    }

    [TestMethod]
    public void TestMarkArrayParameterizedConstructor()
    {
        // Arrange & Act
        MarkArray array = new MarkArray(5);

        // Assert
        Assert.IsNotNull(array);
        Assert.AreEqual(5, array.Length);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestMarkArrayConstructor_NegativeSize_ThrowsException()
    {
        // Arrange & Act & Assert
        MarkArray array = new MarkArray(-1);
    }

    [TestMethod]
    public void TestMarkArrayCopyConstructor_DeepCopy()
    {
        // Arrange
        MarkArray original = new MarkArray(3);
        original[0] = new Mark("Математика", 8);
        original[1] = new Mark("Физика", 5);
        original[2] = new Mark("Химия", 3);

        // Act
        MarkArray copy = new MarkArray(original);

        // Assert
        Assert.AreEqual(original.Length, copy.Length);

        // Проверка глубокого копирования
        original[0] = new Mark("Измененный", 10);
        Assert.AreNotEqual(original[0]?.name, copy[0]?.name);
        Assert.AreEqual("Математика", copy[0]?.name);
    }

    [TestMethod]
    public void TestMarkArrayIndexer_GetAndSet()
    {
        // Arrange
        MarkArray array = new MarkArray(3);
        Mark m = new Mark("Тест", 7);

        // Act
        array[1] = m;

        // Assert
        Assert.AreEqual(m, array[1]);
        Assert.AreEqual("Тест", array[1]?.name);
        Assert.AreEqual(7, array[1]?.mark);
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestMarkArrayIndexer_GetOutOfRange_ThrowsException()
    {
        // Arrange
        MarkArray array = new MarkArray(3);

        // Act & Assert
        var temp = array[5];
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestMarkArrayIndexer_SetOutOfRange_ThrowsException()
    {
        // Arrange
        MarkArray array = new MarkArray(3);

        // Act & Assert
        array[5] = new Mark("Тест", 5);
    }

    [TestMethod]
    public void TestMarkArrayDisplay_EmptyArray()
    {
        // Arrange
        MarkArray array = new MarkArray();
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        array.Display();

        // Assert
        StringAssert.Contains(consoleOutput.ToString(), "Коллекция пуста");
    }

    [TestMethod]
    public void TestMarkArrayDisplay_WithElements()
    {
        // Arrange
        MarkArray array = new MarkArray(2);
        array[0] = new Mark("Предмет1", 8);
        array[1] = new Mark("Предмет2", 4);
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        array.Display();

        // Assert
        string output = consoleOutput.ToString();
        StringAssert.Contains(output, "Элементы коллекции:");
        StringAssert.Contains(output, "Предмет1, 8");
        StringAssert.Contains(output, "Предмет2, 4");
    }
}

