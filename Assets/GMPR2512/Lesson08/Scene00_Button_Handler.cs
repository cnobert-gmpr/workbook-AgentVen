using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace GMPR2512.Lesson08 {
	public class Scene00_Button_Handler : MonoBehaviour {
		private Button changeToScene01Button;

		private void OnEnable() {
			VisualElement root = GetComponent<UIDocument>().rootVisualElement;
			changeToScene01Button = root.Q<Button>("ChangeToScene01Button");
			if (changeToScene01Button != null) changeToScene01Button.clicked += ChangeToScene01;
		}

		private void OnDisable() {
			if (changeToScene01Button != null) changeToScene01Button.clicked -= ChangeToScene01;
		}

		private void ChangeToScene01() {
			SceneManager.LoadScene(1);
		}
	}
}
