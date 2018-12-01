using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class SoundEffectsHelper : MonoBehaviour
    {
        public AudioClip CorrectAnswerSound;
        public AudioClip WrongAnswerSound;

        public static SoundEffectsHelper Instance;

        #region Unity Methods

        private void Awake()
        {
            // Register the singleton
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

        /// <summary>
        /// Play a given sound.
        /// </summary>
        /// <param name="originalClip"></param>
        private void PlaySound(AudioClip originalClip)
        {
            // As it is not 3D audio clip, position doesn't matter.
            AudioSource.PlayClipAtPoint(originalClip, transform.position);
        }
    }
}