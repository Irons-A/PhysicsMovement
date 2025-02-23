using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _jumpHeight = 6f;
    [SerializeField] private float _gravityAmplifier = 1f;

    private CharacterController _characterController;
    private PlayerInput _input;
    private Vector3 _movementDirection = Vector3.zero;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (_characterController.isGrounded)
        {
            _movementDirection = new Vector3(_input.HorizontalInput, 0f, _input.VerticalInput) * _speed;

            if (_input.IsJumping)
            {
                _movementDirection.y = _jumpHeight;
            }
        }

        _movementDirection.y += Physics.gravity.y * _gravityAmplifier * Time.deltaTime;
        _characterController.Move(_movementDirection * Time.deltaTime);
    }
}
