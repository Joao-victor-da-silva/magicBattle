using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror.Examples.Chat;

public class movimentoCamera : MonoBehaviour
{

    [SerializeField] float velocidade, velocidadeRotacao, save1, save2,scrol, velocidadeScrol;
    [SerializeField] bool girar, subir,  decer;
    [SerializeField] private GameObject painel, cameraa, p01, p02;
    [SerializeField] private GameObject d4, d6, d8, d10, d12, d20, d100;
    [SerializeField] private GameObject bd4, bd6, bd8, bd10, bd12, bd20, bd100, roll;
    [SerializeField] int d4n, d6n, d8n, d10n, d12n, d20n, d100n;
    [SerializeField] GameObject cava, caixa, imagem, postProcecing, chat;
    [SerializeField] int cont20, cont4, cont6, cont8, cont10, cont12, cont100;
    [SerializeField] Sprite foto;
    [SerializeField] GameObject d4t, d6t, d8t, d10t, d12t, d20t, d100t;
    public string menssagem;
    int oii;
    public GameObject seguir;


    // Start is called before the first frame update
    void Start()
    {
        oii = 1;
        cameraa = Camera.main.gameObject;
        save1 = velocidade;
        save2 = velocidadeRotacao;
        cameraa.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        subirCamera();


        cameraa.SetActive(true);
        if (painel.activeSelf == true)
        {
            velocidade = 0;
            velocidadeRotacao = 0;
        }
        else
        {
            velocidade = save1;
            velocidadeRotacao = save2;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            girar = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse2))
        {
            girar = false;
        }

