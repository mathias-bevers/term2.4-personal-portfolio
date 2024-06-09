using System.Collections;
using MineSweeper;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayTester
{
    [UnityTest]
    public IEnumerator PlayTesterWithEnumeratorPasses()
    {
        GameObject go = new ();
        PlayTest playTest = go.AddComponent<PlayTest>();
        
        yield return new WaitForSeconds(PlayTest.DELAY * 1.5f);
        Assert.AreEqual(10, playTest.value);
    }
}
