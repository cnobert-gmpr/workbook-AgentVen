using UnityEngine;
using UnityEngine.InputSystem;

namespace GMPR2512.Lesson07 {
	public class Ship : MonoBehaviour {
		[SerializeField] private float movementSpeed = 5, rotationSpeed = 200, scaleSpeed = 5;
		[SerializeField] private float minRotation = 25, maxRotation = -25;

		private InputAction moveAction, rotationAction, scaleAction;

		void Awake() {
			moveAction = InputSystem.actions.FindAction("Player/Move");
			rotationAction = InputSystem.actions.FindAction("Player/Move");
			scaleAction = InputSystem.actions.FindAction("Player/Scale");
		}

		void Update() {
			#region Movement
			Vector2 moveDirection = moveAction.ReadValue<Vector2>() * Vector2.right;
			Vector2 translation = movementSpeed * Time.deltaTime * moveDirection.normalized;
			transform.Translate(translation, Space.Self);
			#endregion

			#region Rotation
			float rotation = rotationAction.ReadValue<Vector2>().normalized.y
				* rotationSpeed * Time.deltaTime;
			transform.Rotate(0, 0, rotation);

			// Clamp
			Vector3 euler = transform.eulerAngles;
			if (euler.z > 180f) euler.z -= 360f;
			euler.z = Mathf.Clamp(euler.z, maxRotation, minRotation);
			transform.eulerAngles = euler;
			#endregion

			#region Scale
			float scale = scaleAction.ReadValue<float>() * scaleSpeed * Time.deltaTime;
			Vector3 scaleDelta = Vector2.one * scale;
			transform.localScale += scaleDelta;

			Vector3 localScale = transform.localScale;
			if (localScale.x < 0) localScale.x = 0;
			if (localScale.y < 0) localScale.y = 0;
			if (localScale.z < 0) localScale.z = 0;
			transform.localScale = localScale;
			#endregion
		}
	}
}
