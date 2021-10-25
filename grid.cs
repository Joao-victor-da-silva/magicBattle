using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SimpleFileBrowser;
using Mirror;

public class grid : MonoBehaviour
{
    [SerializeField] private int subir, cont;
    [SerializeField] public Transform cubePrefeb, cube, selecionado, save1, texto;
    [SerializeField] private Transform gridd;
    [SerializeField] public bool editar, trocar;
    [SerializeField] float distancia, meio, real;
    [SerializeField] Vector3 posicaoIncicial;
    [SerializeField] int Metros;
    [SerializeField] LineRenderer line;
    [SerializeField] public GameObject painel, editarB, selecionarB, gridimage, gridimage02, slider, testo;
    [SerializeField] Texture2D gridMap;
    [SerializeField] string destinationPath, palavra;
    public bool permitir;
    Transform cubinho;
    public Transform filho;

    public RaycastHit Hit;

    public Text andares;
    Vector3 posicaoAnterior;

    public Vector3 tilepos, livre;
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        velocidade = 8f;
        permitir = true;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        cube.GetComponent<BoxCollider>().enabled = false;
        editar = false;
        trocar = false;
        save1 = cube;
        texto.gameObject.SetActive(false);

        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));
        FileBrowser.SetDefaultFilter(".jpg");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);

        filho = transform.Find("filho");
        posicaoAnterior = cube.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (filho == null)
        {
            filho = transform.Find("filho");
        }
        if(filho.gameObject.activeSelf == false)
        {
            filho.gameObject.SetActive(true);
        }
        
        texto.gameObject.GetComponent<Text>().text = "" + meio + " M";
        //distancia = Mathf.RoundToInt(distancia);
        Metros = (int)distancia;
        if(Metros == 0)
        {
            meio = Metros;
        }
        else if (Metros >= 1)
        {
            meio = 1.5f * Metros;
        }
        

        

        if (trocar == true && posicaoIncicial != null)
        {
            texto.gameObject.SetActive(true);
            //distancia = Vector3.Distance(posicaoIncicial, selecionado.position);
            distancia = Vector3.Distance(posicaoIncicial, tilepos);
        }
        else if(trocar == false && posicaoIncicial != null)
        {
            texto.gameObject.SetActive(false);
            distancia = 0;
            cont = 0;
            //posicaoIncicial = null;
        }


        if(selecionado != null && trocar == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                trocar = false;
                selecionado = null;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                selecionado.transform.Rotate(0, 45, 0);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                selecionado.transform.Rotate(0, -45, 0);
            }

        }



        if (editar == true)
        {
            cube.gameObject.SetActive(true);
        }
        else if (editar == false)
        {
            cube.gameObject.SetActive(false);
        }


        if (editar == true)
        {

            Vector3 quadPos = Vector3.up * subir;
            gridd.position = quadPos;

            if (Input.GetKeyDown(KeyCode.E))
            {
                cube.transform.Rotate(0, 45, 0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                cube.transform.Rotate(0, -45, 0);
            }
            if (cube.name == "Cube")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if(Hit.collider != null)
                    {
                        if (Hit.collider.gameObject.tag != ("chao") && cube.tag != ("pesas")
                            && permitir == true)
                        {
                            filho.gameObject.GetComponent<gridNetWork>().criarOb();
                            
                        }
                        if (Hit.collider.gameObject.tag == ("chao") && cube.tag == "pesas"
                            && permitir == true || Hit.collider.gameObject.tag == ("chao") && cube.tag == "detalhe"
                            && permitir == true)
                        {
                            filho.gameObject.GetComponent<gridNetWork>().criarOb();
                            
                        }
                    }
                    

                    /*
                     if (Hit.collider.gameObject.tag == ("chao") && cube.tag != "chao")
                    {
                        Instantiate(cube, cube.transform.position, cube.transform.rotation);
                    }
                     */


                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {


                    if (Hit.collider.gameObject.tag == "pesas" && cube.GetComponent<BoxCollider>().enabled == false)
                    {
                        if (Hit.collider.gameObject.name != "Cube")
                        {
                            Destroy(Hit.collider.gameObject);
                        }
                    }
                    if (Hit.collider.gameObject.tag == "chao" && cube.GetComponent<BoxCollider>().enabled == false
                        || Hit.collider.gameObject.tag == "detalhe" && cube.GetComponent<BoxCollider>().enabled == false)
                    {
                        if (Hit.collider.gameObject.name != "Cube")
                        {
                            Destroy(Hit.collider.gameObject);
                        }
                    }

                }
            }


            /////teste

        }

        teste();

        if(editar == false)
        {
            if(Hit.collider != null)
            {
                if(Hit.collider.gameObject.tag == "pesas")
                {
                    if(painel.activeSelf == false && line.enabled == false)
                    {
                        selecionado = Hit.collider.gameObject.transform;
                    }
                    
                    
                }
                
            }
        }

        if (destinationPath != "")
        {
            if (destinationPath != palavra)
            {
                palavra = destinationPath;
                Destroy(gridimage.GetComponent<BoxCollider>());
                WWW www = new WWW("file:///" + destinationPath);
                Sprite desenho = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
                gridimage.GetComponent<SpriteRenderer>().sprite = desenho;
                gridimage02.GetComponent<Image>().sprite = desenho;
                print("cripou");
                gridimage.AddComponent<BoxCollider>();
            }
        
           
        }
        subindo();
    }

    
    void Spawn()
    {

       
        

        print("sevidor ta on");
        
    }


    private void teste()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out Hit, 1000f))
        {
            if (cube.transform.childCount > 0 && editar == true)
            {
                if (cube.transform.GetChild(0).tag == "detalhe")
                {
                    tilepos = new Vector3(Hit.point.x, subir, Hit.point.z);
                }
                else
                {
                    tilepos = new Vector3(Mathf.RoundToInt(Hit.point.x), subir, Mathf.RoundToInt(Hit.point.z));
                }
            }
            if (editar == false)
            {
                tilepos = new Vector3(Mathf.RoundToInt(Hit.point.x), subir, Mathf.RoundToInt(Hit.point.z));
            }
            

            if (Hit.collider != null)
            {
                if(trocar  == false)
                {

                    cube.position = Vector3.Lerp(cube.position, tilepos, velocidade * Time.deltaTime);
                    //cube.position = tilepos;
                    //cube.position = Vector3.Lerp(cube.position, livre, velocidade * Time.deltaTime);
                    line.enabled = false;
                }
                else
                {
                   
                    if (trocar == true && cont == 0)
                    {
                        posicaoIncicial =  new Vector3(Mathf.RoundToInt(selecionado.position.x), Mathf.RoundToInt(selecionado.position.y), Mathf.RoundToInt(selecionado.position.z));
                        cont = 1;
                    }

                    if (cont == 1)
                    {
                        //selecionado.position = tilepos;
                        selecionado.position = Vector3.Lerp(selecionado.position, tilepos, velocidade * Time.deltaTime);
                    }
                    

                    if (trocar == true)
                    {
                        line.enabled = true;
                        line.SetPosition(0, posicaoIncicial + new Vector3(0,0.05f,0));
                        line.SetPosition(1, selecionado.position + new Vector3(0, 0.05f, 0));
                    }

                }
                
            }
        }

    }

    public void subindo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            botaoSubir();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            botaoDecer();
        }

        andares.text = "Andar: " + subir;

    }

    public void botaoSubir()
    {
        subir++;
    }
    public void botaoDecer()
    {
        subir--;
    }

    public void editarr()
    {
        editarB.GetComponent<Button>().interactable = false;
        selecionarB.GetComponent<Button>().interactable = true;
        editar = true;
    }

    public void selecionarr()
    {
        editarB.GetComponent<Button>().interactable = true;
        selecionarB.GetComponent<Button>().interactable = false;
        editar = false;
    }


    public void deletar()
    {
        Destroy(selecionado.gameObject);
    }

    public void selecionar()
    {
        trocar = true;
    }

    public void selecionarTextura()
    {

        StartCoroutine(ShowLoadDialogCoroutine());

    }

    public void aumentar()
    {
        gridimage.transform.localScale = new Vector3(slider.GetComponent<Slider>().value
, slider.GetComponent<Slider>().value, slider.GetComponent<Slider>().value);
        testo.GetComponent<Text>().text = "" + slider.GetComponent<Slider>().value;
    }

    public void cima()
    {
        gridimage.transform.Translate(0, -0.01f, 0);
    }
    public void baixo()
    {
        gridimage.transform.Translate(0, 0.01f, 0);
    }
    public void direita()
    {

        gridimage.transform.Translate(0.01f, 0, 0);
    }
    public void esquerda()
    {
        gridimage.transform.Translate(-0.01f,0, 0);
    }

    public void visible()
    {
        if(gridimage.activeSelf == true)
        {
            gridimage.SetActive(false);
        }
        else
        {
            gridimage.SetActive(true);
        }
       
    }

    IEnumerator ShowLoadDialogCoroutine()
    {

        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
        {

            for (int i = 0; i < FileBrowser.Result.Length; i++)
                Debug.Log(FileBrowser.Result[i]);


            byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);


            destinationPath = Path.Combine(Application.persistentDataPath, FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
            FileBrowserHelpers.CopyFile(FileBrowser.Result[0], destinationPath);
        }
    }






}
