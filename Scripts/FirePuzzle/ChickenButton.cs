
using UnityEngine;

public class ChickenButton : Interactable
{
	//item mit dem interagiert werden kann
	public Animator chickenAnimator, buttonAnimator;
	public bool isPressed;

	public override void Interact(bool pressed)
	{
		if (pressed)
		{
			isPressed = !isPressed;
			chickenAnimator.SetBool("isPressed", isPressed);
			buttonAnimator.SetBool("isPressed", isPressed);
			gameObject.GetComponent<AudioSource>().Play();
		}
	}
}

