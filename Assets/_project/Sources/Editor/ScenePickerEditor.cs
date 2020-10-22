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

            serializedObject.Update();

            var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.targetScenePath);
            EditorGUI.BeginChangeCheck();
            if (EditorGUILayout.ObjectField("Target scene", oldScene, typeof(SceneAsset), false) is SceneAsset
                pickedScene)
                if (EditorGUI.EndChangeCheck())
                {
                    var newScenePath = AssetDatabase.GetAssetPath(pickedScene);
                    var targetScenePathProperty = serializedObject
                        .FindProperty(nameof(AutoSceneLoadingBehavior.targetScenePath));
                    targetScenePathProperty.stringValue = newScenePath;
                }


            picker.minSecondsToLoading = EditorGUILayout.IntField("Min seconds to load", picker.minSecondsToLoading);

            serializedObject.ApplyModifiedProperties();
        }
    }
}