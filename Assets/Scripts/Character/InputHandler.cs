using UnityEngine;

public class InputHandler: MonoBehaviour
{
    public float VerticalAxis()
    {
        return Input.GetAxis("Vertical");
    } 

    public float HorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool IsAiming()
    {
        return Input.GetMouseButton(1);
    }
}
