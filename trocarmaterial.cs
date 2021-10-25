using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class trocarmaterial : MonoBehaviour
{

    [SerializeField] public Transform filho, pai;
    [SerializeField] Material selecionar, material;
    [SerializeField] public GameObject grids, painel, luz;
    int cont, cont01;
    [SerializeField] public TextMeshProUGUI nome;
    [SerializeField] public string nickNeme;
    [SerializeField] public int idCor;
    public bool combatendo, combate;
    public GameObject iniciativas;
    public Transform[] filhos;



    // Start is called before the first frame update
    void Start()
    {
        

        combatendo = false;
        if (painel == null)
        {
            painel = Camera.main.gameObject.GetComponent<grid>().painel;
        }
        
        cont = 1;
        if (gameObject.tag != "chao" && gameObject.tag != "detalhe")
        {
            nome = transform.Find("Canvas").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
            transform.Find("Canvas").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().enabled = false;
        }
        
        grids = Camera.main.gameObject;

        filho = transform.Find("default");
        pai = transform.parent;

        material = filho.GetComponent<Renderer>().material;



        if (transform.parent.name != "Cube")
        {
            transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
            //filho.gameObject.AddComponent<NetworkIdentity>();
            //filho.gameObject.AddComponent<NetworkTransform>();
            NetworkServer.Spawn(filho.gameObject);
        }
        

        if(transform.parent.name != "Cube")
        {
            if (transform.name == "chao")
            {
               // Destroy(nome.transform.parent.gameObject);
            }
        }
        
        

        
        

        if (transform.parent.name == "Cube")
        {
            filho.GetComponent<Renderer>().material = new Material(selecionar);
            if (filho.transform.childCount > 0)
            {
                filho.transform.GetChild(0).GetComponent<Renderer>().material = new Material(selecionar);
            }
            

            filhos = new Transform[transform.childCount];

            for (int io = 0; io < transform.childCount; io++)
            {
                filhos[io] = transform.GetChild(io);
                if (filhos[io].GetComponent<Renderer>())
                {
                    filhos[io].GetComponent<Renderer>().material = new Material(selecionar);
                    mudarMateriasIrmas(io);
                    
                }
                
            }
        }
        if (transform.parent.name != "Cube")
        {
            filho.GetComponent<Renderer>().material = new Material(material);
        }

        if (transform.parent.name != "Cube")
        {
            filho.gameObject.AddComponent<Outline>();
            filho.gameObject.GetComponent<Outline>().enabled = false;
        }
        if(transform.parent.name != "Cube" && gameObject.tag == "chao" || transform.parent.name != "Cube" && gameObject.tag == "detalhe")
        {
            transform.parent.GetComponent<BoxCollider>().size = new Vector3(1, 0.5f, 1);
            if (luz != null)
            {
                Destroy(luz);
            }
            
        }

        if (pai.name != "Cube")
        {
            nickNeme = gameObject.name;
            trocarNome();
        }
        

    }

    public void mudarMateriasIrmas(int contes)
    {

        Material[] teste = new Material[filhos[contes].GetComponent<Renderer>().materials.Length];

        for (int i = 0; i < filhos[contes].GetComponent<Renderer>().materials.Length; i++)
        {
            print("tomateGrulll03");
            teste[i] = new Material(selecionar);
           // filhos[contes].GetComponent<Renderer>().materials[i] = new Material(selecionar);
        }
        filhos[contes].GetComponent<Renderer>().materials = teste;
    }

    public void passarIdCor()
    {
        pai.gameObject.GetComponent<spawnTokem>().idCor = idCor;
    }

    // Update is called once per frame
    void Update()
    {

        if(iniciativas != null)
        {
            if(iniciativas.GetComponent<iniciativa>().combatendo == false)
            {
                combate = false;
            }
        }




        //Habilitar e desabilitar Outline 

        if (grids.gameObject.GetComponent<grid>().Hit.collider != null && combatendo == false)
        {
            if (grids.gameObject.GetComponent<grid>().editar == false &&
            grids.gameObject.GetComponent<grid>().Hit.collider.gameObject == transform.parent.gameObject
            && painel.activeSelf == false)
            {
                filho.gameObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                if (transform.parent.name != "Cube" && painel.activeSelf == false)
                {
                  
                    filho.gameObject.GetComponent<Outline>().enabled = false;
                }

            }
        }

        //Mudar Material e shadowCastingMode

        if (pai.name == "Cube(Clone)" && gameObject.name == "parede" && grids.GetComponent<grid>().editar == false && cont == 0)
        {
            cont = 1;
            filho.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            filho.GetComponent<Renderer>().material = new Material(material);
        }
        else if(pai.name == "Cube(Clone)" && gameObject.name == "parede" && grids.GetComponent<grid>().editar == true && cont == 1)
        {
            cont = 0;
            filho.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            filho.GetComponent<Renderer>().material = new Material(selecionar);
        }

        //Mudar Tag

        transform.parent.tag = this.gameObject.tag;

        if (pai.name == "Cube(Clone)")
        {

            transform.parent.tag = this.gameObject.tag;

            /*
            if (gameObject.tag == "chao")
            {
                transform.parent.tag = "chao";
            }
            if (gameObject.tag != "chao")
            {
                transform.parent.tag = "pesas";
            }*/


        }
        



        //Mudar Cor

        if (grids.GetComponent<grid>().selecionado != null)
        {
            if (grids.GetComponent<grid>().selecionado == pai.transform && pai.tag != "chao" && pai.tag != "detalhe")
            {
                painel.transform.parent.gameObject.GetComponent<menu>().pesaCor = filho.gameObject;
            }
        }
        


    }

    public void trocarNome()
    {
        if (nome != null)
        {
            nome.text = nickNeme;
            nome.enabled = true;
        }
    }

    

}
