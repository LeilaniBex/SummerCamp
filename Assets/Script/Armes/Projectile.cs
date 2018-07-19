
using UnityEngine;

public class Projectile : MonoBehaviour
{
	#region Variables (public)

	public float m_fVitesse = 0.0f;
	public float m_fDistanceMax = 0.0f;



	#endregion

	#region Variables (private)

	private Vector3 m_tPositionDeDepart = Vector3.zero;
	private Vector3 m_tDirectionDeDepart = Vector3.forward;

	#endregion


	private void Start()
	{
		m_tPositionDeDepart = transform.position;
		m_tDirectionDeDepart = transform.forward;
	}

	private void Update()
	{
		DeplacerProjectile();
	}

	private void DeplacerProjectile()
	{

		Vector3 tTrajectoire = new Vector3(0.0f, 0.0f, 0.0f);

		tTrajectoire = m_tDirectionDeDepart * (m_fVitesse * Time.deltaTime);
		transform.position += tTrajectoire;

		if ((transform.position - m_tPositionDeDepart).sqrMagnitude >= (m_fDistanceMax * m_fDistanceMax))
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider pCollider)
	{
		if (pCollider.gameObject.layer != LayerMask.NameToLayer("Attaque") && pCollider.gameObject.layer != LayerMask.NameToLayer("Arme"))
		{
			Destroy(gameObject);
		}
	}
}
