using Game.Core.Player;
using UnityEngine;
using Zenject;

namespace Game.Core.Common
{
	[RequireComponent(typeof(Camera))]
	public class CameraController : MonoBehaviour
	{
		[field: SerializeField]
		private Camera Camera { get; set; }

		[Inject]
		private PlayerBehaviour PlayerBehaviour { get; set; }

		private void OnValidate()
		{
			Camera = GetComponent<Camera>();
		}

		private void LateUpdate()
		{
			var targetPosition = PlayerBehaviour.transform.position;
			var cameraTransform = Camera.transform;
			targetPosition.z = cameraTransform.position.z;
			cameraTransform.position = targetPosition;
		}
	}
}