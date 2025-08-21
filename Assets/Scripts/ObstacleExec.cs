using UnityEngine;

public class ObstacleExec : MonoBehaviour
{
    [Header("Obstacles Configuration")]
    public int initialObstacles;
    public float maxSpread;
    
    [Header("Unity Configuration")]
    public GameObject obstaclePrefab;
    public GameObject player;

    private float tick = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spew();
    }

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;

        if (tick > 3) {
            Spawn();
            tick = 0;
        }
    }

    public void Spew()
    {
        for (int i = 0; i < initialObstacles; i++) {
            Spawn();
        }
    }

    private void Spawn()
    {
        float x = player.transform.position.x + maxSpread * (2 * Random.value - 1);
        float y = player.transform.position.y + maxSpread * (2 * Random.value - 1);
        var spawned = Instantiate(obstaclePrefab, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0));
    }
}
