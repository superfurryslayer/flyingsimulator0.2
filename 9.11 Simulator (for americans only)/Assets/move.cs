using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public float flyspeed = 5;
    public int score;
    public AudioSource nicemusic;
    public Text scoreText;
    private float jav;
    public float javmoung = 20;
    public float time;
    public Text timeText;
    public int timer;
    public AudioSource motorio;
// Start is called before the first frame update
void Start()
    {
        //scoreText.text = "score: " + score;
        score = 0;
        scoreText.text = "score:" + score;
        time = 60f;
        timeText.text = "timer: " + time;
      
    }   

    // Update is called once per frame
    void Update()
    {  time -= Time.deltaTime;
        timeText.text = "timer: " + time.ToString("0");


        transform.position += transform.forward *flyspeed* Time.deltaTime;
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        jav +=HorizontalInput * javmoung * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 30, Mathf.Abs(VerticalInput)) * Mathf.Sign(VerticalInput);
        float roll= Mathf.Lerp(0, 0, Mathf.Abs(VerticalInput)) * -Mathf.Sign(HorizontalInput);
        transform.localRotation = Quaternion.Euler(Vector3.up * jav + Vector3.right * pitch + Vector3.forward * roll);
        if (time <= 0) SceneManager.LoadScene(0);
        if (Input.GetKey(KeyCode.A))
        {
            motorio.enabled = true;

        }
        else
        {
            motorio.enabled = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            score++;
            Destroy(other.gameObject);
            scoreText.text = "score:" + score;
            time++;
        }

        if (other.gameObject.tag == "teleport")
        {
            SceneManager.LoadScene("level");
            time = 20f;
        }
    }

    
}
