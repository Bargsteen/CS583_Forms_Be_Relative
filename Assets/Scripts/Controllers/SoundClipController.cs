using UnityEngine;

namespace Controllers
{
    public class SoundClipController : MonoBehaviour
    {
        [SerializeField] private AudioClip correctShapeSound;
        [SerializeField] private AudioClip wrongShapeSound;
        [SerializeField] private AudioSource audioSource;
    
        [SerializeField] private float volume = 10f;

        public void PlayCorrectShapeSound() => audioSource.PlayOneShot(correctShapeSound, volume);
        public void PlayWrongShapeSound() => audioSource.PlayOneShot(wrongShapeSound, volume);
    }
}
