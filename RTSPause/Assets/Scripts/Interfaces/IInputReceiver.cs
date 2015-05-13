using UnityEngine;
using System.Collections;

public enum InputAxis { Up, Right, Forward }
/// <summary>
/// Use an input receiver to ask about input data
/// </summary>
public interface IInputReceiver {
    
    float GetAxis(InputAxis axis);
}
