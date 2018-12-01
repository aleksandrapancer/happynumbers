using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class BackgroundMusicHelper : MonoBehaviour
    {
        public static BackgroundMusicHelper Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
    }
}
