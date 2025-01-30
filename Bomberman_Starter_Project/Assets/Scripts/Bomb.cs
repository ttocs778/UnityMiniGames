using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject explosionPrefab;
    public int ownerplayerNumber;

    public LayerMask levelMask;
    private bool exploded = false;
    void Start()
    {
        Invoke("Explode",3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Explode(){
        GameObject initialExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        initialExplosion.GetComponent<Explosion>().ownerplayerNumber = this.ownerplayerNumber;//1
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));  
        GetComponent<MeshRenderer>().enabled = false; //2
        exploded = true; 
        transform.Find("Collider").gameObject.SetActive(false); //3
        Destroy(gameObject, .3f); //4

    }
    private IEnumerator CreateExplosions(Vector3 direction) 
    {
        //1
        for (int i = 1; i < 3; i++) 
        { 
            //2
            RaycastHit hit; 
            //3
            Physics.Raycast(transform.position + new Vector3(0,.5f,0), direction, out hit, 
                i, levelMask); 

            //4
            if (!hit.collider) 
            { 
                GameObject explosionInstance = Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
                explosionInstance.GetComponent<Explosion>().ownerplayerNumber = this.ownerplayerNumber;
                //6
            } 
            else 
            { //7
                break; 
            }

            //8
            yield return new WaitForSeconds(.05f); 
        }

    }  
    public void OnTriggerEnter(Collider other) 
    {
        if (!exploded && other.CompareTag("Explosion"))
        { // 1 & 2  
            CancelInvoke("Explode"); // 2
            Explode(); // 3
        }  

    }
}