using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Level : MonoBehaviour {

    int blockCount = 0;
	
	public void AddBreakableBlock()
    {
        blockCount++;
    }

    public void RemoveBreakableBlock()
    {
        blockCount--;
        if(blockCount<=0)
        {
            SceneLoader sceneLoader=FindObjectOfType<SceneLoader>();
            sceneLoader.LoadNextScene();
        }
    }
}
