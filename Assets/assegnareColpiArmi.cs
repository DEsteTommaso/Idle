using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assegnareColpiArmi : MonoBehaviour
{
    public GameObject colpoNormale1;
    public GameObject colpoNormale2;
    public GameObject colpoNormale3;
    public GameObject colpoNormale4;
    public GameObject colpoNormale5;

    public GameObject colpoSpecialeArma3;
    public GameObject colpoSpecialeArma4;
    public GameObject colpoSpecialeArma5;

    public GameObject colpoSpecialeEroe1;
    public GameObject colpoSpecialeEroe2;
    public GameObject colpoSpecialeEroe3;

    singleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  /*  public void sparare(Transform personaggio)
{
    GameObject newPallottola = null; // Inizializza newPallottola come null

    if (singleton.AbilitaCliccataArma)
    {
        // Controllo quale delle tre abilità far ritornare
        if (singleton.SelezionatoArma3)
            newPallottola = Instantiate(colpoSpecialeArma3, personaggio.position, Quaternion.identity);
        else if (singleton.SelezionatoArma4)
            newPallottola = Instantiate(colpoSpecialeArma4, personaggio.position, Quaternion.identity);
        else if (singleton.SelezionatoArma5)
            newPallottola = Instantiate(colpoSpecialeArma5, personaggio.position, Quaternion.identity);
    }
    else if (singleton.AbilitaCliccataEroe)
    {
        // Controllo quale delle tre abilità far ritornare
        if (singleton.SelezionatoPersonaggio1)
            newPallottola = Instantiate(colpoSpecialeEroe1, personaggio.position, Quaternion.identity);
        else if (singleton.SelezionatoPersonaggio2)
            newPallottola = Instantiate(colpoSpecialeEroe2, personaggio.position, Quaternion.identity);
        else if (singleton.SelezionatoPersonaggio3)
            newPallottola = Instantiate(colpoSpecialeEroe3, personaggio.position, Quaternion.identity);
    }
    else
    {
        Debug.Log("e?");
        if (singleton.SelezionatoArma1)
            newPallottola = Instantiate(colpoNormale1, personaggio.position, Quaternion.identity);
        else if (singleton.SelezionatoArma2)
            newPallottola = Instantiate(colpoNormale2, personaggio.position, Quaternion.identity);
        else if (singleton.SelezionatoArma3)
            newPallottola = Instantiate(colpoNormale3, personaggio.position, Quaternion.identity);
        else if (singleton.SelezionatoArma4)
            newPallottola = Instantiate(colpoNormale4, personaggio.position, Quaternion.identity);
        else if (singleton.SelezionatoArma5)
        {
            Debug.Log("Se entra wua sono nella cacca");
            newPallottola = Instantiate(colpoNormale5, personaggio.position, Quaternion.identity);
        }
    }

    // Ora puoi fare riferimento al nuovo GameObject istanziato come newPallottola
    if (newPallottola != null)
    {
        Debug.Log("Gesu");
    }
}*/


    public GameObject getColpo()
    {
        //prima le abilità, poi i colpi normali
        if (singleton.AbilitaCliccataArma)
        {
            //prima dico che è stata usata
            singleton.AbilitaUsataArma = true;


            //controllo quale delle tre abilità far ritornare
            if (singleton.SelezionatoArma3)
                return colpoSpecialeArma3;
            else if (singleton.SelezionatoArma4)
                return colpoSpecialeArma4;
            else if (singleton.SelezionatoArma5)
                return colpoSpecialeArma5;
        }
        else if (singleton.AbilitaCliccataEroe)
        {

            //prima dico che è stata usata l'arma
            singleton.AbilitaUsataEroe = true;



            if (singleton.SelezionatoPersonaggio1)
                return colpoSpecialeEroe1;
            else if (singleton.SelezionatoPersonaggio2)
                return colpoSpecialeEroe2;
            else if (singleton.SelezionatoPersonaggio3)
                return colpoSpecialeEroe3;
        }
        else
        {


            if (singleton.SelezionatoArma1)
                return colpoNormale1;
            else if (singleton.SelezionatoArma2)
                return colpoNormale2;
            else if (singleton.SelezionatoArma3)
                return colpoNormale3;
            else if (singleton.SelezionatoArma4)
                return colpoNormale4;
            else if (singleton.SelezionatoArma5)
                return colpoNormale5;
        }

        //non dovrebbe mai arrivare qua
        return colpoNormale1;

    }

    public void setTraiettoria(GameObject colpo, Vector3 position)
    {
        if (singleton.AbilitaCliccataArma)
        {
            //dico che non è più cliccata
            singleton.AbilitaCliccataArma = false;
            //controllo quale delle tre abilità far ritornare
            if (singleton.SelezionatoArma3)
                colpo.GetComponent<pallottola_specialeBacchettaOscura>().setTarget(position);
            else if (singleton.SelezionatoArma4)
                colpo.GetComponent<pallottola_specialeBastoneGhiacciato>().setTarget(position);
            else if (singleton.SelezionatoArma5)
                colpo.GetComponent<pallottola_specialeVedovaNera>().setTarget(position);

        }
        else if (singleton.AbilitaCliccataEroe)
        {
            //non è più cliccata
            singleton.AbilitaCliccataEroe = false;
            if (singleton.SelezionatoPersonaggio1)
                colpo.GetComponent<pallottola_specialeBolla>().setTarget(position);
            else if (singleton.SelezionatoPersonaggio2)
                colpo.GetComponent<pallottola_specialeBomba>().setTarget(position);
            else if (singleton.SelezionatoPersonaggio3)
                colpo.GetComponent<pallottola_specialeBucoNero>().setTarget(position);
        }
        else
        {
            if (singleton.SelezionatoArma1)
                colpo.GetComponent<pallottola_bastonePrincipiante>().setTarget(position);
            else if (singleton.SelezionatoArma2)
                colpo.GetComponent<pallottola_bastoneLuminoso>().setTarget(position);
            else if (singleton.SelezionatoArma3)
                colpo.GetComponent<pallottola_bacchettaOscura>().setTarget(position);
            else if (singleton.SelezionatoArma4)
                colpo.GetComponent<pallottola_bastoneGhiacciato>().setTarget(position);
            else if (singleton.SelezionatoArma5)
                colpo.GetComponent<pallottola_vedovaNera>().setTarget(position);
        }
    }
}
