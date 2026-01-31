using UnityEngine;
using UnityEditor;
using VRC.Core;

[CustomEditor(typeof(BlueprintHolder))]
public class BlueprintHolderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        BlueprintHolder holder = (BlueprintHolder)target;
        PipelineManager pm = holder.GetComponent<PipelineManager>();

        if (pm == null)
        {
            EditorGUILayout.HelpBox("Pipeline Managerが見つかりません。", MessageType.Warning);
            return;
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("IDを反映する", EditorStyles.boldLabel);

        foreach (var entry in holder.presets)
        {
            if (GUILayout.Button($"反映: {entry.label}"))
            {
                Undo.RecordObject(pm, "Change Blueprint ID");
                pm.blueprintId = entry.blueprintId;
                EditorUtility.SetDirty(pm);
            }
        }
    }
}
