using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    protected override void Awake()
    {
        base.Awake(); //TopDowmController를 상속받았기에 base = 부모가 됨
        camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        //실제 움직이는 처리는 여기서 하는게 아니라 PlayerMovement에서 함.
    }
    public void OnLook(InputValue value) 
    {
        Vector2 newAim = value.Get<Vector2>();//마우스이기에 노말라이즈X
        Vector2 worldPos = camera.WorldToScreenPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }
    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}

