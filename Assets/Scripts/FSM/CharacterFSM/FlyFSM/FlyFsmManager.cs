using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FsmManager
{
    public class FlyFsmManager : MonoBehaviour
    {
        private IState currentState;

        private Dictionary<FlyST, IState> states = new Dictionary<FlyST, IState>();

        public FlyParameter parameter = new FlyParameter();


        void Start()
        {

            states.Add(FlyST.Empty, new FlyEmptyState(this));
            states.Add(FlyST.Run, new FlyRunState(this));
            states.Add(FlyST.Idle, new FlyIdleState(this));
            states.Add(FlyST.Attack, new FlyAttackState(this));

        }

        void Update()
        {
            currentState.OnUpdate();
        }

        public void TransitionState(FlyST type)
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
