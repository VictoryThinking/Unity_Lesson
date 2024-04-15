using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using Unity.VisualScripting;

[CustomEditor(typeof(SpawnZone))]
public class SpawnZoneEditor : Editor
{
    private BoxBoundsHandle m_handles = new BoxBoundsHandle();
    public virtual void OnSceneGUI()
    {
        SpawnZone selectedZone = (SpawnZone)target;
        //copies data from highlightened spawn zone
        m_handles.center = selectedZone.bounds.center;
        m_handles.size = selectedZone.bounds.size;

        EditorGUI.BeginChangeCheck();
        m_handles.DrawHandle();
        if (EditorGUI.EndChangeCheck())
        {
            // record the target object before setting new values so changes can be undone/redone
            Undo.RecordObject(selectedZone, "Change Bounds");

            // copy the handle's updated data back to the target object
            Bounds newBounds = new Bounds();
            newBounds.center = m_handles.center;
            newBounds.size = m_handles.size;
            selectedZone.bounds = newBounds;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
