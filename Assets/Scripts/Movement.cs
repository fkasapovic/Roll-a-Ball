using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {


    public Text countText;
    private int zbroj;
    public float speed;
    private Rigidbody rb;

	void Start () {

        rb = GetComponent<Rigidbody>();
        zbroj = 0;
        SetCountText();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float kretanjeHorizotnal = Input.GetAxis("Horizontal");
        float kretanjeVertical = Input.GetAxis("Vertical");


        Vector3 kretanje = new Vector3(kretanjeHorizotnal, 0.0f, kretanjeVertical);

        rb.AddForce(kretanje * speed);
	}

   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive(false);
            zbroj += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Rezultat: " + zbroj.ToString();
    }
}
