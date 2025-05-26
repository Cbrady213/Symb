using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public NavMeshMan navUpdate;
    public GameObject explosion;
    float timer;
    float defaultYpos;
    // Start is called before the first frame update
    void Start()
    {
        navUpdate = GameObject.Find("GameManager").GetComponent<NavMeshMan>();
        defaultYpos = transform.position.y;


    }

    // Update is called once per frames
    void Update()
    {
        RotatePickup();

        timer += Time.deltaTime * 1.5f;
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            defaultYpos + Mathf.Sin(timer) * 0.2f,
            transform.localPosition.z
        );
        
        

    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
            navUpdate.StartCoroutine(navUpdate.UpdateNavMesh());
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(this.gameObject);




        }

    }

    void RotatePickup()
    {

        transform.Rotate(0, 50 * Time.deltaTime, 0);



    }

    
}
