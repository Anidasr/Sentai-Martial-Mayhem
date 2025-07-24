using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public Transform camTransform;
	public float shakeDuration = 1f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 3f;
	public float decreaseFactor = 1.0f;

	public bool shaketrue = false;

	Vector3 originalPos;
	float originalShakeDuration;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
		originalShakeDuration = shakeDuration; //<--add this
	}

	void Update()
	{
		if (shaketrue)
		{
			if (shakeDuration > 0)
			{
				camTransform.localPosition = Vector3.Lerp(camTransform.localPosition,originalPos + Random.insideUnitSphere * shakeAmount,Time.deltaTime * 3);

				shakeDuration -= Time.deltaTime * decreaseFactor;
			}
			else
			{
				shakeDuration = originalShakeDuration; //<--add this
				camTransform.localPosition = originalPos;
				shaketrue = false;
			}
		}
	}

	public void shakecamera()
	{
    	shaketrue = true;
	}
}
