using UnityEngine;

namespace GMPR2512.Lesson04 {
	public class DeathZone : MonoBehaviour {

		void Start() {}

		void Update() {}

		void OnTriggerEnter2D(Collider2D collider) {
			Destroy(collider.gameObject);
		}
	}
}
