using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson09 {
	public class PlatformFalling : MonoBehaviour {
		private Renderer renderer;
		private Rigidbody2D rigidbody;


		void Awake() {
			renderer = GetComponent<Renderer>();
			rigidbody = GetComponent<Rigidbody2D>();
		}

		void OnCollisionEnter2D(Collision2D collision) {
			renderer.material.color = Color.cadetBlue;

			StartCoroutine(WaitThenFall());
		}

		
		private IEnumerator WaitThenFall() {
			yield return new WaitForSeconds(2);

			rigidbody.bodyType = RigidbodyType2D.Dynamic;
		}
	}
}
