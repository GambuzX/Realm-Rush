using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{

    [SerializeField][Range(1f, 20f)] float gridSize = 10f;
    private TextMesh cubeText;

    // Start is called before the first frame update
    void Start()
    {
        cubeText = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        this.transform.position = new Vector3(snapPos.x, this.transform.position.y, snapPos.z);
        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        cubeText.text = labelText;
        gameObject.name = "Cube " + labelText;
    }
}
