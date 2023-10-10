using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FsmManager
{
    public class SuperFlyFsmManager : MonoBehaviour
    {
        private IState currentState;

        private Dictionary<SuperFlyST, IState> states = new Dictionary<SuperFlyST, IState>();

        public SuperFlyParameter parameter = new SuperFlyParameter();


        void Start()
        {

            states.Add(SuperFlyST.Empty, new SuperFlyEmptyState(this));
            states.Add(SuperFlyST.Run, new SuperFlyRunState(this));
            states.Add(SuperFlyST.Idle, new SuperFlyIdleState(this));
            states.Add(SuperFlyST.Attack, new SuperFlyAttackState(this));

        }

        void Update()
        {
            currentState.OnUpdate();
        }

        public void TransitionState(SuperFlyST type)
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

