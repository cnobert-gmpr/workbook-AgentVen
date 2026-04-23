using UnityEngine;

namespace GMPR2512.Lesson07 {
	public class Thing : MonoBehaviour {
		[SerializeField] private GameObject projectilePrefab;
		[SerializeField] private float projectileSpeed = 5, projectileSpinVelocity = -2000;
		[SerializeField] private int upperRandomFiringRange;

		private Transform firePos;

		void Awake() {
			firePos = transform.GetChild(0);
		}

		void Update() {
			int random = Random.Range(1, upperRandomFiringRange);
			if (random == 1) {
				GameObject newProjectile = 
					Instantiate(projectilePrefab, firePos.position, transform.rotation);
				
				Projectile projectileScript = newProjectile.GetComponent<Projectile>();
				projectileScript.Speed = projectileSpeed;
				projectileScript.Direction = transform.up;
				projectileScript.SpinVelocity = projectileSpinVelocity;
				projectileScript.TagFilter = TagHandle.GetExistingTag("Player");
			}
		}

		void OnTriggerEnter2D(Collider2D collider) {
			if (collider.gameObject.CompareTag("Projectile")) return;

			ThingLeader leader = transform.parent.GetComponent<ThingLeader>();
			leader.Direction *= Vector2.left;
		}
	}
}
