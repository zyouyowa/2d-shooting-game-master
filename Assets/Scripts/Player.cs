using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
    private Spaceship spaceship;

    void Start () {
        spaceship = GetComponent<Spaceship> ();
        spaceship.OnStart ();
        StartCoroutine (StartShot ());
    }

    IEnumerator StartShot () {
        WaitForSeconds wait = new WaitForSeconds (spaceship.shotDelay);
        while (true) {
            spaceship.Shot (transform);
            yield return wait;
        }
    }

    void Update () {
        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");
        Vector2 direction = new Vector2 (x, y).normalized;
        spaceship.Move (direction);
    }
}
