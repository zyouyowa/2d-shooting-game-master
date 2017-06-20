using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Spaceship spaceship;

    void Start () {
        spaceship = GetComponent<Spaceship> ();
        spaceship.OnStart ();
        spaceship.Move (transform.up * -1f);

        // コルーチンをbreakするのではなくコルーチンを始めなければよい
        if (spaceship.canShot) {
            StartCoroutine (StartShot ());
        }
    }

    IEnumerator StartShot () {
        WaitForSeconds wait = new WaitForSeconds (spaceship.shotDelay);
        while (true) {
            for (int i = 0; i < transform.childCount; ++i) {
                Transform shotPosition = transform.GetChild (i);
                spaceship.Shot (shotPosition);
            }
            yield return wait;
        }
    }
}
