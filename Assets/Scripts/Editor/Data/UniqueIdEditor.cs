using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


[CustomEditor(typeof(UniqueId))]
public class UniqueIdEditor : Editor
{
    private void OnEnable()
    {
        var uniqueId = (UniqueId) target;
        if(IsPrefab(uniqueId))
            return;
            
            
        if (string.IsNullOrEmpty(uniqueId.Id))
        {
            Generate(uniqueId);
        }
        else
        {
            UniqueId[] uniqueIds = FindObjectsOfType<UniqueId>();
            if (uniqueIds.Any(other => other != uniqueId && other.Id == uniqueId.Id))
            {
                Generate(uniqueId);
            }
        }
    }

    private bool IsPrefab(UniqueId uniqueId)
    {
        return uniqueId.gameObject.scene.rootCount == 0;
    }

    private void Generate(UniqueId uniqueId)
    {
        
        Type uniqueIdType = typeof(UniqueId);
        FieldInfo idField = uniqueIdType.GetField("_id", BindingFlags.NonPublic | BindingFlags.Instance);

        string newId = $"{uniqueId.gameObject.scene.name}_{Guid.NewGuid()}";
        idField.SetValue(uniqueId, newId);
        
        if (!Application.isPlaying)
        {
            EditorUtility.SetDirty(uniqueId);
            EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
        }
            
    }
}