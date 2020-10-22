using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _project.Sources.Behaviors
{
    public class AutoSceneLoadingBehavior : MonoBehaviour
    {
        [SerializeField] [CanBeNull] public string targetScenePath;
        public int minSecondsToLoading;
        private bool _isSceneLoaded;
        private Scene _sourceScene;

        private void Awake()
        {
            _sourceScene = SceneManager.GetActiveScene();
        }

        private void Start()
        {
            var loadSceneTask = SceneManager.LoadSceneAsync(targetScenePath, LoadSceneMode.Additive);

            loadSceneTask.completed += OnSceneLoaded;

            StartCoroutine(WaitingCoroutine());
        }

        private IEnumerator WaitingCoroutine()
        {
            yield return new WaitForSeconds(minSecondsToLoading);
            yield return new WaitUntil(() => _isSceneLoaded);

            var targetScene = SceneManager.GetSceneByPath(targetScenePath);
            SceneManager.UnloadSceneAsync(_sourceScene);
            SceneManager.SetActiveScene(targetScene);
        }

        private void OnSceneLoaded(AsyncOperation operation)
        {
            operation.completed -= OnSceneLoaded;

            _isSceneLoaded = true;
        }
    }
}