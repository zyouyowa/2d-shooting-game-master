using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 10f;
    private Rigidbody2D rigidbody2d;
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        rigidbody2d.velocity = transform.up * speed;
	}
}
