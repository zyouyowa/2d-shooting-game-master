using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public float speed = 1f;
    private new Renderer renderer;

    void Start () {
        renderer = GetComponent<Renderer> ();
    }

    void Update () {
        float y = Mathf.Repeat (Time.time * speed, 1f);
        Vector2 offset = new Vector2 (0f, y);
        renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
    }
}
