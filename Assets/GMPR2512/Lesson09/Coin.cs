using UnityEngine;

namespace GMPR2512.Lesson09 {
	public class Coin : MonoBehaviour {
		private SoundHub soundHub;


		void Awake() {
			soundHub = GameObject.Find("SoundHub").GetComponent<SoundHub>();
		}

		void OnTriggerEnter2D(Collider2D collider) {
			soundHub.PlayCoinSound();

			Destroy(gameObject);
		}
	}
}
