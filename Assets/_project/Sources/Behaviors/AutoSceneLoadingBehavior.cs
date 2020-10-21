using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _project.Sources.Behaviors
{
    public class AutoSceneLoadingBehavior : MonoBehaviour
    {
        [SerializeField] [CanBeNull] public string targetScenePath;
        private Scene _sourceScene;

        private void Awake()
        {
            _sourceScene = SceneManager.GetActiveScene();
        }

        private void Start()
        {
            var loadSceneTask = SceneManager.LoadSceneAsync(targetScenePath, LoadSceneMode.Additive);

            loadSceneTask.completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation operation)
        {
            var targetScene = SceneManager.GetSceneByPath(targetScenePath);

            SceneManager.UnloadSceneAsync(_sourceScene);
            SceneManager.SetActiveScene(targetScene);

            operation.completed -= OnSceneLoaded;
        }
    }
}