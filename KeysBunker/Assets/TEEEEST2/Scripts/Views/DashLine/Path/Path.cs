using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace linepath {

	public class Path {

		[HideInInspector]
		public float totalLength;

		[HideInInspector]
		public List<PathPoint> points;

		private PathPoint first;

		public Path () {
			points = new List<PathPoint>();
			totalLength = 0f;

		}

		public void AppendPoint (Vector2 point) {
			InsertPoint(point, points.Count, false);
		}
		
		public void InsertMultiplePoints(List<Vector2> points, int index) {
			int len = points.Count;
			for (int i = 0; i < len; i++) {
				InsertPoint(points[i], index + i, true);
			}
		}
		
		public PathPoint GetPointAtProgress (float progress) {

			progress = Mathf.Abs(progress);
			
			PathPoint point = new PathPoint (10, 10);
			if (progress > 1) progress = 1;
			PathPoint pp = first;
			if (pp == null || pp.next == null) return null;
			if (pp.next.progress < 0) return null;
			
			while (pp.next != null && pp.next.progress < progress) {
				pp = pp.next;
			}
			
			if (pp != null) {
				
				if (pp.length == 0) return null;
				float pathProg = (progress - pp.progress) / (pp.length / totalLength);
				point.SetPoint (pp.x + pathProg * pp.xChange, pp.y + pathProg * pp.yChange);
				point.angle = pp.angle;
				return point;
				
			}
			return null;
		}
		
		public void Dispose () {
			points = new List<PathPoint>();
			totalLength = 0f;
			first = null;
		}
		
		
		public void SetPoints(List<Vector2> value) {
			
			points.Clear();
			InsertMultiplePoints(value, 0);
		}
		
		
		private void InsertPoint(Vector2 point, int index, bool skipOrganize)  {

			if (index > 0) {
				var prev = points [index - 1];
				if (Vector2.Distance (prev.point, point) < 0.01f)
					return;
			}

			PathPoint p = new PathPoint (0,0);
			p.SetPoint(point);


			if (points.Count == 0) {
				points.Add(p);
			} else {
				points.Insert(index, p);
			}
			
			if (!skipOrganize) {
				Organize();
			}
		}
		
		private void Organize() {

			totalLength = 0;
			int last = points.Count - 1;

			if (last == -1) {
				first = null;
			} else if (last == 0) {
				first = points[0];
				first.progress = first.xChange = first.yChange = first.length = 0;
				return;
			}
			PathPoint pp = null;
			for (int i = 0; i <= last; i++) { 
				if (points[i] != null) {
					pp = points[i];
					if (i == last) {
						pp.length = 0;
						pp.next = null;
					} else {
						pp.next = points[i + 1];

						pp.xChange = pp.next.x - pp.x;
						pp.yChange = pp.next.y - pp.y;
						pp.length = (float) Mathf.Sqrt(pp.xChange * pp.xChange + pp.yChange * pp.yChange);
						totalLength += pp.length;
					}
				}
			}
			first = pp = points[0];
			float curTotal = 0f;
			while (pp != null) {
				pp.progress = curTotal / totalLength;
				curTotal += pp.length;
				pp = pp.next;
			}
			UpdateAngles();
		}
		
		private void UpdateAngles() {
			PathPoint pp = first;
			while (pp != null) {
				pp.angle = (float) Mathf.Atan2(pp.yChange, pp.xChange ) ;
				pp = pp.next;
			}
		}

		public class PathPoint  {

			public float x;
			public float y;
			public float progress;
			public float xChange;
			public float yChange;
			public Vector2 point;
			public float length;
			public float angle;
			public PathPoint next;

			public PathPoint (float x, float y) {
				this.x = x;
				this.y = y;
				this.point = new Vector2 (x, y);
				progress = -1;
			}

			public void SetPoint (Vector2 p) {
				this.x = this.point.x = p.x;
				this.y = this.point.y = p.y;
				progress = -1;
			}

			public void SetPoint (float x, float y) {
				this.x = this.point.x = x;
				this.y = this.point.y = y;
			}

			public void Reset () {
				x = y = progress = xChange = yChange = length = angle = 0;
				next = null;
				point = Vector2.zero;
			}
		}

	}


}

