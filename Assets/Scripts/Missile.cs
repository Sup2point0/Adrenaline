using UnityEngine;


public class MissileScript : MonoBehaviour
{
    public float missileSpeed;
    public float recoil;

    public Rigidbody2D rigidBody;
    public GameObject trailPrefab;

    private GameObject trail;


    void Start()
    {
        transform.position += transform.forward * 1;

        var dir = Mathf.PI * (transform.rotation.eulerAngles.z + 90) / 180;
        GameObject.FindWithTag("Player")
            .GetComponent<Rigidbody2D>()
            .AddForce(recoil * new Vector2(Mathf.Cos(dir), Mathf.Sin(dir)));

        trail = Instantiate(trailPrefab);
        trail.transform.position = transform.position;
    }

    void FixedUpdate()
    {
        rigidBody.AddRelativeForce(new Vector2(0, missileSpeed));
        trail.transform.position = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Obstacle")) {
            Destroy(gameObject);
            Destroy(trail);
            collision.gameObject.GetComponent<ObstacleScript>().Hit();
        }
    }
}
