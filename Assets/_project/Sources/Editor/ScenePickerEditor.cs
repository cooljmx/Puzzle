using _project.Sources.Behaviors;
using UnityEditor;

namespace _project.Sources.Editor
{
    [CustomEditor(typeof(AutoSceneLoadingBehavior), true)]
    public class ScenePickerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (!(target is AutoSceneLoadingBehavior picker))
                return;

            var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.targetScenePath);

            serializedObject.Update();

            EditorGUI.BeginChangeCheck();

            if (!(EditorGUILayout.ObjectField("scene", oldScene, typeof(SceneAsset), false) is SceneAsset pickedScene))
                return;

            if (EditorGUI.EndChangeCheck())
            {
                var newPath = AssetDatabase.GetAssetPath(pickedScene);
                var scenePathProperty = serializedObject.FindProperty(nameof(AutoSceneLoadingBehavior.targetScenePath));
                scenePathProperty.stringValue = newPath;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}