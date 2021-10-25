using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class dice : NetworkBehaviour
{
    //Declare Variables:

    //Strength of attraction from your sphere (obviously, it can be any type of game-object)
    public float StrengthOfAttraction;

    //Obviously, you won't be using planets, so change this variable to whatever you want
    GameObject planet;

    public GameObject alvo;

    public float atracao;

    //Initialise code:
    void Start()
    {
        
        if(this.gameObject.GetComponent<diceStatc>().player.isServer == true)
        {
            alvo = GameObject.Find("alvo");
            Vector3 concentrar;
            concentrar = alvo.transform.position - transform.position;
            transform.rotation = new Quaternion(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            planet = GameObject.FindGameObjectWithTag("Planet");
            GetComponent<Rigidbody>().AddForce(concentrar.normalized * atracao);
        }

        StartCoroutine(oi());

    }

    //Use FixedUpdate because we are controlling the orbit with physics
    void FixedUpdate()
    {
        if (this.gameObject.GetComponent<diceStatc>().player.isServer == true)
        {
            Vector3 offset;

            offset = planet.transform.position - transform.position;

            GetComponent<Rigidbody>().AddForce((StrengthOfAttraction * offset.normalized * Time.deltaTime) * GetComponent<Rigidbody>().mass);
        }
    }

    IEnumerator oi()
    {
        yield return new WaitForSeconds(4.5f);
        Destroy(this.gameObject);
    }

}
