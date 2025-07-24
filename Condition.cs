using UnityEngine;

[System.Serializable]
public class Condition
{
    public ButtonScript button;
    public bool RequireOff;

    public Condition(ButtonScript button, bool requireOff)
    {
        this.button = button;
        RequireOff = requireOff;
    }
}
