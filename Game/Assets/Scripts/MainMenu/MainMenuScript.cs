using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MainMenu
{
    public class MainMenuScript : MonoBehaviour
    {
        private void Start()
        {

        }
        
        private void Update()
        {

        }

        public void OnPlayButtonClick()
        {
            SceneManager.LoadScene(Scenes.DifficultyChoiseScene);
        }

        public void OnQuitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
