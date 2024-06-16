using System.Collections;
using MineSweeper;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;

public class RuntimeTester
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Test10By10PlayingField()
    {
        #region Given

        GameObject go = new(); // Create a new game objects
        PlayingField field = go.AddComponent<PlayingField>(); // Add a playing field instance to the game object. 

        #endregion

        #region When

        // Set the mine percentage to 20%.
        field.minePercentage = 20;
        // Create a new grid of 10 * 10;
        field.CreateGrid(10);
        // Skip a frame
        yield return null;

        // Get the top right cell.
        Cell cell = field.GetCellFromPosition(0, 0);
        // Simulate a right click on the cell if it exists.
        cell?.OnPointerClick(new PointerEventData(EventSystem.current) { button = PointerEventData.InputButton.Right });

        #endregion

        #region Then

        // The last cell should be 9,9 since the grid is 10 * 10.
        Assert.NotNull(field.GetCellFromPosition(9, 9)); 
        // There should be 20 mines since: 10 * 10 = 100 * 0.2 = 20.
        Assert.AreEqual(20, field.mineCount); 
        // The top right should be in the marked state.
        Assert.AreEqual(Cell.State.Marked, cell?.state);

        #endregion
    }
}