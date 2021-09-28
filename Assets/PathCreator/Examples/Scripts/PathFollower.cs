using System.Collections;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;

        public bool playPath = false;
        public bool closedLoop = true;
        public bool useSoundEffect = true;

        float numPaths = 1;
        TrailRenderer trailRenderer; 

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            trailRenderer = GetComponent<TrailRenderer>();
        }

        void Update()
        {
            if (pathCreator != null && playPath)
            {
                distanceTravelled += speed * Time.deltaTime;

                // This conditional ensures the trail renderer does not show coming back around when it is a closed loop
                if (closedLoop)
                {
                    if (distanceTravelled / numPaths >= pathCreator.path.length)
                    {
                        numPaths++;

                        trailRenderer.emitting = false;
                        trailRenderer.time = 0;
                    }
                    else
                    {
                        trailRenderer.emitting = true;
                        trailRenderer.time = 5;
                    }
                }

                if (useSoundEffect)
                {
                    GetComponent<AudioSource>().enabled = true;
                }

                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
            else if (!playPath)
            {
                trailRenderer.emitting = false;
                trailRenderer.time = 0;

                if (useSoundEffect)
                {
                    GetComponent<AudioSource>().enabled = false;
                }
            }
        }


        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}