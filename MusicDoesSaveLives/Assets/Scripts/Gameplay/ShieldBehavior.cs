using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public GameObject explObj;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "FObject")
        {
            PlayExplosion(other.gameObject.transform.position);
            other.gameObject.SetActive(false);
            Debug.Log("Shield!!!");
        }
    }

    void PlayExplosion(Vector3 tp)
    {
        GameObject explosion = (GameObject)Instantiate(explObj);
        explosion.transform.position = tp;
        StartCoroutine(destroyGO(explosion));
    }

    private IEnumerator destroyGO(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
