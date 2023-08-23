using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float returnTime;
    public float followSpeed;
    public float length;

    public Transform target;

    public bool hasTarget {get {return target != null; }}

    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
        target = null;    
    }

    // Update is called once per frame
    void Update()
    {
        if(hasTarget){
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPos = target.position + (targetToCameraDirection * length);

            transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTransform, float targetLength){
        
        StopAllCoroutines();
        
        target = targetTransform;
        length = targetLength;
    }

    public void BackToDefault(){
        StopAllCoroutines();
      
        target = null;

        StartCoroutine(MovePosition(defaultPos, 5));
    }

    private IEnumerator MovePosition(Vector3 target, float time){
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time){
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer/time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
