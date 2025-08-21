using UnityEngine;


public class ObstacleScript : MonoBehaviour
{
    [Header("Configuration")]
    public int maxInitialHealth;
    public float rootScale;
    public float healthScale;

    [Header("Connections")]
    public Rigidbody2D rigidBody;

    [Header("State")]
    public int health;

    private float root_scale;
    private float scale {
        get => root_scale + (root_scale * health * healthScale);
    }

    private SpriteRenderer sprite_renderer;

    private bool collided = false;


    void Start()
    {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        gameObject.transform.localScale = Vector3.zero;

        health = Random.Range(1, maxInitialHealth);
        root_scale = rootScale;
    }

    void FixedUpdate()
    {
        var delta = new Vector3(scale, scale, scale) - gameObject.transform.localScale;
        gameObject.transform.localScale += delta / 4;

        rigidBody.mass = health / 2;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Obstacle")) {
            sprite_renderer.color = Color.magenta;
        } else {
            Hit();
        }
    }

    public void Hit()
    {
        if (sprite_renderer is null) return;
        
        health--;
        if (health < 1) {
            Destroy(gameObject);
        }

        if (collided) {
            sprite_renderer.color = Color.yellow;
        } else {
            sprite_renderer.color = Color.green;
            collided = true;
        }

        gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }
}
