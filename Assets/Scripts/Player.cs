﻿using System.Collections;using UnityEngine;public class Player : MonoBehaviour {    public float speed = 5f;    public GameObject bullet;    private Rigidbody2D rigidbody2d;	void Start () {        rigidbody2d = GetComponent<Rigidbody2D>();        StartCoroutine(StartShot());	}    IEnumerator StartShot(){        WaitForSeconds wait = new WaitForSeconds(0.05f);        while(true){            Instantiate(bullet, transform.position, transform.rotation);            yield return wait;        }    }		void Update () {        float x = Input.GetAxisRaw("Horizontal");        float y = Input.GetAxisRaw("Vertical");        Vector2 direction = new Vector2(x, y).normalized;        rigidbody2d.velocity = direction * speed;	}}