using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
       
        float distanceTravelled;

        // Settings
        public float MoveSpeed = 5;
        public float SteerSpeed = 180;
        public float BodySpeed = 5;
        public int Gap = 10;

        // References
        public GameObject BodyPrefab;

        // Lists
        public List<GameObject> BodyParts = new List<GameObject>();
        private List<Vector3> PositionsHistory = new List<Vector3>();
        public bool isMoving= false;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
            //GrowSnake();
            //GrowSnake();
            //GrowSnake();
            //GrowSnake();
            //GrowSnake();
        }

        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
                isMoving = !isMoving;
            if (pathCreator != null)
            {
                if (isMoving == true)
                {
                    distanceTravelled += MoveSpeed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

                // Store position history
                PositionsHistory.Insert(0, transform.position);
                // Move body parts
                int index = 0;
                foreach (var body in BodyParts)
                {
                    Vector3 point = PositionsHistory[Mathf.Clamp((index+1) * Gap, 0, PositionsHistory.Count - 1)];

                    // Move body towards the point along the snakes path
                    Vector3 moveDirection = point - body.transform.position;
                    body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

                    // Rotate body towards the point along the snakes path
                    body.transform.LookAt(point);

                    index++;
                    }
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
        private void GrowSnake()
        {
            // Instantiate body instance and
            // add it to the list
            GameObject body = Instantiate(BodyPrefab);

            BodyParts.Add(body);
        }
    }
}