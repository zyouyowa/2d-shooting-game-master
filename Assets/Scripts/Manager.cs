using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject player;
    private GameObject title;

    public bool isPlaying{ get { return !title.activeSelf; } }

    void Start () {
        title = GameObject.Find ("Title");
        Score.instance.Initialize ();
    }

    void Update () {
        if (!isPlaying && Input.GetKeyDown (KeyCode.X)) {
            GameStart ();
        }
    }

    void GameStart () {
        title.SetActive (false);
        Instantiate (player, player.transform.position, player.transform.rotation);
    }

    public void GameOver () {
        Score.instance.Save ();
        title.SetActive (true);
    }
}
