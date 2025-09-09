using UnityEngine;


public class CameraExec : MonoBehaviour
{
    public GameObject player;

    public float rootZoom;
    public float zoomScale;

    [HideInInspector]
    public float zoom;


    void Start()
    {
        zoom = rootZoom;
    }

    void LateUpdate()
    {
        {
            Vector3 delta = player.transform.position - transform.position;
            delta.z = 0;
            transform.position += delta / 32;
        } {
            var z = zoom + zoomScale * player.GetComponent<Rigidbody2D>().linearVelocity.magnitude;
            float delta = z - gameObject.GetComponent<Camera>().orthographicSize;
            gameObject.GetComponent<Camera>().orthographicSize += delta / 32;
        }
    }
}
