using UnityEngine;
 


/// <summary>
/// Found this code on the unity forums: https://forum.unity.com/threads/calculate-orthographic-size.454478/
/// </summary>
[ExecuteInEditMode]
public class CameraSizeFit : MonoBehaviour
{
    public Vector2 minSize = new Vector2(10, 5);
    public bool fitToObject;
    public bool lookAt;
    public GameObject fitObject;
 
    private Camera cam;
    private new Transform transform;
 
    void Awake ()
    {
        cam = GetComponent<Camera>();
        transform = GetComponent<Transform>();
    }
 
    void Update ()
    {
        if (lookAt && fitObject)
            transform.LookAt(fitObject.transform.position);
 
        var minSize = EvaluateSize();
        cam.orthographicSize = CalculateOrtographicSize(minSize);
    }
 
 
    private Vector2 EvaluateSize()
    {
        Vector2 size = minSize;
 
        if (fitToObject && fitObject) {
            Bounds bounds;
            if (FetchObjectBounds(fitObject, out bounds)) {
                CalculateSizeFromBounds(bounds, ref size);
            }
        }
 
        return size;
    }
 
 
    private float CalculateOrtographicSize(Vector2 size)
    {
        float aspect = Screen.width / (float)Screen.height; // not using cam.aspect because it is not always updated immediately
        float height = size.x / aspect;
        if (height < size.y) height = size.y;
        return height / 2;
    }
 
 
    // returns false if object bounds could not be determined
    private bool FetchObjectBounds(GameObject obj, out Bounds bounds)
    {
        var renderer = obj.GetComponent<Renderer>();
        if (renderer) {
            bounds = renderer.bounds;
            return true;
        }
 
        var collider = obj.GetComponent<Collider>();
        if (collider) {
            bounds = collider.bounds;
            return true;
        }
 
        bounds = new Bounds();
        return false;
    }
 
 
    // returns false if calculated size was not valid
    private bool CalculateSizeFromBounds(Bounds bounds, ref Vector2 size)
    {
        bounds = TransformBounds(bounds);
        if (bounds.size.x > float.Epsilon && bounds.size.y > float.Epsilon) {
            size = bounds.size;
            return true;
        }
        return false;
    }
 
 
    private static Vector3[] extentPoints = new Vector3[8]; // array reused by TransformBounds method, don't do this in a multithreaded application
 
    private Bounds TransformBounds(Bounds bounds)
    {
        Vector3 cen = bounds.center;
        Vector3 ext = bounds.extents;
        extentPoints[0] = transform.InverseTransformPoint(new Vector3(cen.x - ext.x, cen.y - ext.y, cen.z - ext.z));
        extentPoints[1] = transform.InverseTransformPoint(new Vector3(cen.x + ext.x, cen.y - ext.y, cen.z - ext.z));
        extentPoints[2] = transform.InverseTransformPoint(new Vector3(cen.x - ext.x, cen.y - ext.y, cen.z + ext.z));
        extentPoints[3] = transform.InverseTransformPoint(new Vector3(cen.x + ext.x, cen.y - ext.y, cen.z + ext.z));
        extentPoints[4] = transform.InverseTransformPoint(new Vector3(cen.x - ext.x, cen.y + ext.y, cen.z - ext.z));
        extentPoints[5] = transform.InverseTransformPoint(new Vector3(cen.x + ext.x, cen.y + ext.y, cen.z - ext.z));
        extentPoints[6] = transform.InverseTransformPoint(new Vector3(cen.x - ext.x, cen.y + ext.y, cen.z + ext.z));
        extentPoints[7] = transform.InverseTransformPoint(new Vector3(cen.x + ext.x, cen.y + ext.y, cen.z + ext.z));
 
        Vector3 min = extentPoints[0];
        Vector3 max = extentPoints[0];
        foreach (Vector3 v in extentPoints) {
            min = Vector3.Min(min, v);
            max = Vector3.Max(max, v);
        }
 
        bounds.SetMinMax(min, max);
        return bounds;
    }
 
}