using UnityEngine;
using System.Collections;

/// <summary>
/// Access instanced controllers through GameController
/// </summary>
public class GameController : MonoBehaviour {

    public static PauseTimeScale pauseTimeScale;
    public static UIPauseIcon uiPauseIcon;
    public static DistributeTerrain distributeTerrain;

    public Chunk chunk;

    void Awake(){
        pauseTimeScale = GetComponent<PauseTimeScale>();
        uiPauseIcon = GetComponent<UIPauseIcon>();
        distributeTerrain = new DistributeTerrain();
        
        distributeTerrain.CreateTerrain(10,10, chunk);
    }

}
