
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

		if (m_pNavMeshAgent.velocity == Vector3.zero)
			Attaquer();
	}

	private void LateUpdate()
	{
		if (m_pAnimator != null)
			AnimeMarche();
	}

	protected override void Attaquer()
	{
		Vector3 tDirection = (m_pCible.transform.position - transform.position).normalized;
		tDirection.y = 0.0f;
		transform.forward = tDirection.normalized;

		base.Attaquer();
	}

	protected override void MoveCharacter()
	{
		Vector3 tDirection = (m_pCible.transform.position - transform.position).normalized;

		RaycastHit tHit;

		if (Physics.Raycast(transform.position + Vector3.up, tDirection, out tHit, 300.0f, LayerMask.GetMask("Personnage"), QueryTriggerInteraction.Collide))
		{
			Vector3 tDestination = tHit.point - Vector3.up - (m_pNavMeshAgent.radius * tDirection /*notre largeur, vers l'arrière*/ );
			m_pNavMeshAgent.SetDestination(tDestination);
		}
	}

	private void AnimeMarche()
	{

		m_pAnimator.SetBool("Move", m_pNavMeshAgent.velocity != Vector3.zero);
	}

}
