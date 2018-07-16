using UnityEngine;


public class PersonnageJoueur : MonoBehaviour
{
  #region Variables (public)


    public int m_iPv = 20;

    public float m_fVitesse = 5.0f;
    
    #endregion

    #region Variables (private)




    #endregion


    private void Start()
    {
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        Vector3 tDirection = new Vector3(fHorizontal, 0.0f, fVertical);

        // Pression sur espace --> faire le reste de la fct° //
        if (tDirection != Vector3.zero)
        {
            tDirection.Normalize();

            Vector3 tDeplacement = tDirection * (m_fVitesse * Time.deltaTime);
            transform.position += tDeplacement;

            transform.forward = tDirection;
        }
     
    }

}
