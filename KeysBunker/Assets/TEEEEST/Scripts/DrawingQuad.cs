﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawingQuad : MonoBehaviour
{    
	public List<Vector3> vertices;

	public bool drawQuads;

	private Material lineMaterial;

	private float thickness = 0.01f;

	void Start ()
	{
		vertices = new List<Vector3> ();
		var shader = Shader.Find ("Unlit/Color");
		lineMaterial = new Material (shader);
		lineMaterial.color = Color.red;
		lineMaterial.hideFlags = HideFlags.HideAndDontSave;
	}

	public void OnRenderObject ()
	{
		if (vertices.Count == 2) {

			lineMaterial.SetPass (0);

			GL.PushMatrix ();
			GL.LoadOrtho();

			var i = 0;

			if (drawQuads) {

				GL.Begin(GL.QUADS);

				while (i < vertices.Count) {

					if (i > 0) {

						var point1 = vertices[i-1];
						var point2 = vertices[i];

						Vector2 startPoint = Vector2.zero;
						Vector2 endPoint = Vector2.zero;

						var diffx = Mathf.Abs(point1.x - point2.x);
						var diffy = Mathf.Abs(point1.y - point2.y);

						if (diffx > diffy) {
							if (point1.x <= point2.x) {
								startPoint = point1;	
								endPoint = point2;
							} else {
								startPoint = point2;
								endPoint = point1;
							}
						} else {
							if (point1.y <= point2.y) {
								startPoint = point1;	
								endPoint = point2;
							} else {
								startPoint = point2;
								endPoint = point1;
							}
						}

						var angle = Mathf.Atan2(endPoint.y - startPoint.y, endPoint.x - startPoint.x);
						var perp = angle + Mathf.PI * 0.5f;

						var p1 = Vector3.zero;
						var p2 = Vector3.zero;
						var p3 = Vector3.zero;
						var p4 = Vector3.zero;

						var cosAngle = Mathf.Cos (angle);
						var cosPerp = Mathf.Cos (perp);
						var sinAngle = Mathf.Sin (angle);
						var sinPerp = Mathf.Sin (perp);

						var distance = Vector2.Distance(startPoint, endPoint);

						p1.x = startPoint.x - (thickness * 0.5f) * cosPerp;
						p1.y = startPoint.y - (thickness * 0.5f) * sinPerp;
						
						p2.x = startPoint.x + (thickness * 0.5f) * cosPerp;
						p2.y = startPoint.y + (thickness * 0.5f) * sinPerp;
						
						p3.x = p2.x + distance * cosAngle;
						p3.y = p2.y + distance * sinAngle;
						
						p4.x = p1.x + distance * cosAngle;
						p4.y = p1.y + distance * sinAngle;
						
						GL.Vertex3 (p1.x, p1.y, 0);
						GL.Vertex3 (p2.x, p2.y, 0);
						GL.Vertex3 (p3.x, p3.y, 0);
						GL.Vertex3 (p4.x, p4.y, 0);

					}
					i++;
				}
			}
			else
			{

				GL.Begin(GL.LINES);

				while (i < vertices.Count) {

					GL.Vertex(vertices[i]);
					i++;
				}

			}

			GL.End ();
			GL.PopMatrix ();
		}
	}
}