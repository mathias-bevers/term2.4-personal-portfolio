using System.Collections;
using System.Collections.Generic;
using MineSweeper;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RuntimeTester
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Test5By6PlayingField()
    {
        // Given
        GameObject go = new (); // Create a new game objects
        PlayingField field = go.AddComponent<PlayingField>(); // Add a playing field instance to the game object. 
            
        // When
        field.CreateGrid(new Vector2Int(5,6)); // Create a new grid of 5 * 6;
        yield return null; // Skip a frame
            
        // Then
        // Use the Assert class to test conditions.
        Assert.NotNull(field.GetCellFromPosition(4,5)); // The last cell from the array. 
        Assert.AreEqual(field.mineCount, 3); // 5 * 6 = 30 / 10 = 3.
    }
}
