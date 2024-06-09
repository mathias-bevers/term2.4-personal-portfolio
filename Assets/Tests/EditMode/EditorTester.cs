using MineSweeper;
using NUnit.Framework;

public class EditorTester
{
    [Test]
    public void TestEditorValue()
    {
        Assert.AreEqual(10, EditorTest.EDITOR_TEST);
    }
}