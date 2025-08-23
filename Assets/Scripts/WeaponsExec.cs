using UnityEngine;


public class WeaponsExec : MonoBehaviour
{
    public float autofireCooldown;
    public float fireSpread;
    public int missilesCount = 1;
    public int spreadMissilesCount;

    public GameObject player;
    public GameObject missilePrefab;

    [HideInInspector]
    public bool autofire = false;
    public bool laser = false;

    private float fire_tick = 0;


    void Start()
    {
    }

    void Update()
    {
        if (!autofire) return;

        fire_tick += Time.deltaTime;

        if (fire_tick > autofireCooldown) {
            fire_tick -= autofireCooldown;
            transform.rotation = Utils.GetDirectionToMouse(source: player.transform.position);
            for (int i = 0; i < missilesCount; i++) {
                Instantiate(missilePrefab, player.transform.position, transform.rotation);
                transform.Rotate(new Vector3(0, 0, Random.Range(-fireSpread, fireSpread)));
            }
        }
    }

    public void FireSpreadMissiles()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(1, 360)));
        
        for (int i = 0; i < spreadMissilesCount; i++) {
            transform.Rotate(new Vector3(0, 0, 360 / spreadMissilesCount));
            Instantiate(missilePrefab, player.transform.position, transform.rotation);
        }
    }
}
