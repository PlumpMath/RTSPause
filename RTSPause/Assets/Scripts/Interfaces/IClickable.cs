using UnityEngine;
using System.Collections;

public enum Click { Left, Right, Middle, None};

public interface IClickable {

    void Clicked(Click button, Vector3 pos);
}
