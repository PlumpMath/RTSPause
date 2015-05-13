using UnityEngine;
using System.Collections;

/// <summary>
/// Access instanced controllers through GameController
/// </summary>
public class GameController : MonoBehaviour {

    public static PauseTimeScale pauseTimeScale;
    public static UIPauseIcon uiPauseIcon;
    public static World world;

    void Awake(){
        pauseTimeScale = GetComponent<PauseTimeScale>();
        uiPauseIcon = GetComponent<UIPauseIcon>();
        world = GetComponent<World>();
    }

}
