using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parameter
{
    //С��Skeleton����
    public class SkeletonParameter
    {
        public float currentHP;

        public float ATK;

        public float speed;

        public float speedMulti;

        public Seeker seeker;

        public Path path;

        public int currentWaypoint = 0;

        public Direction direction;

        public Vector3 targetPos;

        public Animator animator;

        public Transform transform;
    }
}

