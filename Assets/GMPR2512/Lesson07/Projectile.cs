using UnityEngine;

namespace GMPR2512.Lesson07 {
	public class Projectile : MonoBehaviour {
		[SerializeField] private ParticleSystem explosionEffect;

		private float speed = 10, spinVelocity = 0;
		private Vector2 direction = Vector2.up;
		private TagHandle tagFilter;

		internal Vector2 Direction { get => direction; set => direction = value; }
		internal float Speed { get => speed; set => speed = value; }
		internal float SpinVelocity { set => spinVelocity = value; }
		internal TagHandle TagFilter { get => tagFilter; set => tagFilter = value; }


		void Update() {
			transform.Translate(speed * Time.deltaTime * Direction.normalized, Space.World);
			transform.Rotate(0, 0, spinVelocity * Time.deltaTime, Space.World);
		}

		void OnTriggerEnter2D(Collider2D collider) {
			if (!collider.gameObject.CompareTag(TagFilter)) return;

			Instantiate(explosionEffect, collider.gameObject.transform.position, transform.rotation);

			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
