using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public float enemySpeed;
    public GameObject Player;
    Rigidbody rb;
    private const float SPEED = 6f;
    private Vector3 direction;
    Vector3 latestVelocity;

    public Camera cameraViev1;
    public Camera cameraViev2;
    public void Start()
    {
        direction = RandomVector(-2f, 2f);
    }
    private void Update()
    {
        transform.position += direction * SPEED * Time.deltaTime;
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = UnityEngine.Random.Range(min, max);
        var y = 0;
        var z = UnityEngine.Random.Range(min, max);

        return new Vector3(x, y, z);
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            var globalPositionOfContact = collision.contacts[0];
            var curDir = transform.TransformDirection(Vector3.forward);
            direction = Vector3.Reflect(curDir, globalPositionOfContact.normal);
           
        }

        if (collision.gameObject.name == "Player")
        {
            Player.transform.position = new Vector3(1f, 1f, 1f);
        }
    }
}
