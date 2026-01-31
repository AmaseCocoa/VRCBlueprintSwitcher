using UnityEngine;
using System.Collections.Generic;

public class BlueprintHolder : MonoBehaviour
{
    [System.Serializable]
    public struct BlueprintEntry
    {
        public string label;
        public string blueprintId;
    }

    public List<BlueprintEntry> presets = new List<BlueprintEntry>();
}
