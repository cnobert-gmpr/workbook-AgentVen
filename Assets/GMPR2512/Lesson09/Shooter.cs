using UnityEngine;

namespace GMPR2512.Lesson09 {
	public class Shooter : MonoBehaviour {
		[SerializeField] private float laserLength = 8f;

		private LineRenderer laserLineRenderer;
		
		private Transform lastObjectHit = null;


		void Awake() {
			if (laserLineRenderer == null) laserLineRenderer = GetComponent<LineRenderer>();
			if (laserLineRenderer != null) {
				laserLineRenderer.positionCount = 2;
				laserLineRenderer.useWorldSpace = true;
				laserLineRenderer.startWidth = 0.05f;
				laserLineRenderer.endWidth = 0.05f;
			}
		}

		void Update() {
			#region rotation
			float rotationInput = 0;

			if (Input.GetKey(KeyCode.Comma))
				rotationInput = 100f;
			else if (Input.GetKey(KeyCode.Period))
				rotationInput = -100f;

			transform.parent.Rotate(new Vector3(0, 0, rotationInput * Time.deltaTime));
			#endregion

			int layerMask = LayerMask.GetMask("Ground", "Enemy");
			RaycastHit2D raycastHit =
				Physics2D.Raycast(transform.position, transform.right, laserLength, layerMask);
			
			Vector3 endPoint = transform.position + transform.right * laserLength;
			if (raycastHit.collider != null) endPoint = raycastHit.point;
			laserLineRenderer?.SetPosition(0, transform.position);
			laserLineRenderer?.SetPosition(1, endPoint);
		}
	}
}
