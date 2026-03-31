using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace GMPR2512.Lesson08 {
	public class Scene01_UI : MonoBehaviour {
		private Button changeToScene00Button;

		private void OnEnable() {
			VisualElement root = GetComponent<UIDocument>().rootVisualElement;
			changeToScene00Button = root.Q<Button>("ChangeToScene00Button");
			if (changeToScene00Button != null) changeToScene00Button.clicked += ChangeToScene00;
		}

		private void OnDisable() {
			if (changeToScene00Button != null) changeToScene00Button.clicked -= ChangeToScene00;
		}

		private void ChangeToScene00() {
			SceneManager.LoadScene(0);
		}
	}
}
