using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class trocarModelo : MonoBehaviour
{

    [SerializeField] public GameObject[] modelos;
    [SerializeField] public int modelo;
    [SerializeField] Animator animar;
    [SerializeField] bool abrir;
    [SerializeField] GameObject prefabTeste;
    [SerializeField] Texture2D teste;
    [SerializeField] Sprite testando;
    [SerializeField] Image tassste;
    [SerializeField] GameObject cubao, tokenss;

    // Start is called before the first frame update
    void Start()
    {
        modelos = cubao.GetComponent<spawnTokem>().tokens;
    }

    // Update is called once per frame
    void Update()
    {
       /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (modelos[modelo] != null)
            {
                modelos[modelo].SetActive(false);
                modelo++;
                if(modelos[modelo] != null)
                {
                    modelos[modelo].SetActive(true);
                }
                else
                {
                    modelo = 0;
                    modelos[modelo].SetActive(true);
                }
            }
            
        }
        */
        
    }

    public void montro(int model)
    {
        if(tokenss != null)
        {
            Destroy(tokenss);
        }
        //modelos[modelo].SetActive(false);
        Quaternion rotationAgora = cubao.transform.rotation;
        cubao.transform.rotation = new Quaternion(0, 0, 0, 0);
        //cubao.transform.localScale = new Vector3(1, 1, 1);
        modelo = model;
        tokenss = Instantiate(modelos[modelo], cubao.transform.position + modelos[modelo].transform.position, modelos[modelo].transform.rotation);
        tokenss.transform.SetParent(cubao.transform);
        cubao.transform.rotation = rotationAgora;
       // cubao.transform.localScale = new Vector3(1.12f, 1.12f, 1.12f);
        //modelos[modelo].SetActive(true);
    }
    
    public void abriMenu()
    {
        if(abrir == true)
        {

            abrir = false;

        }
        else if(abrir == false)
        {

            abrir = true;

        }

        animar.SetBool("abrir", abrir);
    }
     
    private IEnumerator a()
    {
        yield return new WaitForSeconds(1f);
        print("2");
    }

    public void RetornarImage()
    {

       StartCoroutine(criartImagem());

    }

    WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();

    IEnumerator criartImagem()
    {
        yield return frameEnd;
        //teste = AssetPreview.GetAssetPreview(prefabTeste);
        testando = Sprite.Create(teste, new Rect(0, 0, 128, 128), new Vector2(0, 0));
        tassste.sprite = testando;
        byte[] testeando = teste.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/imagens/prefabs/" + prefabTeste.name + ".png", testeando);
        print(Application.dataPath + "/imagens/prefabs/" + prefabTeste.name + ".png");





    }

}
