using UnityEngine;

namespace GMPR2512.Lesson06 {
	public class Flippers : MonoBehaviour {
		[SerializeField] GameObject leftFlipper, rightFlipper;

		private HingeJoint2D leftFlipperHinge, rightFlipperHinge;

		void Awake() {
			leftFlipperHinge = leftFlipper.GetComponent<HingeJoint2D>();
			rightFlipperHinge = rightFlipper.GetComponent<HingeJoint2D>();
		}

		void Update() {
			leftFlipperHinge.useMotor = Input.GetKey(KeyCode.LeftShift);
			rightFlipperHinge.useMotor = Input.GetKey(KeyCode.RightShift);
		}
	}
}
