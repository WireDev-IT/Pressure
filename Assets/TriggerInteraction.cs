using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerInteraction : MonoBehaviour
{
    private Collider2D[] objDetected;
    public Transform Position;
    public float height;
    public float width;
    public LayerMask InteractionLayer;

    public GameObject menu;

    void Start() {
        menu = GetComponent<GameObject>();
    }

    void Update()
    {
        objDetected = Physics2D.OverlapBox(
            Position.position,
            new Vector2(width, height),
            0,
            InteractionLayer
        );

        foreach (Collider2D colider in objDetected) {
            Debug.Log(collider.gameObject.name);
        }
        // Debug.Log(playerDetected);
        // if (Input.GetKeyDown(KeyCode.E)) { SceneManager.LoadScene("informatics_house_1"); }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Position.position, new Vector3(width, height, 1));
    }
}
