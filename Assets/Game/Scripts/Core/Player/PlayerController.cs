using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Core.Player
{
	public class PlayerController : MonoBehaviour
	{
		[field: SerializeField]
		private Rigidbody2D Rigidbody2D { get; set; }

		[field: SerializeField]
		private Transform Transform { get; set; }

		[field: SerializeField]
		private InputActionReference MovementInput { get; set; }

		[field: SerializeField]
		private float Speed { get; set; }

		private void OnEnable()
		{
			MovementInput.action.Enable();
		}

		private void OnDisable()
		{
			MovementInput.action.Disable();
		}

		private void FixedUpdate()
		{
			var direction = MovementInput.action.ReadValue<Vector2>();
			direction.Normalize();

			Rigidbody2D.MovePosition((Vector2)Transform.position + direction * (Speed * Time.fixedDeltaTime));
		}
	}
}