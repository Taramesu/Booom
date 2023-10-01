using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkDownState : IState
{
    private PlayerFsmManager manager;
    private PlayerParameter parameter;

    public PlayerWalkDownState(PlayerFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        parameter.animator.Play("run_front");
        if (!parameter.attacking)
        {
            var image = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-front.png");
            parameter.headSpriteRenderer.sprite = image;
#if UNITY_EDITOR
            if (image == null)
            {
                Debug.Log("Failed to load the head image.");
            }
            else
            {
                Debug.Log("Succeed to load the head image");
            }
#endif
        }

#if UNITY_EDITOR
        Debug.Log("front");
#endif
    }

    public void OnUpdate()
    {
        parameter.transform.Translate(PlayerInputData.Instance.moveVal*parameter.speed*Time.deltaTime);

        if(PlayerInputData.Instance.moveVal == Vector2.zero || manager.GetMoveDir(PlayerInputData.Instance.moveVal) != PlayerMoveDir.down)
        {
            manager.TransitionState(PlayerST.Idle);
        }
    }

    public void OnExit()
    {

    }

}
