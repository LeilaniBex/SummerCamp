using UnityEngine;


public class PersonnageJoueur : MonoBehaviour
{
	#region Variables (public)
	

	public Rigidbody m_pRigidBody = null;

	public int m_iPv = 20;

	public float m_fVitesse = 5.0f;
	public float m_fVitesseDeSaut = 0.0f;
	
	#endregion

	#region Variables (private)




	#endregion


	private void Start()
	{
	}

	private void Update()
	{
		MoveCharacter();
		Jump();
	}

	private void MoveCharacter()
	{
		float fHorizontal = Input.GetAxis("Horizontal");
		float fVertical = Input.GetAxis("Vertical");

		Vector3 tDirection = new Vector3(fHorizontal, 0.0f, fVertical);

		// Pression sur espace --> faire le reste de la fct° //
		if (tDirection != Vector3.zero)
		{
			tDirection = CameraPersonnage.Instance.transform.TransformDirection(tDirection);
			tDirection.y = 0.0f;

			if (tDirection.sqrMagnitude != 0.0f)
				tDirection.Normalize();
			else
				tDirection = transform.forward;


			Vector3 tDeplacement = tDirection * (m_fVitesse * Time.deltaTime);
			m_pRigidBody.MovePosition(transform.position += tDeplacement);


			transform.forward = tDirection;
		}
	 
	}
	private void Jump()
	{
		if (Input.GetButtonDown("Jump"))
		{
			Vector3 tJump = Vector3.up * m_fVitesseDeSaut;
			m_pRigidBody.AddForce(tJump, ForceMode.Impulse);
		}
	}
}
