using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    private static ObjectPool _instance;

    public static ObjectPool instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<ObjectPool> ();
                if (_instance == null) {
                    _instance = new GameObject ("ObjectPool").AddComponent<ObjectPool> ();
                }
            }
            return _instance;
        }
    }

    private Dictionary<int, List<GameObject>> pooledGameObjects = new Dictionary<int, List<GameObject>> ();

    public GameObject GetGameObject (GameObject prefab, Vector2 position, Quaternion rotation) {
        int key = prefab.GetInstanceID ();
        if (!pooledGameObjects.ContainsKey (key)) {
            pooledGameObjects.Add (key, new List<GameObject> ());
        }
        List<GameObject> gameObjects = pooledGameObjects [key];

        GameObject go = null;
        for (int i = 0; i < gameObjects.Count; i++) {
            go = gameObjects [i];
            if (!go.activeInHierarchy) {
                go.transform.position = position;
                go.transform.rotation = rotation;
                go.SetActive (true);
                return go;
            }
        }

        go = Instantiate (prefab, position, rotation) as GameObject;
        go.transform.SetParent (transform);
        gameObjects.Add (go);
        return go;
    }

    public void ReleaseGameObject (GameObject go) {
        go.SetActive (false);
    }
}