        if(girar == false)
        {

            if (Input.mousePosition.y >= Screen.height - 10f)
            {
                transform.Translate(0, 0, 1 * Time.deltaTime * velocidade);
            }
            if (Input.mousePosition.y <= 10f)
            {
                transform.Translate(0, 0, -1 * Time.deltaTime * velocidade);
            }
            if (Input.mousePosition.x >= Screen.width - 10f)
            {
                transform.Translate(1 * Time.deltaTime * velocidade, 0, 0);
            }
            if (Input.mousePosition.x <= 10f)
            {
                transform.Translate(-1 * Time.deltaTime * velocidade, 0, 0);
            }


            transform.Translate(x * Time.deltaTime * velocidade, 0, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidade);
        }
        if(girar == true)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadeRotacao, 0);

            if (Input.mousePosition.x >= Screen.width - 10f)
            {
                transform.Rotate(0, 1 * Time.deltaTime * velocidadeRotacao, 0);
            }
            if (Input.mousePosition.x <= 10f)
            {
                transform.Rotate(0, -1 * Time.deltaTime * velocidadeRotacao, 0);
            }

        }
       


        if (d4n == 0 && d6n == 0 && d8n == 0 && d10n == 0 && d10n == 0 && d12n == 0 && d20n == 0 && d100n == 0 && oii == 0)
        {
            oii = 1;
            //StartCoroutine(valordado());
        }

        trocarCamera();

    }

    private void trocarCamera()
    {

        cameraa.transform.position = Vector3.Lerp(cameraa.transform.position, seguir.transform.position, 5f * Time.deltaTime);
        cameraa.transform.rotation = Quaternion.Lerp(cameraa.transform.rotation, seguir.transform.rotation, 5f * Time.deltaTime);

        if (painel.activeSelf == false)
        {
            scrol = Input.GetAxisRaw("Mouse ScrollWheel");
        }
        else
        {
            scrol = 0;
        }
        
        //print(scrol);

        if(scrol > 0)
        {
            decer = false;
            subir = true;
            if (subir == true)
            {
                seguir.transform.position = Vector3.Lerp(seguir.transform.position, p02.transform.position, velocidadeScrol * Time.deltaTime);
                seguir.transform.rotation = Quaternion.Lerp(seguir.transform.rotation, p02.transform.rotation, velocidadeScrol * Time.deltaTime);
                print("negativo");
            }
            
        }
        else if(scrol < 0)
        {
            decer = true;
            subir = false;
            if (subir == false)
            {
                seguir.transform.position = Vector3.Lerp(seguir.transform.position, p01.transform.position, velocidadeScrol * Time.deltaTime);
                seguir.transform.rotation = Quaternion.Lerp(seguir.transform.rotation, p01.transform.rotation, velocidadeScrol * Time.deltaTime);
                print("positivo");
            }
        }
    }

    public void jogard4()
    {
        d4n++;
        bd4.transform.Find("Text").GetComponent<Text>().text = d4n + "D4";
    }
    public void jogard6()
    {
        d6n++;
        bd6.transform.Find("Text").GetComponent<Text>().text = d6n + "D6";
    }
    public void jogard8()
    {
        d8n++;
        bd8.transform.Find("Text").GetComponent<Text>().text = d8n + "D8";
    }
    public void jogard10()
    {
        d10n++;
        bd10.transform.Find("Text").GetComponent<Text>().text = d10n + "D10";
    }
    public void jogard12()
    {
        d12n++;
        bd12.transform.Find("Text").GetComponent<Text>().text = d12n + "D12";
    }
    public void jogard20()
    {
        d20n++;
        bd20.transform.Find("Text").GetComponent<Text>().text = d20n + "D20";
    }
    public void jogard100()
    {
        d100n++;
        bd100.transform.Find("Text").GetComponent<Text>().text = d100n + "D100";
    }

    public void jogarDados()
    {

        oii = 0;

        if (d4n != 0 || d6n != 0 || d8n != 0 || d10n != 0 || d10n != 0 || d12n != 0 || d20n != 0 || d100n != 0)
        {

           // StartCoroutine(oi());

        }

        if (d4n != 0)
        {
            if (cont4 != d4n)
            {
                var dice4 = Instantiate(d4, d4.transform.position, d4.transform.rotation);
                //dice4.transform.parent = caixa.transform;
                dice4.name = d4.name;
                dice4.transform.position = d4t.transform.position;
                //dice4.transform.localScale = new Vector3(124, 124, 94);
                dice4.transform.localScale = new Vector3(99, 99, 99);
                cont4++;
                jogarDados();
                cameraa.transform.Find("filho").gameObject.GetComponent<gridNetWork>().criarDados(dice4.gameObject);
                
            }
            else if (cont4 >= d4n)
            {
                cont4 = 0;
                d4n = 0;
                bd4.transform.Find("Text").GetComponent<Text>().text = "D4";
            }
        }
        if (d6n != 0)
        {
            if (cont6 != d6n)
            {
                var dice6 = Instantiate(d6, d6.transform.position, d6.transform.rotation);
                //dice6.transform.parent = caixa.transform;
                dice6.name = d6.name;
                dice6.transform.position = d6t.transform.position;
                //dice6.transform.localScale = new Vector3(69, 69, 69);
                dice6.transform.localScale = new Vector3(100, 100, 100);
                cont6++;
                jogarDados();
                cameraa.transform.Find("filho").gameObject.GetComponent<gridNetWork>().criarDados(dice6.gameObject);
            }
            else if (cont6 >= d6n)
            {
                cont6 = 0;
                d6n = 0;
                bd6.transform.Find("Text").GetComponent<Text>().text = "D6";
            }
        }
        if (d8n != 0)
        {
            if (cont8 != d8n)
            {
                var dice8 = Instantiate(d8, d8.transform.position, d8.transform.rotation);
                //dice8.transform.parent = caixa.transform;
                dice8.name = d8.name;
                dice8.transform.position = d8t.transform.position;
                //dice8.transform.localScale = new Vector3(85, 85, 104);
                dice8.transform.localScale = new Vector3(90, 90, 90);
                cont8++;
                jogarDados();
                cameraa.transform.Find("filho").gameObject.GetComponent<gridNetWork>().criarDados(dice8.gameObject);
            }
            else if (cont8 >= d8n)
            {
                cont8 = 0;
                d8n = 0;
                bd8.transform.Find("Text").GetComponent<Text>().text = "D8";
            }
        }
        if (d10n != 0)
        {
            if (cont10 != d10n)
            {
                var dice10 = Instantiate(d10, d10.transform.position, d10.transform.rotation);
                //dice10.transform.parent = caixa.transform;
                dice10.name = d10.name;
                dice10.transform.position = d10t.transform.position;
                //dice10.transform.localScale = new Vector3(67, 67, 67);
                dice10.transform.localScale = new Vector3(175, 175, 175);
                cont10++;
                jogarDados();
                cameraa.transform.Find("filho").gameObject.GetComponent<gridNetWork>().criarDados(dice10.gameObject);
            }
            else if (cont10 >= d10n)
            {
                cont10 = 0;
                d10n = 0;
                bd10.transform.Find("Text").GetComponent<Text>().text = "D10";
            }
        }
        if (d12n != 0)
        {
            if (cont12 != d12n)
            {
                var dice12 = Instantiate(d12, d12.transform.position, d12.transform.rotation);
               // dice12.transform.parent = caixa.transform;
                dice12.name = d12.name;
                dice12.transform.position = d12t.transform.position;
                //dice12.transform.localScale = new Vector3(52, 52, 52);
                dice12.transform.localScale = new Vector3(76, 76, 76);
                cont12++;
                jogarDados();
                cameraa.transform.Find("filho").gameObject.GetComponent<gridNetWork>().criarDados(dice12.gameObject);
            }
            else if (cont12 >= d12n)
            {
                cont12 = 0;
                d12n = 0;
                bd12.transform.Find("Text").GetComponent<Text>().text = "D12";
            }
        }
        if (d20n != 0)
        {

            if(cont20 != d20n)
            {
                var dice20 = Instantiate(d20, d20.transform.position, d20.transform.rotation);
                //dice20.transform.parent = caixa.transform;
                dice20.name = d20.name;
                dice20.transform.position = d20t.transform.position;
                //dice20.transform.localScale = new Vector3(100, 100, 100);
                dice20.transform.localScale = new Vector3(77, 77, 77);
                cont20++;
                jogarDados();
                cameraa.transform.Find("filho").gameObject.GetComponent<gridNetWork>().criarDados(dice20.gameObject);
            }
            else if(cont20 >= d20n)
            {
                cont20 = 0;
                d20n = 0;
                bd20.transform.Find("Text").GetComponent<Text>().text = "D20";
            }
 
        }
        if (d100n != 0)
        {

            if (cont100 != d100n)
            {
                var dice100 = Instantiate(d100, d100.transform.position, d100.transform.rotation);
                var dice10002 = Instantiate(d10, d10.transform.position, d10.transform.rotation);
                //dice100.transform.parent = caixa.transform;
                //dice10002.transform.parent = caixa.transform;
                dice100.name = d100.name;
                dice10002.name = d10.name;
                dice100.transform.position = d100t.transform.position;
                dice10002.transform.position = d10t.transform.position;
                //dice20.transform.localScale = new Vector3(100, 100, 100);
                dice100.transform.localScale = new Vector3(175, 175, 175);
                dice10002.transform.localScale = new Vector3(175, 175, 175);
                cont100++;
                jogarDados();
                cameraa.transform.Find("filho").gameObject.GetComponent<gridNetWork>().criarDados(dice100.gameObject);
                cameraa.transform.Find("filho").gameObject.GetComponent<gridNetWork>().criarDados(dice10002.gameObject);
            }
            else if (cont100 >= d100n)
            {
                cont100 = 0;
                d100n = 0;
                bd100.transform.Find("Text").GetComponent<Text>().text = "D100";
            }

        }

    }

    WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();

    private IEnumerator oi()
    {
        yield return frameEnd;
        Texture2D currentCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        currentCapture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        currentCapture.Apply();
        foto = Sprite.Create(currentCapture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0, 0));
        imagem.GetComponent<Image>().sprite = foto;
        imagem.SetActive(true);
        postProcecing.SetActive(false);
        roll.GetComponent<Button>().interactable = false;
        cava.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        caixa.SetActive(true);
        cameraa.GetComponent<Camera>().orthographic = true;
        yield return new WaitForSeconds(5f);
        cameraa.GetComponent<Camera>().orthographic = false;
        postProcecing.SetActive(true);
        imagem.SetActive(false);
        cava.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        caixa.SetActive(false);
        roll.GetComponent<Button>().interactable = true;
    }


    /*public IEnumerator valordado(string valorDados)
    {
        //menssagem = "<color=yellow>";
        //valorDados = "";
        yield return new WaitForSeconds(4.5f);
        menssagemDados(valorDados);
    }*/



    public void menssagemDados(string valorDados)
    {
        //menssagem = menssagem + "</color>";
        //chat.GetComponent<ChatWindow>().dados = menssagem;
        chat.GetComponent<ChatWindow>().dados = valorDados;
        chat.GetComponent<ChatWindow>().OnSend();
        print("testeAAAA");

    }

    public void subirCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            subirs();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            decers();
        }
    }

    public void subirs()
    {
        transform.Translate(0, 1, 0);
    }

    public void decers()
    {
        transform.Translate(0, -1, 0);
    }

}
