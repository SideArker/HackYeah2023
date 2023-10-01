using UnityEditor;
using UnityEngine;

public enum abilityType
{
    Laser, 
    Fist, 
    Leg,
}


[System.Serializable]
[CreateAssetMenu]
public class Combo : ScriptableObject
{
    public bool enabled;
    public int damage;
    public int range;
    public int cooldown;
    public string comboString;
    public Animation animation;
    public abilityType abilityType;
    public GameObject laserPrefab;
    public ParticleSystem particle;
}
