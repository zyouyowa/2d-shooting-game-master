using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
    public GameObject[] waves;
    private int currentWave;
    private Manager manager;

    void Start () {
        manager = FindObjectOfType<Manager> ();
        if (waves.Length > 0) {
            StartCoroutine (StartWave ());
        }
    }

    IEnumerator StartWave () {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame ();
        while (true) {
            while (!manager.isPlaying) {
                yield return waitForEndOfFrame;
            }

            GameObject wave = Instantiate (
                                  original: waves [currentWave], 
                                  position: transform.position, 
                                  rotation: Quaternion.identity
                              ) as GameObject;
            wave.transform.SetParent (transform);
            while (wave.transform.childCount != 0) {
                yield return waitForEndOfFrame;
            }
            Destroy (wave);
            if (waves.Length <= ++currentWave) {
                currentWave = 0;
            }
        }
    }
}
