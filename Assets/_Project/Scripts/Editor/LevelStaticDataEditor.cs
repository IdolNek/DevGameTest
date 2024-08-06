using Assets.Scripts.Infrastructure.GameOption.LevelData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string initialPoint = "StartPlayerPoint";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var levelData = (LevelStaticData)target;
            if (GUILayout.Button("Collect"))
            {
                levelData.LevelKey = SceneManager.GetActiveScene().name;
                levelData.StartPlayerPoint = FindObjectOfType<PlayerSpawnMarker>().gameObject.transform.position;
            }
            EditorUtility.SetDirty(target);
        }
    }
}