using Parameter;
using Pathfinding;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FsmManager
{
    public class SuperSkeletonFsmManager : MonoBehaviour
    {
        private IState currentState;

        private Dictionary<SuperSkeletonST, IState> states = new Dictionary<SuperSkeletonST, IState>();

        public SuperSkeletonParameter parameter = new SuperSkeletonParameter();

        private Seeker seeker;

        public Pathfinding.Path path;

        public float nextWaypointDistance = 3;

        private int currentWaypoint = 0;


        void Start()
        {

            states.Add(SuperSkeletonST.Empty, new SuperSkeletonEmptyState(this));
            states.Add(SuperSkeletonST.Run, new SuperSkeletonRunState(this));
            states.Add(SuperSkeletonST.Idle, new SuperSkeletonIdleState(this));
            states.Add(SuperSkeletonST.Attack, new SuperSkeletonAttackState(this));

            InitializeData();

            TransitionState(SuperSkeletonST.Idle);

        }

        void Update()
        {

            parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;

            seeker.StartPath(parameter.transform.position, parameter.targetPos);
            if (path == null)
            {
                return;
            }
            if (currentWaypoint >= path.vectorPath.Count)
            {
                Debug.Log("路径搜索结束");
                return;
            }

            seeker.StartPath(parameter.transform.position, parameter.targetPos, OnPathComplete);

        }

        public void TransitionState(SuperSkeletonST type)
        {
            if (currentState == null)
            {
                currentState.OnExit();
            }

            currentState = states[type];

            currentState.OnEnter();

        }

        private void InitializeData()
        {
            DataManager.Instance.LoadAll();
            var data = DataManager.Instance.GetfasdffByID(1);
            parameter.currentHP = data.HP;
            parameter.ATK = data.ATK;
            parameter.speed = data.speed;
            parameter.speedMulti = data.speedMulti;

            parameter.transform = GetComponent<Transform>();
            parameter.animator = transform.Find("SuperSkeleton").GetComponent<Animator>();
            seeker = GetComponent<Seeker>();
            seeker.pathCallback += OnPathComplete;
        }

        private void OnPathComplete(Pathfinding.Path p)
        {
            if (!p.error)
            {
                path = p;
                currentWaypoint = 0;
            }
            Debug.Log("发现这个路线" + p.error);
        }

    }

}
