using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject ExplosionsBoss;
    public GameObject ExplosionsBoss2;

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
            //this.gameObject.SetActive(false);
            //Debug.Log("Boss killed!");
        }
    }

    void PlayExplosion(Vector3 tp)
    {
      //  GameObject explosions = (GameObject)Instantiate(ExplosionsBoss);
      //  explosions.transform.position = tp;
      //  StartCoroutine(destroyGO(explosions));
    }

    private IEnumerator destroyGO()
    {
        ExplosionsBoss.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        ExplosionsBoss.SetActive(true);
        ExplosionsBoss2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        ExplosionsBoss2.SetActive(true);
        ExplosionsBoss.SetActive(false);
        yield return new WaitForSeconds(3f);
        ExplosionsBoss.SetActive(false);
        ExplosionsBoss2.SetActive(false);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }

    private IEnumerator endAnim()
    {
        yield return new WaitForSeconds(7f);
        this.GetComponent<Animator>().enabled = false;
        ExplosionsBoss.SetActive(true);
        ExplosionsBoss2.SetActive(true);
        StartCoroutine(destroyGO());
    }
}
