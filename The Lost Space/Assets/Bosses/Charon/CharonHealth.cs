using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharonHealth : MonoBehaviour
{
    public float Health = 300f;
    public Slider Healthbar;
    private bool isDead = false;
    public Animator isHit;
    private Animator SecondPhase;
    public GameObject SecondPhaseBurstPrefab;
    public GameObject CharonDeathEffect;
    public Animator TransitionAnim;
    public GameObject KeyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Healthbar.value = Health;
        SecondPhase = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.value = Health;
        if (Health < 0)
        {
            isDead = true;
        }

        if (Health < 104 && Health > 94)
        {
            FindObjectOfType<AudioManagerBoss>().Play("CharonScream");
            SecondPhase.SetTrigger("Stage2");
            Instantiate(SecondPhaseBurstPrefab, transform.position, Quaternion.identity);

        }
        if (Health < 54 && Health > 50)
        {
            FindObjectOfType<AudioManagerBoss>().Play("CharonScream");
            SecondPhase.SetTrigger("Death");


        }
        if (Health < 0)
        {
            FindObjectOfType<AudioManagerBoss>().Play("CharonDeath");
            Destroy(gameObject);
            Instantiate(CharonDeathEffect, transform.position, Quaternion.identity);
            Instantiate(KeyPrefab, transform.position, Quaternion.identity);
        }   Destroy(FindObjectOfType<AudioManager>());
        if (isDead)
        {
            StartCoroutine(Outro());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead == false)
        {
            if (collision.CompareTag("PlayerRedBullet"))
            {
                Health = Health - 1f;
                isHit.SetTrigger("ishit");

            }
        }
    }

    IEnumerator Outro()
    {

        
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Outro1");
    }



}
