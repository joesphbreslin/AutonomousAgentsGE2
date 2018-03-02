using UnityEngine;

public class Seek : SteeringBehaviour {
    
    public GameObject targetGameObject = null;
    public Vector3 target = Vector3.zero;


    public void OnDrawGizmos()
    {
        if(isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            if (targetGameObject != null)
            {
                target = targetGameObject.transform.position;        
            }
            Gizmos.DrawLine(transform.position, target);
        }
    }

    public override Vector3 Calculate()
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= boid.maxSpeed;
        return desired - boid.velocity;
    }
 
    void Update () {
		if(targetGameObject != null)
        {
           
                target = targetGameObject.transform.position;
           
        }
	}
}
