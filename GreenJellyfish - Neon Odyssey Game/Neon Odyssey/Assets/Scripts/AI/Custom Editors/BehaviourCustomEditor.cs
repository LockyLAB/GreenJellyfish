using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BehaviourComposite), true)]
[CanEditMultipleObjects]
public class BehaviourCustomEditor : Editor
{
    SerializedProperty m_editorName;
    SerializedProperty m_editorBranches;

    private bool m_showDetails = false;

    private string name = "";

    void OnEnable()
    {
        // Setup the SerializedProperties.
        m_editorName = serializedObject.FindProperty("m_nameOfComponent");
        m_editorBranches = serializedObject.FindProperty("m_behaviourBranches");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.Label(name, EditorStyles.boldLabel);
        m_showDetails = EditorGUILayout.Foldout(m_showDetails, "Show Details");
        if (m_showDetails)
        {
            name = EditorGUILayout.TextField("Name of Component", name);
            EditorGUILayout.PropertyField(m_editorBranches, true);
        }

        serializedObject.ApplyModifiedProperties();
    }
}