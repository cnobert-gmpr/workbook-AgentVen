using UnityEngine;

namespace GMPR2512.Lesson07 {
	public class Projectile : MonoBehaviour {
		private float speed = 10, spinVelocity;
		private Vector2 direction = Vector2.up;

		internal Vector2 Direction { get => direction; set => direction = value; }
		internal float Speed { get => speed; set => speed = value; }


		void Update() {
			transform.Translate(speed * Time.deltaTime * Direction.normalized, Space.World);
		}
	}
}
