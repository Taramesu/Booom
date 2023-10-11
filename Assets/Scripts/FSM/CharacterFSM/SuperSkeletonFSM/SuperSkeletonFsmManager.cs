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
        public Vector3 center;

        private IState currentState;

        private Dictionary<SuperSkeletonST, IState> states = new Dictionary<SuperSkeletonST, IState>();

        public SuperSkeletonParameter parameter = new SuperSkeletonParameter();

        void Start()
        {
            GridGraph gridGraph = AstarPath.active.data.gridGraph;

            states.Add(SuperSkeletonST.Empty, new SuperSkeletonEmptyState(this));
            states.Add(SuperSkeletonST.Run, new SuperSkeletonRunState(this));
            states.Add(SuperSkeletonST.Idle, new SuperSkeletonIdleState(this));
            states.Add(SuperSkeletonST.Attack, new SuperSkeletonAttackState(this));

            InitializeData();

            gridGraph.center = center;

            AstarPath.active.Scan(gridGraph);

            TransitionState(SuperSkeletonST.Idle);

        }

        void Update()
        {

            currentState.OnUpdate();

        }

        public void TransitionState(SuperSkeletonST type)
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }

            currentState = states[type];

            currentState.OnEnter();

        }

        private void InitializeData()
        {
            DataManager.Instance.LoadAll();
            var data = DataManager.Instance.GetfasdffByID(4);
            parameter.currentHP = data.HP;
            parameter.ATK = data.ATK;
            parameter.speed = data.speed;
            parameter.speedMulti = data.speedMulti;

            parameter.transform = GetComponent<Transform>();
            parameter.animator = transform.Find("SuperSkeleton").GetComponent<Animator>();
            parameter.seeker = GetComponent<Seeker>();
            parameter.seeker.pathCallback += OnPathComplete;
        }

        private void OnPathComplete(Pathfinding.Path p)
        {
            if (!p.error)
            {
                parameter.path = p;
                parameter.currentWaypoint = 0;
            }
        }

        public void GetDamege(int damege)
        {
            parameter.currentHP -= damege;
        }

    }

}
