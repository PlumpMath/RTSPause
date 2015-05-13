using UnityEngine;
using System.Collections;

public class BlockRock : Block {


    public BlockRock():base(true){}

    public override void Instantiate(WorldPos pos) {
        instance = GameController.Instantiate(template, new Vector3(pos.x, 0, pos.y), Quaternion.identity) as GameObject;
           
    }
    public override void Delete() {
        GameController.Destroy(instance);
    }
}
