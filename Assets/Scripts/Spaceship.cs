using UnityEngine;


public abstract class Spaceship : MonoBehaviour {
    public float speed = 10f;
    public float shotDelay;
    public GameObject bullet;
    public bool canShot;
    public GameObject explosion;

    public void Explosion () {
        //ObjectPool.instance.GetGameObject (explosion, transform.position, transform.rotation);
        Instantiate (explosion, transform.position, transform.rotation);
    }

    public void Shot (Transform origin) {
        //ObjectPool.instance.GetGameObject (bullet, origin.position, origin.rotation);
        Instantiate (bullet, origin.position, origin.rotation);
    }

    public abstract void Move (Vector2 direction);
}
