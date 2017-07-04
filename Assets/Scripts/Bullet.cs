using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
    public float speed = 10f;
    public float lifeTime = 5f;
    private Rigidbody2D rigidbody2d;

    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D> ();
        rigidbody2d.velocity = transform.up * speed;
        Destroy (gameObject, lifeTime);
    }
}
