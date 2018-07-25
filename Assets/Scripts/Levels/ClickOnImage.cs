using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnImage : MonoBehaviour {

    public Transform OriginalPosition;
    public Transform CenterPoint;
    public Transform PointToCalculateRadius;
    public Transform PointToCalculateOffsetX;
    public Transform PointToCalculateOffsetY;
    public string imageName;

    private List<Vector2> centralPoints = new List<Vector2>();
    private int result = 0;
    private RawImage rawImage;
    private float radius;
    private float offsetX;
    private float offsetY;
    private Vector2 centralFirstPoint;
    // Use this for initialization
    void Start()
    {
        centralFirstPoint = new Vector2(CenterPoint.position.x, CenterPoint.position.y - (OriginalPosition.position.y - gameObject.transform.parent.position.y));
        radius = PointToCalculateRadius.position.x - centralFirstPoint.x;
        offsetX = PointToCalculateOffsetX.position.x - (centralFirstPoint.x + radius);
        offsetY = Mathf.Abs((PointToCalculateOffsetY.position.y - (OriginalPosition.position.y - gameObject.transform.parent.position.y)) - (centralFirstPoint.y - radius));
        /*Debug.Log("Center Point: " + centralFirstPoint);
        Debug.Log("Radius: " + radius);
        Debug.Log("OffsetX: " + offsetX);
        Debug.Log("OffsetY: " + offsetY);*/
        for (int i = 0; i < 10; i++)
        {
            Vector2 centralPoint = new Vector2(centralFirstPoint.x + radius * 2 * (i % 5) + offsetX * (i % 5), centralFirstPoint.y - (radius * (i / 5) + offsetY * (i / 5)));
            centralPoints.Add(centralPoint);
        }
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        result = CalculateCircle();
        if (rawImage != null)
        {
            rawImage.texture = Resources.Load("Images/" + imageName + result) as Texture2D;
        }
    }

    public int getResult()
    {
        return result;
    }

    public void ResetResult()
    {
        result = 0;
    }

    //Calculate position click in circles
    int CalculateCircle()
    {
        Vector2 pointClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        for (int i = 0; i < 10; i++)
        {
            float k = Mathf.Pow(pointClicked.x - centralPoints[i].x, 2) + Mathf.Pow(pointClicked.y - centralPoints[i].y, 2);
            if (k <= Mathf.Pow(radius, 2))
            {
                return i + 1;
            }
        }
        return 0;
    }
}
