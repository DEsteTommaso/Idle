using UnityEngine;

public class SeguiPersonaggio : MonoBehaviour
{
    public Transform target;         // Riferimento al personaggio che la camera deve seguire
    public Transform esca;
    public Transform torretta;
    public Transform muro;
    public Transform mostro;

    private float moveSpeed = 8.0f;   // Velocità di movimento della camera
    public Vector3 offset;           // Offset tra la camera e il personaggio
    private Vector3 desiredPosition; // Posizione desiderata della camera
    singleton singleton;

    private void Start()
    {
        singleton = singleton.Instance;
    }

    void LateUpdate()
    {
        if (singleton.EscaTutorial)
        {
            // Calcola la posizione desiderata della camera
            desiredPosition = new Vector3(esca.position.x + offset.x, esca.position.y + offset.y, transform.position.z);
        }
        else if (singleton.TorrettaTutorial)
        {
            desiredPosition = new Vector3(torretta.position.x + offset.x, torretta.position.y + offset.y, transform.position.z);
        }
        else if (singleton.MuroTutorial)
        {
            desiredPosition = new Vector3(muro.position.x + offset.x, muro.position.y + offset.y, transform.position.z);
        }
        else if (singleton.MostroTutorial)
        {
            if(mostro != null)
                desiredPosition = new Vector3(mostro.position.x + offset.x, mostro.position.y + offset.y, transform.position.z);
        }
        else if (target != null)
        {
            // Calcola la posizione desiderata della camera
            desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        }

        // Muovi la camera verso la posizione desiderata utilizzando la velocità
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, moveSpeed * Time.deltaTime);
    }
}
