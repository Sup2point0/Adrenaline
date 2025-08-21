using UnityEngine;
using UnityEngine.InputSystem;


public class SceneExec : MonoBehaviour
{
    public GameObject cameraExecObject;
    public GameObject playerObject;
    public GameObject weaponsExecObject;
    public GameObject obstacleExecObject;

    [HideInInspector]
    public CameraExec cameraExec;

    [HideInInspector]
    public PlayerScript player;

    [HideInInspector]
    public WeaponsExec weaponsExec;

    [HideInInspector]
    public ObstacleExec obstacleExec;
    

    void Start()
    {
        cameraExec = cameraExecObject.GetComponent<CameraExec>();
        player = playerObject.GetComponent<PlayerScript>();
        weaponsExec = weaponsExecObject.GetComponent<WeaponsExec>();
        obstacleExec = obstacleExecObject.GetComponent<ObstacleExec>();
    }

    void Update()
    {
        
    }

    #region INPUT EVENTS

    void OnMove(InputValue value)
    {
        player.impetus = player.speedScale * value.Get<Vector2>();
    }

    void OnKapow()
    {
        obstacleExec.Spew();
    }

    void OnAimedMissiles()
    {
        weaponsExec.autofire = !weaponsExec.autofire;
    }

    void OnSpreadMissiles()
    {
        weaponsExec.FireSpreadMissiles();
    }

    void OnZoom(InputValue value)
    {
        var val = value.Get<float>();

        if (val > 0) {
            cameraExec.zoom = cameraExec.rootZoom + 20;
        } else {
            cameraExec.zoom = cameraExec.rootZoom;
        }
    }

    #endregion
}
