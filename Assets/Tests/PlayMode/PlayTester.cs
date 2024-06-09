using System.Collections;
using UnityEngine.TestTools;

public class PlayTester
{
    [UnityTest]
    public IEnumerator PlayTesterWithEnumeratorPasses()
    {
        yield return null;
    }
}
