using Parameter;
using Pathfinding;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FsmManager
{
    public class SuperFlyFsmManager : MonoBehaviour
    {
        public Vector3 center;
        private IState currentState;

        private Dictionary<SuperFlyST, IState> states = new Dictionary<SuperFlyST, IState>();

        public SuperFlyParameter parameter = new SuperFlyParameter();


        void Start()
        {
            GridGraph gridGraph = AstarPath.active.data.gridGraph;

            states.Add(SuperFlyST.Empty, new SuperFlyEmptyState(this));
            states.Add(SuperFlyST.Run, new SuperFlyRunState(this));
            states.Add(SuperFlyST.Idle, new SuperFlyIdleState(this));
            states.Add(SuperFlyST.Attack, new SuperFlyAttackState(this));

            InitializeData();

            gridGraph.center = center;

            AstarPath.active.Scan(gridGraph);

            TransitionState(SuperFlyST.Idle);

        }

        void Update()
        {

            if (parameter.currentHP < 0)
            {
                OnDestroy();
            }

            currentState.OnUpdate();
        }

        public void TransitionState(SuperFlyST type)
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
            var data = DataManager.Instance.GetfasdffByID(5);
            parameter.currentHP = data.HP;
            parameter.ATK = data.ATK;
            parameter.speed = data.speed;
            parameter.shootRate = data.shootRate;

            parameter.transform = GetComponent<Transform>();
            parameter.animator = transform.Find("SuperFly").GetComponent<Animator>();
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

