using UnityEngine;

namespace GMPR2512.Lesson09 {
	public class CharacterController : MonoBehaviour {
		[SerializeField] private float _maxSpeed = 5;
		[SerializeField] private Transform _groundCheck;
		[SerializeField] private float _jumpForce = 1000;

		protected Animator animator;
		protected Rigidbody2D rigidboy;
		protected float moveForce = 365;
		protected bool isFacingRight = true;
		protected bool isGrounded = false;
		protected bool hasJumped = false;

		void Awake() {
			animator = GetComponent<Animator>();
			rigidboy = GetComponent<Rigidbody2D>();
		}

		// TODO)) Jumping broken

		void Update() {
			//_grounded will be true if our hero is standing on a platform (remember to add the platform to the ground layer)
			//layer mask bitwise ops: https://answers.unity.com/questions/8715/how-do-i-use-layermasks.html
			isGrounded = Physics2D.Linecast(transform.position, _groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
			if (Input.GetButtonDown("Jump") && isGrounded) {
				hasJumped = true;
			}
		}

		void FixedUpdate() {
			float horizontalAxis = Input.GetAxis("Horizontal");
			animator.SetFloat("Speed", Mathf.Abs(horizontalAxis));

			if ((horizontalAxis > 0 && !isFacingRight) || (horizontalAxis < 0 && isFacingRight)) Flip();

			//Have we reached maxSpeed? If not, add force.
			if (horizontalAxis * rigidboy.linearVelocity.x < _maxSpeed) {
				rigidboy.AddForce(moveForce * horizontalAxis * Vector2.right);
			}

			//Have we exceeded the maxSpeed? Clamp it.
			if (Mathf.Abs(rigidboy.linearVelocity.x) > _maxSpeed) {
				rigidboy.linearVelocity = new Vector2(
				    Mathf.Sign(rigidboy.linearVelocity.x) * _maxSpeed,
				    rigidboy.linearVelocity.y
				);
			}

			if (hasJumped) {
				animator.SetTrigger("Jump");
				rigidboy.AddForce(new Vector2(0, _jumpForce));
				hasJumped = false;
			}
		}

		void Flip() {
			isFacingRight = !isFacingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}