using UnityEngine;


public static partial class Utils
{
    public static Quaternion GetDirectionToMouse(Vector3 source)
    {
        Vector3 camera_position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, source.z)
        );
        Vector3 delta = camera_position - source;
        float rot = 180 * Mathf.Atan2(delta.y, delta.x) / Mathf.PI - 90;
        
        return Quaternion.Euler(0, 0, rot);
    }
}
