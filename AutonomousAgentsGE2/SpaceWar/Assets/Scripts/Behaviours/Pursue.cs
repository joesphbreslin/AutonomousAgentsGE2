using UnityEngine;

public class Pursue : SteeringBehaviour {

    public Boid target;
    Vector3 targetPos;

    public void OnDrawGizmos()
    {
        if(isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, targetPos);
        }
    }
 
    public override Vector3 Calculate()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        float time = dist / boid.maxSpeed;
        targetPos = target.transform.position + (time * target.velocity);
        Vector3 desired = targetPos - transform.position;
        desired.Normalize();
        desired *= boid.maxSpeed;
        return desired - boid.velocity;

    }
}
