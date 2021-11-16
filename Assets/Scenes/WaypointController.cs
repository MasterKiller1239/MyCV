using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour {

    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the waypoint is less than this, then it has reacehd the waypoint
    private int lastWaypointIndex;

  
    private float rotationSpeed = 5.0f;
    public ParticleSystem smoke;


    // Settings
    public float movementSpeed = 5;
    public float maxSpeed = 10;



    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;

    // References
    public GameObject BodyPrefab;
    
    // Lists
    public List<GameObject> BodyParts = new List<GameObject>();
    private List<int> PositionsHistory = new List<int>();
    private List<Transform> targetWaypointS = new List<Transform>();
    public bool isMoving = false;
    // Use this for initialization
     AudioSource audioSource;
    void Start () {
        audioSource = GetComponent<AudioSource>();
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];
       

        foreach (var body in BodyParts)
        {
            PositionsHistory.Add(0);
            Transform newone = waypoints[targetWaypointIndex];
            targetWaypointS.Add(newone);
        }

    }
    public void SwitchMoving()
    {
        isMoving = !isMoving;
        audioSource.Play();
        if (isMoving)
            smoke.Play(true);
        else
            smoke.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
	
	// Update is called once per frame
	void Update () {
      
          
        if (isMoving == true)
        {
       
            float movementStep = movementSpeed * Time.deltaTime;
            float rotationStep = rotationSpeed * Time.deltaTime;

            Vector3 directionToTarget = targetWaypoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);


            float distance = Vector3.Distance(transform.position, targetWaypoint.position);
            CheckDistanceToWaypoint(distance);

            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
       
            // Move body parts
            int index = 0;
            foreach (var body in BodyParts)
            {
                float movementStepC = movementSpeed * Time.deltaTime;
                float rotationStepC = rotationSpeed * Time.deltaTime;

                Vector3 directionToTargetC = targetWaypointS[index].position - body.transform.position;
                Quaternion rotationToTargetC = Quaternion.LookRotation(directionToTargetC);

                body.transform.rotation = Quaternion.Slerp(body.transform.rotation, rotationToTargetC, rotationStep);


                float distancec = Vector3.Distance(body.transform.position, targetWaypointS[index].position);
                CheckDistanceToWaypointc(distancec,index);

                body.transform.position = Vector3.MoveTowards(body.transform.position, targetWaypointS[index].position, movementStep);
                index++;
            }
        }
  
          
	}

    /// <summary>
    /// Checks to see if the enemy is within distance of the waypoint. If it is, it called the UpdateTargetWaypoint function 
    /// </summary>
    /// <param name="currentDistance">The enemys current distance from the waypoint</param>
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if(currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }
    void CheckDistanceToWaypointc(float currentDistance,int index)
    {
        if (currentDistance <= minDistance)
        {
            PositionsHistory[index]++;
            UpdateTargetWaypoints(index);
        }
    }
    /// <summary>
    /// Increaes the index of the target waypoint. If the enemy has reached the last waypoint in the waypoints list, it resets the targetWaypointIndex to the first waypoint in the list (causes the enemy to loop)
    /// </summary>
    void UpdateTargetWaypoint()
    {
        if(targetWaypointIndex > lastWaypointIndex)
        {
           // targetWaypointIndex = waypoints.FindLast();
            isMoving = !isMoving;
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }
    void UpdateTargetWaypoints(int index)
    {
        if (PositionsHistory[index] > lastWaypointIndex)
        {
           // PositionsHistory[index] = 0;
            isMoving = !isMoving;
        }

        targetWaypointS[index] = waypoints[PositionsHistory[index]];
    }
    private void GrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        body.transform.position = this.transform.position;

        BodyParts.Add(body);
    }
}
