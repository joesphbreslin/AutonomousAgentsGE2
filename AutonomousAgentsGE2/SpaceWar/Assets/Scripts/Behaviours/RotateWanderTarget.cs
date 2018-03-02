using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWanderTarget : MonoBehaviour {

    public float frequency = 5;
    Quaternion rotTarget = Quaternion.identity;

    void Start()
    {
        StartCoroutine(CallRotation());
    }

    IEnumerator CallRotation()
    {
        RotateObject();
        yield return new WaitForSeconds(frequency);
        StartCoroutine(CallRotation());
    }
    void RotateObject()
    {
        rotTarget.eulerAngles = GetEulerAngle();
        transform.rotation = rotTarget;
    }

    Vector3 GetEulerAngle()
    {
        Vector3 desired = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        return desired;
    }
}
