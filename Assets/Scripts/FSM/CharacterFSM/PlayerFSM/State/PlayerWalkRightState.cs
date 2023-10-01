using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkRightState : IState
{
    private PlayerFsmManager manager;
    private PlayerParameter parameter;

    public PlayerWalkRightState(PlayerFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        parameter.animator.Play("run_right");
        if (!parameter.attacking)
        {
            var image = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-right.png");
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

        manager.HeadSynchronize += OnHeadSynchronizeRight;

    }

    public void OnUpdate()
    {
        parameter.transform.Translate(PlayerInputData.Instance.moveVal * parameter.speed * Time.deltaTime);
        if (PlayerInputData.Instance.moveVal == Vector2.zero || manager.GetDir(PlayerInputData.Instance.moveVal) != PlayerDir.right)
        {
            manager.TransitionState(PlayerST.Idle);
        }
    }

    public void OnExit()
    {
        manager.HeadSynchronize -= OnHeadSynchronizeRight;
    }

    public void OnHeadSynchronizeRight()
    {
        parameter.headSpriteRenderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-right.png");
    }
}
