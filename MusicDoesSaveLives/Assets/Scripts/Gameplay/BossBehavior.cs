using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject ExplosionsBoss;

    void Start()
    {
        StartCoroutine(endAnim());
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Detector"))
        {
            PlayExplosion(other.gameObject.transform.position);
            this.gameObject.SetActive(false);
            Debug.Log("Boss killed!");
        }
    }

    void PlayExplosion(Vector3 tp)
    {
        GameObject explosions = (GameObject)Instantiate(ExplosionsBoss);
        explosions.transform.position = tp;
        StartCoroutine(destroyGO(explosions));
    }

    private IEnumerator destroyGO(GameObject gameObject)
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private IEnumerator endAnim()
    {
        yield return new WaitForSeconds(4f);
        this.GetComponent<Animator>().enabled = false;
    }
}
