using UnityEditor;
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
        parameter.animator.Play("run_behind");
        if (!parameter.attacking)
        {
            var image = Resources.Load<Sprite>(parameter.headSpritePath + "head-behind");
            parameter.headSpriteRenderer.sprite = image;
#if UNITY_EDITOR
            //if (image == null)
            //{
            //    Debug.Log("Failed to load the head image.");
            //}
            //else
            //{
            //    Debug.Log("Succeed to load the head image");
            //}
#endif
        }

        manager.HeadSynchronize += OnHeadSynchronizeUp;

    }

    public void OnUpdate()
    {
        parameter.transform.Translate(PlayerInputData.Instance.moveVal * parameter.speed * Time.deltaTime);
        if (PlayerInputData.Instance.moveVal == Vector2.zero || manager.GetDir(PlayerInputData.Instance.moveVal) != PlayerDir.up)
        {
            manager.TransitionState(PlayerST.Idle);
        }
    }

    public void OnExit()
    {
        manager.HeadSynchronize -= OnHeadSynchronizeUp;
    }

    public void OnHeadSynchronizeUp()
    {
        parameter.headSpriteRenderer.sprite = Resources.Load<Sprite>(parameter.headSpritePath + "head-behind");
    }

}
