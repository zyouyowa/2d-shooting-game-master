using System.Collections;
using UnityEngine;

public class Player : Spaceship {
    private AudioSource audioSource;
    private Animator animator;

    void Start () {
        audioSource = GetComponent<AudioSource> ();
        StartCoroutine (StartShot ());
    }

    IEnumerator StartShot () {
        WaitForSeconds wait = new WaitForSeconds (shotDelay);
        while (true) {
            Shot (transform);
            audioSource.Play ();
            yield return wait;
        }
    }

    void Update () {
        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");
        Vector2 direction = new Vector2 (x, y).normalized;
        Move (direction);

    }

    public override void Move (Vector2 direction) {
        Vector2 min = Camera.main.ViewportToWorldPoint (Vector2.zero);
        Vector2 max = Camera.main.ViewportToWorldPoint (Vector2.one);
        Vector2 pos = transform.position;

        //Transformを直接いじれば当たり判定が働かないのを悪用している方法、良くない...。
        pos += direction * speed * Time.deltaTime;
        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);
        transform.position = pos;
    }

    void OnTriggerEnter2D (Collider2D col) {
        string layerName = LayerMask.LayerToName (col.gameObject.layer);
        if (layerName == "Bullet(Enemy)") {
            Destroy (col.gameObject);
        }
        if (layerName == "Bullet(Enemy)" || layerName == "Enemy") {
            FindObjectOfType<Manager> ().GameOver ();
            Explosion ();
            Destroy (gameObject);
        }
    }
}
