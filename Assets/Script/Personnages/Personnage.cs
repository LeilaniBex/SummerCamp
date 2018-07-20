
using UnityEngine;

abstract public class Personnage : MonoBehaviour
{
	#region Variables (public)


	public Arme m_pArme = null;

	public Animator m_pAnimator = null;

	public int m_iPv = 20;

	public float m_fVitesse = 5.0f;

	#endregion

	#region Variables (private)



	#endregion

	abstract protected void MoveCharacter();

	/// <summary>
	/// Lance l'attaque de mon arme si elle existe
	/// </summary>

	virtual protected void Attaquer()
	{
		m_pArme?.Attaquer();
	}
}
