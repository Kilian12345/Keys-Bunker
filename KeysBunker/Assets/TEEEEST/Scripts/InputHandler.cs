using UnityEngine;
using System.Collections;

public interface InputHandler {

	void HandleTouchDown (Vector2 touch);
	void HandleTouchMove (Vector2 touch);
	void HandleTouchUp (Vector2 touch);
}
