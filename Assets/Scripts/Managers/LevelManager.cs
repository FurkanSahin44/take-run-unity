using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelManager : MonoBehaviour
{

    public GameObject door;

    public void restartLevel()
    {
        deactiveDoor();
    }



    private void deactiveDoor()
    {
        door.SetActive(false);
    }

    public void appleCollected()
    {
        door.SetActive(true);
    }
    
}
