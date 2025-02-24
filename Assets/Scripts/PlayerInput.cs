using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const string HorizontalAxisTitle = "Horizontal";
    public const string VerticalAxisTitle = "Vertical";
    public const KeyCode JumpKey = KeyCode.Space;

    public float HorizontalInput { get; private set; } = 0;
    public float VerticalInput { get; private set; } = 0;
    public bool IsJumping { get; private set; } = false;

    private void Update()
    {
        HorizontalInput = Input.GetAxis(HorizontalAxisTitle);
        VerticalInput = Input.GetAxis(VerticalAxisTitle);

        if (Input.GetKeyDown(JumpKey))
        {
            IsJumping = true;
        }
    }

    public bool GetIsJumping()
    {
        if (IsJumping)
        {
            IsJumping = false;
            return true;
        }

        return false;
    }
}