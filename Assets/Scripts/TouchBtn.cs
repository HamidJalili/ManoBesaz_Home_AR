using UnityEngine;
using System.Collections;

public class TouchBtn : MonoBehaviour {

//	public Color defaultColor;
//	public Color selectedColor;

//	private Material mat;

	public AudioSource audioSource;
//	public AudioClip audioClip;

//	public GameObject MyObject;

	private Animator animator;

	void Start() {
//		mat = GetComponent<Renderer>().material;
		animator = GetComponent <Animator>();
        //audio is public
        //audioSource = GetComponent<AudioSource>();
    }

	void OnTouchDown() {

//		mat.color = selectedColor;

        if (animator)
        {
		animator.SetBool ("Touched", true);
		StartCoroutine (MyEnumeratorSeconds());
        }

        if (audioSource)
            audioSource.Play();
    }

	void OnTouchUp() {
//		mat.color = defaultColor;
	}

	void OnTouchStay() {
//		mat.color = selectedColor
	}

	void OnTouchExit() {
//		mat.color = defaultColor
	}

	IEnumerator MyEnumeratorSeconds() 
	{
		yield return new WaitForSeconds (0.5f);
		animator.SetBool ("Touched", false);
	}
}