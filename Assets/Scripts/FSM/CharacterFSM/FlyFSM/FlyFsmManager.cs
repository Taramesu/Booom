using Parameter;
using Pathfinding;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FsmManager
{
    public class FlyFsmManager : MonoBehaviour
    {
        public Vector3 center;
        private IState currentState;

        private Dictionary<FlyST, IState> states = new Dictionary<FlyST, IState>();

        public FlyParameter parameter = new FlyParameter();


        void Start()
        {
            GridGraph gridGraph = AstarPath.active.data.gridGraph;

            states.Add(FlyST.Empty, new FlyEmptyState(this));
            states.Add(FlyST.Run, new FlyRunState(this));
            states.Add(FlyST.Idle, new FlyIdleState(this));
            states.Add(FlyST.Attack, new FlyAttackState(this));

            InitializeData();

            gridGraph.center = center;

            AstarPath.active.Scan(gridGraph);

            TransitionState(FlyST.Idle);

        }

        void Update()
        {

            if(parameter.currentHP < 0)
            {
                OnDestroy();
            }

            currentState.OnUpdate();

        }

        public void TransitionState(FlyST type)
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
            var data = DataManager.Instance.GetfasdffByID(2);
            parameter.currentHP = data.HP;
            parameter.ATK = data.ATK;
            parameter.speed = data.speed;
            parameter.shootRate = data.shootRate;

            parameter.transform = GetComponent<Transform>();
            parameter.animator = transform.Find("Fly").GetComponent<Animator>();
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
