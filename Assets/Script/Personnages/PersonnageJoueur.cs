using UnityEngine;


public class PersonnageJoueur : Personnage
{
	#region Variables (public)


	public Rigidbody m_pRigidBody = null;
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
		Attaquer();
	}

	override protected void MoveCharacter()
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

	override protected void Attaquer()
	{
		if (Input.GetButtonDown("Fire1"))
		{

			Vector3 tDirectionDattaque = Input.mousePosition;		//On stock la position de la souris

			tDirectionDattaque.x /= Screen.width;					//On le transforme de (x=1920, y=1080) à (x=1, y=1)
			tDirectionDattaque.y /= Screen.height;

			tDirectionDattaque -= new Vector3(0.5f, 0.5f, 0.0f);    //On le prend par rapport au centre de l'ecran

			tDirectionDattaque.z = tDirectionDattaque.y;			//On echange le y et le z 
			tDirectionDattaque.y = 0.0f;

			tDirectionDattaque = CameraPersonnage.Instance.transform.TransformDirection(tDirectionDattaque);	//On transforme la direction de 
			tDirectionDattaque.y = 0.0f;																		//On aplatit la direction pour ne pas qu;il regarde vers le haut 

			if (tDirectionDattaque != Vector3.zero)
				transform.forward = tDirectionDattaque.normalized;

			base.Attaquer();

			
		}
	}
}