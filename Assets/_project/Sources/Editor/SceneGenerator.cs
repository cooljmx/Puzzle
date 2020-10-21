using Assets.Sources.Behaviors;
using Assets.Sources.Extensions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Sources.Editor
{
    [InitializeOnLoad]
    public class SceneGenerator
    {
        static SceneGenerator()
        {
            EditorSceneManager.newSceneCreated += OnNewSceneCreated;
        }

        private static void OnNewSceneCreated(Scene scene, NewSceneSetup setup, NewSceneMode mode)
        {
            var setupFolder = CreateFolder("Setup");
            var worldFolder = CreateFolder("World");
            CreateFolder("UI");
            var camerasFolder = CreateFolder("Cameras").AttachToParent(setupFolder);
            CreateFolder("Static").AttachToParent(worldFolder);
            CreateFolder("Dynamic").AttachToParent(worldFolder);

            if (Camera.main != null)
                Camera.main.transform.AttachToParent(camerasFolder);

            setupFolder.gameObject.AddComponent<EntryPointBehavior>();
        }

        private static Transform CreateFolder(string name)
        {
            return new GameObject(name).transform;
        }
    }
}