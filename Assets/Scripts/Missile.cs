using UnityEngine;


public class MissileScript : MonoBehaviour
{
    public float missileSpeed;

    public Rigidbody2D rigidBody;


    void Start()
    {
        gameObject.transform.position += gameObject.transform.forward * 1;
    }

    void Update()
    {
        rigidBody.AddRelativeForce(new Vector2(0, missileSpeed));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Obstacle")) {
            collision.gameObject.GetComponent<ObstacleScript>().Hit();
            Destroy(gameObject);
        }
    }
}
