using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship {
    public int hp = 1;
    public int point = 100;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private static int damageHash = Animator.StringToHash ("Damage");

    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();

        Move (transform.up * -1f);
        // コルーチンをbreakするのではなくコルーチンを始めなければよい
        if (canShot) {
            StartCoroutine (StartShot ());
        }
    }

    IEnumerator StartShot () {
        WaitForSeconds wait = new WaitForSeconds (shotDelay);
        while (true) {
            for (int i = 0; i < transform.childCount; ++i) {
                Transform shotPosition = transform.GetChild (i);
                Shot (shotPosition);
            }
            yield return wait;
        }
    }


    public override void Move (Vector2 direction) {
        rigidbody2d.velocity = direction * speed;
    }

    void OnTriggerEnter2D (Collider2D col) {
        string layerName = LayerMask.LayerToName (col.gameObject.layer);
        if (layerName != "Bullet(Player)") {
            return;
        }

        Transform playerBulletTransform = col.transform.parent;
        Bullet bullet = playerBulletTransform.GetComponent<Bullet> ();
        hp -= bullet.power;

        Destroy (col.gameObject);
        if (hp <= 0) {
            Score.instance.AddPoint (point);
            Explosion ();
            Destroy (gameObject);
        } else {
            animator.SetTrigger (damageHash);
        }
    }
}
