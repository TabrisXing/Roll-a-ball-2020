using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpheight;
    public Text countText;
    public Text winText;
    public GameObject Pickup;
    public int number_of_Pickups;
    public float radius;

    private Rigidbody rb;
    private int count;
    private bool groundContact;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        groundContact = false;

        for (int i = 0; i < number_of_Pickups; i++)
        {
            float angle = i * Mathf.PI * 2f / number_of_Pickups;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 0.5f, Mathf.Sin(angle) * radius);
            Instantiate(Pickup, newPos, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 up = new Vector3(0.0f, jumpheight, 0.0f);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown("space") && groundContact)
        {
            rb.AddForce(up);
            groundContact = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("5pts Pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            groundContact = true;
        }
    }

void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= number_of_Pickups + 5)
        {
            winText.text = "You Win!";
        }
    }

}
