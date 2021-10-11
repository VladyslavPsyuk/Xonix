using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increase : MonoBehaviour
{
    public AnimationCurve animationCurve;
 
    // Start is called before the first frame update
    void Start()
    {
        var pos1 = new Vector3(transform.position.x, transform.position.y-0.6f, transform.position.z);
        var pos2 = new Vector3(transform.position.x, transform.position.y-0.1f, transform.position.z);
       
            StartCoroutine(Move(pos1, pos2, animationCurve, 1.0f));
    }

    // Update is called once per frame

    IEnumerator Move(Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time)
    {
        float timer = 0.0f;
        while (timer <= time)
        {
            transform.position = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
