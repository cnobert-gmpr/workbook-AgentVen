using UnityEngine;

namespace GMPR2512.Lesson09 {
	public class SoundHub : MonoBehaviour {
		private AudioSource[] audioSources;


		void Awake() {
			audioSources = GetComponents<AudioSource>();
		}


		public void PlayCoinSound() {
			audioSources[0]?.Play();
		}
	}
}
