using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    bool isInGame = false;
    bool isPaused = true;

    //Properties

    public bool InGame {
        get { return isInGame; }
        set { isInGame = value; }
    }

    public bool Paused {
        get { return isPaused; }
        set { isPaused = value; }
    }
}
