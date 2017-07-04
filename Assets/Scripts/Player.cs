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

    void OnTriggerEnter2D (Collider2D col) {
        string layerName = LayerMask.LayerToName (col.gameObject.layer);
        if (layerName == "Bullet(Enemy)") {
            Destroy (col.gameObject);
        }
        if (layerName == "Bullet(Enemy)" || layerName == "Enemy") {
            spaceship.Explosion ();
            Destroy (gameObject);
        }
    }
}
