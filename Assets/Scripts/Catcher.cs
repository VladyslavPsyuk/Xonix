using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            collision.transform.position = new Vector3(10f, 0, 10f);
        }
    }
}
