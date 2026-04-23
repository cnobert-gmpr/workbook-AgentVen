using UnityEngine;

namespace GMPR2512.Lesson06 {
	public class Plunger : MonoBehaviour {
		[SerializeField] private Transform lowestPoint, stopPoint;
		[SerializeField] private float velocity = -5, force = 10;

		private Rigidbody2D rigidbody;

		void Awake() {
			rigidbody = GetComponent<Rigidbody2D>();
		}

		void Update() {
			bool spacePressed = Input.GetKey(KeyCode.Space);
			bool spaceReleased = Input.GetKeyUp(KeyCode.Space);

			if (spacePressed && transform.position.y >= lowestPoint.position.y) PullPlunger();
			if (spaceReleased) ReleasePlunger();
		}

		private void PullPlunger() {
			transform.Translate(0, velocity * Time.deltaTime, 0, Space.Self);
		}

		private void ReleasePlunger() {
			rigidbody.bodyType = RigidbodyType2D.Dynamic;

			float distance = stopPoint.position.y - transform.position.y;
			Vector2 impulse = new Vector2(0, force * distance);

			rigidbody.AddForce(impulse, ForceMode2D.Impulse);
		}
	}
}
