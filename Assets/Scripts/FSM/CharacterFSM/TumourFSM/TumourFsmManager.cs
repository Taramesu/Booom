using Parameter;
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
            states.Add(TumourST.Attack, new TumourAttackState(this));

        }

        void Update()
        {
            currentState.OnUpdate();
        }

        public void TransitionState(TumourST type)
        {
            if (currentState == null)
            {
                currentState.OnExit();
            }

            currentState = states[type];

            currentState.OnEnter();

        }
    }
}
