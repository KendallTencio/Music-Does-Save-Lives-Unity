using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionPlatformBehavior : MonoBehaviour
{

    public GameObject explObj;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "FObject")
        {
            PlayExplosion(other.gameObject.transform.position);
            other.gameObject.SetActive(false);
            Debug.Log("Explosion");
        }
    }

    void PlayExplosion(Vector3 tp)
    {
        //Instancia la explosion
        GameObject explosion = (GameObject)Instantiate(explObj);
        //Se coloca la explosion
        explosion.transform.position = tp;
        StartCoroutine(destroyGO(explosion));
    }

    private IEnumerator destroyGO(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
