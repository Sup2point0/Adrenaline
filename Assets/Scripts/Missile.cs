using UnityEngine;


public class MissileScript : MonoBehaviour
{
    public float missileSpeed;

    public Rigidbody2D rigidBody;
    public GameObject trailPrefab;

    private GameObject trail;


    void Start()
    {
        gameObject.transform.position += gameObject.transform.forward * 1;

        var player = GameObject.FindWithTag("Player");
        player.GetComponent<Rigidbody2D>().AddRelativeForceY(-25);

        trail = Instantiate(trailPrefab);
        trail.transform.position = gameObject.transform.position;
    }

    void FixedUpdate()
    {
        rigidBody.AddRelativeForce(new Vector2(0, missileSpeed));
        trail.transform.position = gameObject.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Obstacle")) {
            collision.gameObject.GetComponent<ObstacleScript>().Hit();
            Destroy(gameObject);
            Destroy(trail);
        }
    }
}
