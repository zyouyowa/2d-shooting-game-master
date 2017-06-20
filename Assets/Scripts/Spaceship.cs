using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {
    public float speed = 10f;
    public float shotDelay;
    public GameObject bullet;
    public bool canShot;
    private Rigidbody2D rigidbody2d;

    public void OnStart () {
        rigidbody2d = GetComponent<Rigidbody2D> ();
    }

    public void Shot (Transform origin) {
        Instantiate (bullet, origin.position, origin.rotation);
    }

    public void Move (Vector2 direction) {
        rigidbody2d.velocity = direction * speed;
    }
}