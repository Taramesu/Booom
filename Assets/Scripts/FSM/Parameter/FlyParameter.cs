
using Pathfinding;
using UnityEngine;

namespace Parameter
{
    public class FlyParameter
    {
        public float currentHP;

        public float ATK;

        public float speed;

        public float shootRate;

        public Seeker seeker;

        public Path path;

        public int currentWaypoint = 0;

        public Vector3 targetPos;

        public Animator animator;

        public Transform transform;
    }
}