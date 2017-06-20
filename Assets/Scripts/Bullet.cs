using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
    public float speed = 10f;
    private Rigidbody2D rigidbody2d;

    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        rigidbody2d.velocity = transform.up * speed;
    }
}
