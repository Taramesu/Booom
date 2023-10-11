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
        public Vector3 center;

        private IState currentState;

        private Dictionary<SkeletonST, IState> states = new Dictionary<SkeletonST, IState>();

        public SkeletonParameter parameter = new SkeletonParameter();



        void Start()
        {
            GridGraph gridGraph = AstarPath.active.data.gridGraph;

            states.Add(SkeletonST.Empty, new SkeletonEmptyState(this));
            states.Add(SkeletonST.Run, new SkeletonRunState(this));
            states.Add(SkeletonST.Idle, new SkeletonIdleState(this));
            states.Add(SkeletonST.Attack, new SkeletonAttackState(this));

            InitializeData();

            gridGraph.center = center;

            AstarPath.active.Scan(gridGraph);

            TransitionState(SkeletonST.Idle);

        }

        void Update()
        {

            if (parameter.currentHP < 0)
            {
                OnDestroy();
            }

            currentState.OnUpdate();
            //seeker.StartPath(parameter.transform.position, parameter.targetPos, OnPathComplete);

        }

        public void TransitionState(SkeletonST type)
        {
            if( currentState != null)
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

        public void GetDamage(float damage)
        {
            parameter.currentHP -= damage;
            Debug.Log(parameter.currentHP);
        }

        public void OnDestroy()
        {

            MonsterGenerator.Instance.monsterList.Remove(gameObject);
            GameObject.Destroy(gameObject);

        }

    }

}