using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawingLine : MonoBehaviour
{    
	public List<Vector3> vertices;

	private Material lineMaterial;
	
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

			GL.Begin(GL.LINES);

			while (i < vertices.Count) {

				GL.Vertex(vertices[i]);
				i++;
			}

			GL.End ();
			GL.PopMatrix ();
		}
	}
}