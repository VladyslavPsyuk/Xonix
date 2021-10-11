using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Transform startPoint;
    public Transform endPoint;
    public AnimationCurve animationCurve;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move(startPoint.position, endPoint.position, animationCurve, 3.0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position = target.position + offset;
    }
    IEnumerator Move(Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time)
    {
        float timer = 0.0f;
        while (timer <= time)
        {
            transform.position = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            offset = transform.position - target.transform.position;
            yield return null;
        }
    }
}
