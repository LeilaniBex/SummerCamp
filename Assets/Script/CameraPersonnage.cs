
using UnityEngine;

public class CameraPersonnage : MonoBehaviour
{
	#region  Variables (public)

	static public CameraPersonnage Instance = null;

	public PersonnageJoueur m_pTarget = null;

	public Transform m_pCameraTransform = null;

	public Camera m_pCamera = null;

	public float m_fDistanceDeSuivi = 0.0f;

	public float m_fVitesseDeRotation = 0.0f;


	#endregion


	#region Variables (private)




	#endregion

	private void Awake()
	{
		if (CameraPersonnage.Instance != null)
		{
			if (CameraPersonnage.Instance != this)
				Destroy(this);

			Debug.LogError("Attention, deux CameraPersonnage dans la scene");

			return;
		}

		CameraPersonnage.Instance = this;
	}

	private void Update()
	{
		TournerCamera();
	}

	private void LateUpdate()
	{
		if (m_pTarget != null)
		SuivrePersonnage();
	
	}
	
	private void SuivrePersonnage()
	{
		Vector3 tNouvellePositionPoint = m_pTarget.transform.position + Vector3.up;
		transform.position = tNouvellePositionPoint;

		Vector3 tNouvellePositionCamera = tNouvellePositionPoint - (m_pCameraTransform.forward * m_fDistanceDeSuivi);
		m_pCameraTransform.position = tNouvellePositionCamera;

	}

	private void TournerCamera()
	{
		float fMouseX = Input.GetAxis("Mouse X");

		Vector3 tRotationX = new Vector3(0.0f, fMouseX, 0.0f) * (m_fVitesseDeRotation * Time.deltaTime);

		if (tRotationX != Vector3.zero)
		{
			transform.eulerAngles += tRotationX;
		}

		///float fMouseY = Input.GetAxis("Mouse Y");

		///Vector3 tRotationY = new Vector3(fMouseY, 0.0f, 0.0f) * (m_fVitesseDeRotation * Time.deltaTime);

		///if (tRotationY != Vector3.zero)
		///{
		///transform.eulerAngles += tRotationY;}

		
	}
}