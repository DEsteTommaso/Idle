using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Purchasing;
using UnityEngine.UI;

[Serializable]
public class Money15000
{
    public string name;
    public string id;
    public string desc;
    public float price;
}

[Serializable]
public class Money50000
{
    public string name;
    public string id;
    public string desc;
    public float price;
}

[Serializable]
public class Money125000
{
    public string name;
    public string id;
    public string desc;
    public float price;
}

[Serializable]
public class Rabbit
{
    public string name;
    public string id;
    public string desc;
    public float price;
}

[Serializable]
public class vedovaArma
{
    public string name;
    public string id;
    public string desc;
    public float price;
}



public class iapManager : MonoBehaviour, IStoreListener
{

    IStoreController m_storeController;

    public Money15000 money15k;
    public Money50000 money50k;
    public Money125000 money125k;

    public Rabbit rabbit;
    public vedovaArma vedovaNera;

    //pulsanti
    public Button pulsanteMoneta15k;
    public Button pulsanteMoneta50k;
    public Button pulsanteMoneta125k;

    public Button pulsanteMrRabbit;
    public Button pulsanteVedovaNera;

    //refresh Mr.Rabbit e Vedova Nera
    public GameObject rabbitGameObject;
    public GameObject vedovaNeraGameObject;

    singleton singleton;


    // Start is called before the first frame update
    void Start()
    {
        singleton = singleton.Instance;

        SetupBuilder();
    }

    public void money15kMethod()
    {
        m_storeController.InitiatePurchase(money15k.id);
    }

    public void money50kMethod()
    {
        m_storeController.InitiatePurchase(money50k.id);
    }

    public void money125kMethod()
    {
        m_storeController.InitiatePurchase(money125k.id);
    }

    public void rabbitMethod()
    {
        //l'if per controllare che non sia già stato acquistato
        if (!singleton.CompratoPersonaggio3)
            m_storeController.InitiatePurchase(rabbit.id);
    }

    public void vedovaNeraMethod()
    {
        //l'if per controllare che non sia già stato acquistato
        if(!singleton.CompratoArma5)
            m_storeController.InitiatePurchase(vedovaNera.id);
    }

    //serve per assegnare le ricompense
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        //Retrive the purchased product
        var product = purchaseEvent.purchasedProduct;

        print("Purchase Complete " + product.definition.id);

        if(product.definition.id == money15k.id)
        {
            singleton.addMoneta(15000);
        }
        else if( product.definition.id == money50k.id){
            singleton.addMoneta(50000);
        }
        else if(product.definition.id == money125k.id)
        {
            singleton.addMoneta(125000);
        }
        else if (product.definition.id == rabbit.id && !singleton.CompratoPersonaggio3)
        {
            singleton.CompratoPersonaggio3 = true;
            singleton.SelezionatoPersonaggio3 = true;
            Debug.Log("Qua non dovresti entrsre1");
            //faccio in modo che compaia la scritta di selezionato
            if(rabbitGameObject.GetComponent<pulsanteEroe3>() != null)
                rabbitGameObject.GetComponent<pulsanteEroe3>().refresh();
        }
        else if (product.definition.id == vedovaNera.id && !singleton.CompratoArma5)
        {
            Debug.Log("Qua non dovresti entrare 2");
            singleton.CompratoArma5 = true;
            singleton.SelezionatoArma5 = true;
            //faccio in modo che compaia la scritta di selezionato
            if(vedovaNeraGameObject.GetComponent<pulsanteArma5>() != null)
                vedovaNeraGameObject.GetComponent<pulsanteArma5>().refresh();
        }
        return PurchaseProcessingResult.Complete;
    }


    void SetupBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(money15k.id, ProductType.Consumable);
        builder.AddProduct(money50k.id, ProductType.Consumable);
        builder.AddProduct(money125k.id, ProductType.Consumable);

        builder.AddProduct(rabbit.id, ProductType.NonConsumable);
        builder.AddProduct(vedovaNera.id, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        print("Success");
        m_storeController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        print("Initialized failed " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        print("Initialized failed " + error+message);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        print("purchased failed ");
    }



    
}
