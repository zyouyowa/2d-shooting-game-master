using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
    public int power = 1;
    public float speed = 10f;
    public float lifeTime = 5f;
    private Rigidbody2D rigidbody2d;

    /*
    void OnEnable () {
        rigidbody2d.velocity = transform.up * speed;

    }
    */

    void Awake () {
        rigidbody2d = GetComponent<Rigidbody2D> ();
        rigidbody2d.velocity = transform.up * speed;
        Destroy (gameObject, lifeTime);
    }

    /*
    void OnTriggerExit2D (Collider2D col) {
        ObjectPool.instance.ReleaseGameObject (gameObject);
    }
    */
}
