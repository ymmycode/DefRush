using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] int PlayerBaseHealth = 10;
    [SerializeField] TMP_Text baseHealth;
    [SerializeField] AudioClip enemyAtBase;

    private void Start() 
    {
        baseHealth.text = PlayerBaseHealth.ToString();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemies"))
        {
            Invoke("DangerAtBase",1f);
        }
    }

    private void DangerAtBase()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyAtBase);
        PlayerBaseHealth--;
        baseHealth.text = PlayerBaseHealth.ToString();
    }
}
