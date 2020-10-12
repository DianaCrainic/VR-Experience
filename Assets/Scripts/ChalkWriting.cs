using Boo.Lang;
using System;
using UnityEngine;

public class ChalkWriting : MonoBehaviour
{
    private Transform chalkTip;
    private List<Vector3> points = new List<Vector3>();
    private Color color = Color.black;

    // Start is called before the first frame update
    void Start()
    {
        chalkTip = gameObject.transform.GetChild(0);
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = lineRenderer.endColor = color;
        lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        points.Add(new Vector3(chalkTip.position.x, chalkTip.position.y, chalkTip.position.z));
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    private void OnEnable()
    {
        if (gameObject.GetComponent<LineRenderer>())
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 0;
        }

        points = new List<Vector3>();
    }
}
