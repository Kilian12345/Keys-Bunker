using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using linepath;

public class MouseDashedLine : MonoBehaviour, IInputHandler {

	public GameObject lineDash;
	private Path pathController;
	private List<LineRenderer> lines;
	private bool collect = false;
	private float maxDistance = 0.01f;
	private int dashes = 0;
	private Vector2 touchPosition;
	private float baseDashLength = 0.3f;
	private float dashLength = 0.15f;


	public Color lineColor;

	void Awake ()
	{
		pathController = new Path();
		lines = new List<LineRenderer> ();
		var i = 0;
		while (i < 500) {
			var lineGo = Instantiate (lineDash) as GameObject;
			var line = lineGo.GetComponent<LineRenderer> ();
			line.material =  new Material(Shader.Find("Sprites/Default"));
			line.SetWidth (0.07f, 0.07f);
			line.SetColors(lineColor, lineColor);
			lineGo.SetActive (false);
			lineGo.transform.parent = transform;
			lines.Add (line);
			i++;
		}

	}

	public void HandleTouchDown (Vector2 touch) {

		touchPosition = Camera.main.ScreenToWorldPoint (touch);
		pathController.points.Clear ();
		collect = true; 
	}

	public void HandleTouchMove (Vector2 touch)
	{
		var t = Camera.main.ScreenToWorldPoint (touch);

		if (Vector2.Distance (t, touchPosition) < 0.01f)
			return;

		touchPosition = t;

		if (collect) {

			if (pathController.points.Count == 0) {
				pathController.AppendPoint (  touchPosition);
				DrawPath ();
			} else {
				Vector2 lastPoint = pathController.points [pathController.points.Count - 1].point;
				if (Vector2.Distance (touchPosition, lastPoint) > maxDistance) {
					
					pathController.AppendPoint (  touchPosition);
					DrawPath ();
				}

			}
		} 
	}


	public void HandleTouchUp (Vector2 touch)
	{
		pathController.Dispose ();
		collect = false;
		dashes = 0;
		foreach (var line in lines) {
			line.positionCount = 0;
			line.gameObject.SetActive ( false );
		}
	}



	void DrawPath () {


		float numPoints = pathController.totalLength/baseDashLength;

		float progressIncrement = 1.0f/numPoints;

		float p = 0.0f;
		int cnt = 0;

		while (p < 1.0f) {
			var point = pathController.GetPointAtProgress(p);
			if (point != null) {
				
				var p1 = point.point;

				if (cnt > dashes) {
					dashes++;
					var line = GetNextDash ();
					if (line != null) {
						line.SetVertexCount (2);
						line.useWorldSpace = true;	
						var p2 = new Vector2 (p1.x + dashLength * Mathf.Cos (point.angle),
							         p1.y + dashLength * Mathf.Sin (point.angle));
						line.SetPosition (0, p1);
						line.SetPosition (1, p2);
						line.gameObject.SetActive ( true );
					}
				}

				cnt++;

			} 
			p += progressIncrement;
		}


	}

	LineRenderer GetNextDash () {
		var i = 0;
		while (i < lines.Count) {
			if (!lines [i].gameObject.activeSelf)
				return lines [i];
			i++;
		}
		return null;
	}

}
