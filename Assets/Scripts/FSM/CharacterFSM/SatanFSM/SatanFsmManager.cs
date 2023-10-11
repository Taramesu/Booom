using Parameter;
using Pathfinding;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FsmManager
{
    public class SatanFsmManager : MonoBehaviour
    {
        public Vector3 center;

        private IState currentState;

        private Dictionary<SatanST, IState> states = new Dictionary<SatanST, IState>();

        public SatanParameter parameter = new SatanParameter();

        void Start()
        {
            GridGraph gridGraph = AstarPath.active.data.gridGraph;

            states.Add(SatanST.Run, new SatanRunState(this));
            states.Add(SatanST.Idle, new SatanIdleState(this));
            states.Add(SatanST.Attack, new SatanAttackState(this));

            InitializeData();

            gridGraph.center = center;

            AstarPath.active.Scan(gridGraph);

            TransitionState(SatanST.Idle);

        }

        void Update()
        {

            currentState.OnUpdate();

        }

        public void TransitionState(SatanST type)
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
            var data = DataManager.Instance.GetfasdffByID(6);
            parameter.currentHP = data.HP;
            parameter.ATK = data.ATK;
            parameter.speed = data.speed;
            parameter.speedMulti = data.speedMulti;
            parameter.shootRate = data.shootRate;

            parameter.transform = GetComponent<Transform>();
            parameter.animator = transform.Find("satan").GetComponent<Animator>();
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
