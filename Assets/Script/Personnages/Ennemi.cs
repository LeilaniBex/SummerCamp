
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : Personnage
{
	#region Variables (public)

	public NavMeshAgent m_pNavMeshAgent = null;

	public Personnage m_pCible = null;

	public float m_fDistanceDArret = 0.0f;

	#endregion

	#region Variables (private)

	private float m_fDistanceEntreMoiEtCible = 0.0f;

	#endregion

	private void Start()
	{
		m_pNavMeshAgent.speed = m_fVitesse;
		m_pNavMeshAgent.stoppingDistance = m_fDistanceDArret;
	}

	private void Update()
	{
		if (m_pCible == null)
			return;

		// On sûr d'avoir une cible

		MoveCharacter();
	}

	private void LateUpdate()
	{
		if (m_pAnimator != null)
			AnimeMarche();
	}

	protected override void Attaquer()
	{
		
	}

	protected override void MoveCharacter()
	{
		
	}

	private void AnimeMarche()
	{
		m_pAnimator.SetBool("Move", m_pNavMeshAgent.velocity != Vector3.zero);
	}

}
