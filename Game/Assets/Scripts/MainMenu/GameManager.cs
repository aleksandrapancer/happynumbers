using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MainMenu
{
    public class GameManager : MonoBehaviour
    {
        public Stack<string> SceneStack { get; } = new Stack<string>();

        public static GameManager Instance { get; private set; }

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

        private void Start()
        {

        }

        private void Update()
        {

        }

        public void OnYoungerButtonClick()
        {
            BeforeSceneChangeActivity();
            SceneManager.LoadScene(Scenes.MenuYoungerScene);
        }

        public void OnOlderButtonClick()
        {
            BeforeSceneChangeActivity();
            SceneManager.LoadScene(Scenes.MenuOlderScene);
        }

        public void OnNumbersLearningButtonClick()
        {
            BeforeSceneChangeActivity();
            SceneManager.LoadScene(Scenes.LearnNumbersScene);
        }

        public void OnClockLearningButtonClick()
        {
            BeforeSceneChangeActivity();
            SceneManager.LoadScene(Scenes.ClockLearningScene);
        }

        public void OnSetTheTimeButtonClick()
        {
            BeforeSceneChangeActivity();
            SceneManager.LoadScene(Scenes.SetTheTimeScene);
        }

        public void OnCalculationButtonClick()
        {
            BeforeSceneChangeActivity();
            SceneManager.LoadScene(Scenes.CalculationScene);
        }

        public void OnCalculation2ButtonClick()
        {
            BeforeSceneChangeActivity();
            SceneManager.LoadScene(Scenes.Calculation2Scene);
        }

        public void OnBuildClockButtonClick()
        {
            BeforeSceneChangeActivity();
            SceneManager.LoadScene(Scenes.BuildClockScene);
        }

        public void OnBackButtonClick()
        {
            SceneManager.LoadScene(SceneStack.Pop());
        }

        public void OnQuitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        private void BeforeSceneChangeActivity()
        {
            SceneStack.Push(SceneManager.GetActiveScene().name);
        }
    }
}
