using System.Collections;
using MineSweeper;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayTester
{
    [UnityTest]
    public IEnumerator Test5By6PlayingField()
    {
        // Given
        GameObject go = new ();
        PlayingField field = go.AddComponent<PlayingField>();
        
        // When
        field.CreateGrid(5,6);
        yield return null;
        
        //Then
        Assert.NotNull(field.GetCellFromPosition(4,5));
    }
}
