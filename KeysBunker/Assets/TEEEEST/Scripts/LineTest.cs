using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class LineTest : MonoBehaviour, InputHandler  {

	private Vector3 lineStart = Vector3.zero;
	private Vector3 lineEnd;
	

	public void HandleTouchDown (Vector2 touch)
	{
		if (lineStart == Vector3.zero) {

			lineStart = new Vector3 (touch.x / Screen.width, touch.y / Screen.height, 0);
		}
		else {
			if (lineEnd != Vector3.zero)
			{
				lineStart = Vector3.zero;
				lineEnd = Vector3.zero;
				GetComponent<DrawingLine> ().vertices.Clear ();
				HandleTouchDown(touch);

			} else {
				lineEnd =  new Vector3 (touch.x / Screen.width, touch.y / Screen.height, 0);
				GetComponent<DrawingLine> ().vertices.Clear ();
				GetComponent<DrawingLine> ().vertices.Add (lineStart);
				GetComponent<DrawingLine> ().vertices.Add (lineEnd);
			}
		}
	}

	public void HandleTouchMove (Vector2 touch)
	{
	}

	public void HandleTouchUp (Vector2 touch)
	{
	}
	
}
