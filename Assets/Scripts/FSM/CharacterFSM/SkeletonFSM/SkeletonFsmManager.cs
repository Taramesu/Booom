using Parameter;
using Pathfinding;
using StateType;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace FsmManager
{
    public class SkeletonFsmManager : MonoBehaviour
    {
        private IState currentState;

        private Dictionary<SkeletonST, IState> states = new Dictionary<SkeletonST, IState>();

        public SkeletonParameter parameter = new SkeletonParameter();

        private Seeker seeker;

        public Pathfinding.Path path;

        public float nextWaypointDistance = 3;
        
        private int currentWaypoint = 0;


        void Start()
        {

            states.Add(SkeletonST.Empty, new SkeletonEmptyState(this));
            states.Add(SkeletonST.Run, new SkeletonRunState(this));
            states.Add(SkeletonST.Idle, new SkeletonIdleState(this));
            states.Add(SkeletonST.Attack, new SkeletonAttackState(this));

            InitializeData();

            TransitionState(SkeletonST.Idle);

        }

        void Update()
        {

            parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;

            Debug.Log(parameter.transform.position - parameter.targetPos);

            seeker.StartPath(parameter.transform.position,parameter.targetPos);
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

        public void TransitionState(SkeletonST type)
        {
            if( currentState == null)
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
            parameter.animator = transform.Find("Skeleton").GetComponent<Animator>();
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