
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
		Vector3 tDestination = m_pCible.transform.position;

		RaycastHit tHit;

		if (Physics.Raycast(transform.position + Vector3.up, (tDestination - transform.position).normalized, out tHit, 300.0f, LayerMask.GetMask("Personnage"), QueryTriggerInteraction.Collide))
			m_pNavMeshAgent.SetDestination(tHit.point - Vector3.up);

	}

	private void AnimeMarche()
	{
		m_pAnimator.SetBool("Move", m_pNavMeshAgent.velocity != Vector3.zero);
	}

}
