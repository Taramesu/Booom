using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkLeftState : IState
{
    private PlayerFsmManager manager;
    private PlayerParameter parameter;

    public PlayerWalkLeftState(PlayerFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        parameter.animator.Play("run_left");
        if (!parameter.attacking)
        {
            var image = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-left.png");
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
        Debug.Log("left");
#endif
    }

    public void OnUpdate()
    {
        parameter.transform.Translate(PlayerInputData.Instance.moveVal * parameter.speed * Time.deltaTime);
        if (PlayerInputData.Instance.moveVal == Vector2.zero || manager.GetMoveDir(PlayerInputData.Instance.moveVal) != PlayerMoveDir.left)
        {
            manager.TransitionState(PlayerST.Idle);
        }
    }

    public void OnExit()
    {

    }

}
