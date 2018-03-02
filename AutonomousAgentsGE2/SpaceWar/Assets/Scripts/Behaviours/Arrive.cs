using UnityEngine;

public class Arrive : SteeringBehaviour {

    public Vector3 targetPosition = Vector3.zero;
    public float slowingDistance = 15.0f;
    [HideInInspector]

    [Range(0.0f, 1.0f)]
    public float deceleration = 0.9f;

    public GameObject targetGameObject = null;

    public override Vector3 Calculate()
    {

        Vector3 toTarget = targetPosition - transform.position;
        float distance = toTarget.magnitude;
        if (distance == 0f)
        {
            return Vector3.zero;
        }
        float rampedSpeed = boid.maxSpeed * (distance / slowingDistance * deceleration);
        float clamped = Mathf.Min(rampedSpeed, boid.maxSpeed);
        Vector3 desired = clamped * (toTarget / distance);
        return desired - boid.velocity;   
    }

    // Update is called once per frame
    void Update () {
		if(targetGameObject != null)
        {
            targetPosition = targetGameObject.transform.position;
        }
	}
}
