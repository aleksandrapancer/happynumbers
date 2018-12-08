using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class SoundEffectsHelper : MonoBehaviour
    {
        public AudioClip CorrectAnswerSound;
        public AudioClip WrongAnswerSound;

        public static SoundEffectsHelper Instance { get; private set; }

        #region Unity Methods

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple instances of SoundEffectsHelper!");
            }
            Instance = this;
        }

        #endregion Unity Methods

        public void PlayCorrectAnswerSound()
        {
            PlaySound(CorrectAnswerSound);
        }

        public void PlayWrongAnswerSound()
        {
            PlaySound(WrongAnswerSound);
        }

        private void PlaySound(AudioClip originalClip)
        {
            // As it is not 3D audio clip, position doesn't matter.
            AudioSource.PlayClipAtPoint(originalClip, transform.position);
        }
    }
}