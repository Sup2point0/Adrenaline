using System.Collections;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [Header("Configuration")]
    public float speedScale = 1;

    [Header("Connections")]
    public Rigidbody2D rigidBody;

    [HideInInspector]
    public Vector2 impetus;


    #region UNITY

    void Start()
    {
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(impetus);
    }

    void Update()
    {
        transform.rotation = Utils.GetDirectionToMouse(source: transform.position);
    }

    #endregion


    #region INTERNAL

    IEnumerator AsyncPop()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(1, 1, 1);
    }

    #endregion
}
