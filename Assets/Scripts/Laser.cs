using System.Collections.Generic;

using UnityEngine;


public class LaserScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject weaponsExecObject;
    public GameObject playerObject;

    private WeaponsExec weaponsExec;
    private Vector3 endpoint;


    void Start()
    {
        lineRenderer.useWorldSpace = true;
        weaponsExec = weaponsExecObject.GetComponent<WeaponsExec>();
    }

    void Update()
    {
        lineRenderer.enabled = weaponsExec.laser;

        if (weaponsExec.laser) {
            UpdatePosition();
            CheckHits();
        }
    }


    private void UpdatePosition()
    {
        Vector3 start = playerObject.transform.position;
        Vector3 delta = Utils.GetMousePosition() - start;
        delta.z = 0;
        float scale = Camera.main.orthographicSize * 2.1f;
        endpoint = start + delta.normalized * scale;

        lineRenderer.SetPositions(new Vector3[] { start, endpoint });
    }

    private void CheckHits()
    {
        List<RaycastHit2D> res = new();

        Physics2D.Linecast(
            (Vector2) playerObject.transform.position,
            this.endpoint,
            new ContactFilter2D().NoFilter(),
            res
        );

        foreach (RaycastHit2D hit in res)
        {
            var gameObject = hit.collider.gameObject;

            if (gameObject.name.Contains("Obstacle")) {
                gameObject.GetComponent<ObstacleScript>().Hit();
            }
        }
    }
}
