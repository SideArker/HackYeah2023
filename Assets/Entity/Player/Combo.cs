using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu]
public class Combo : ScriptableObject
{
    public bool enabled;
    public string Name;
    public int damage;
    public int range;
    public string comboString;
    public UnityEvent onCombo;
}
