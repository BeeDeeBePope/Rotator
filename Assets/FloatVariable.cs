using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float Value;

    public void SetFromString(string val)
    {
        Value = float.Parse(val);
    }
}