using UnityEngine;

namespace GMPR2512.Lesson07 {
	public class ThingLeader : MonoBehaviour {
		[SerializeField] private float speed = 0.5f;
		[SerializeField] private Vector2 direction = Vector2.left;

		internal Vector2 Direction { get => direction; set => direction = value; }


		void Update() {
			transform.Translate(speed * Time.deltaTime * direction.normalized);
		}
	}
}
