
using UnityEngine;

public class Projectile : MonoBehaviour
{
	#region Variables (public)

	public float m_fVitesse = 0.0f;
	public float m_fDistanceMax = 0.0f;



	#endregion

	#region Variables (private)



	#endregion

	private void Update()
	{
		DeplacerProjectile();
	}

	private void DeplacerProjectile()
	{
		Vector3 tTrajectoire = new Vector3(0.0f, 0.0f, 0.0f);

		tTrajectoire = transform.forward * (m_fVitesse * Time.deltaTime);

		transform.position += tTrajectoire;
	}
}
