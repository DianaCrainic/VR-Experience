using System;
using UnityEngine;

public class ChalkWriting : MonoBehaviour
{
    private int vertice = 0;
    private Transform chalkTip;
    public Color color = Color.white;
    public int drawRate = 500;
    public int nextDraw = DateTime.Now.Millisecond;

    // Start is called before the first frame update
    void Start()
    {
        chalkTip = gameObject.transform.GetChild(0);
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = lineRenderer.endWidth = 0.15f;
        lineRenderer.startColor = lineRenderer.endColor = color;
        lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now.Millisecond > nextDraw)
        {
            nextDraw = DateTime.Now.Millisecond + drawRate;
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            // Debug.Log(chalkTip.position.x + " " + chalkTip.position.y + " " + chalkTip.position.z);
            lineRenderer.SetPosition(vertice++, new Vector3(chalkTip.position.x, chalkTip.position.y, chalkTip.position.z));
        }
    }
}
