using System;
using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05 {
	public class DeathZone : MonoBehaviour {
		[SerializeField] private Transform _spawnPoint;

		void OnTriggerEnter2D(Collider2D collider) {
			if (collider.gameObject.CompareTag("Ball")) {
				StartCoroutine(RespawnBall(collider.gameObject));
			}
		}

		private IEnumerator RespawnBall(GameObject ball) {
			yield return new WaitForSeconds(2);
			
			Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
			ballRB.linearVelocity = Vector2.zero;
			ballRB.angularVelocity = 0;
			ball.transform.position = _spawnPoint.position;
		}
	}
}
