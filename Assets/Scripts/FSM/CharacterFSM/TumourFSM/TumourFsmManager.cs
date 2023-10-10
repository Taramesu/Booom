using Parameter;
using Pathfinding;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FsmManager
{
    public class TumourFsmManager : MonoBehaviour
    {
        private IState currentState;

        private Dictionary<TumourST, IState> states = new Dictionary<TumourST, IState>();

        public TumourParameter parameter = new TumourParameter();


        void Start()
        {

            states.Add(TumourST.Empty, new TumourEmptyState(this));
            states.Add(TumourST.Run, new TumourRunState(this));
            states.Add(TumourST.Idle, new TumourIdleState(this));
            states.Add(TumourST.Boom, new TumourBoomState(this));

            InitializeData();

            TransitionState(TumourST.Idle);

        }

        void Update()
        {
            currentState.OnUpdate();
        }

        public void TransitionState(TumourST type)
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
            var data = DataManager.Instance.GetfasdffByID(3);
            parameter.currentHP = data.HP;
            parameter.ATK = data.ATK;
            parameter.speed = data.speed;
            parameter.criticalMulti = data.criticalMulti;

            parameter.transform = GetComponent<Transform>();
            parameter.animator = transform.Find("Tumour").GetComponent<Animator>();
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

        public void OnDestroy()
        {
            GameObject.Destroy(gameObject);
        }

    }
}
