using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkUpState : IState
{
    private PlayerFsmManager manager;
    private PlayerParameter parameter;

    public PlayerWalkUpState(PlayerFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        //parameter.animator.Play("WalkYAxis");
    }

    public void OnUpdate()
    {
        parameter.transform.Translate(PlayerInputData.Instance.moveVal * parameter.speed * Time.deltaTime);
        if (PlayerInputData.Instance.moveVal == Vector2.zero)
        {
            manager.TransitionState(PlayerST.Idle);
        }
    }

    public void OnExit()
    {

    }

}
