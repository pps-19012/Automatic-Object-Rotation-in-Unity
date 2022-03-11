using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    public float torqueValue; //the torqueValue is 150
    public float smooth;
    //private bool keyPressed = true;
    public int waitTime;
    public GameObject pos0;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject player;
    public float yHeight; //the yHeight is 0.8f

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(KeyActive());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(dir1());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(dir2());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(dir3());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(dir0());
        }
    }

    private void InputMovement()
    {
        pos0.transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y + yHeight, player.transform.position.z);
        pos1.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yHeight, player.transform.position.z - 0.5f);
        pos2.transform.position = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y + yHeight, player.transform.position.z);
        pos3.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yHeight, player.transform.position.z + 0.5f);
    }

    private void Movement()
    {
        pos0.transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y + yHeight, player.transform.position.z);
        pos1.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yHeight, player.transform.position.z - 0.5f);
        pos2.transform.position = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y + yHeight, player.transform.position.z);
        pos3.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yHeight, player.transform.position.z + 0.5f);

        /*pos0.transform.localPosition = new Vector3(0.5f, 0.15f, 0);
        pos1.transform.localPosition = new Vector3(0, 0.15f, -0.5f);
        pos2.transform.localPosition = new Vector3(-0.5f, 0.15f, 0);
        pos3.transform.localPosition = new Vector3(0, 0.15f, 0.5f);*/

        
        int dir = Random.Range(0, 3);
        if (dir == 0)
        {
            //rb.AddTorque(Vector3.forward * torqueValue, ForceMode.Acceleration);
            /*keyPressed = false;*/
            StartCoroutine(dir0());

            //Debug.Log(Input.GetKey(KeyCode.W));
        }

        else if (dir == 1)
        {
            //rb.AddTorque(-Vector3.right * torqueValue, ForceMode.Acceleration);
            StartCoroutine(dir1());
        }

        else if (dir == 2)
        {
            //rb.AddTorque(-Vector3.forward * torqueValue, ForceMode.Acceleration);
            StartCoroutine(dir2());
        }

        else if (dir == 3)
        {
            //rb.AddTorque(Vector3.right * torqueValue, ForceMode.Acceleration);
            StartCoroutine(dir3());
        }


        /*if (Input.GetKey(KeyCode.W) && keyPressed)
        {
            rb.AddTorque(Vector3.forward * torqueValue, ForceMode.Acceleration);
            *//*keyPressed = false;
            StartCoroutine(KeyActive());*//*

            //Debug.Log(Input.GetKey(KeyCode.W));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.right * torqueValue, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddTorque(-Vector3.forward * torqueValue, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.right * torqueValue, ForceMode.Acceleration);
        }*/


        //THE CODE BELOW USES THE RIGIDBODY OF THE GAMEOBJECT TO ROTATE IT. IT IS REALISTIC, BUT DUE TO PHYSICS IT BEHAVES IN UNEXPECTED MANNERS.
        /*float turn1 = Input.GetAxis("Horizontal");
        rb.AddTorque(Vector3.right * torqueValue * turn1, ForceMode.Acceleration);
        float turn2 = Input.GetAxis("Vertical");
        rb.AddTorque(Vector3.forward * torqueValue * turn2, ForceMode.Acceleration);*/


        //THE CODE BELOW USES ONLY TRANSFORM.ROTATE TO ROTATE THE GAMEOBJECT WITHOUT THE USE OF RIGIDBODY. BELOW MIGHT BE THE BETTER VERSION OF THE CODE SHOWN
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 90f), Time.deltaTime * smooth);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90f, 0f, 0f), Time.deltaTime * smooth);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, -90f), Time.deltaTime * smooth);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(90f, 0f, 0f), Time.deltaTime * smooth);
        }*/


        //THE CODE BELOW USES ONLY TRANSFORM.ROTATE TO ROTATE THE GAMEOBJECT WITHOUT THE USE OF RIGIDBODY. IT WAS ASSUMED THAT THIS IS CODE IS THE BETTER VERSION OF THE CODE USED ABOVE, HOWEVER IT DOES NOT SEEM TO BE THE CASE
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z + 90f), Time.deltaTime * smooth);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x - 90f, 0f, transform.rotation.z), Time.deltaTime * smooth);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z - 90f), Time.deltaTime * smooth);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x + 90f, 0f, transform.rotation.z), Time.deltaTime * smooth);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(transform.rotation);
        }*/
    }

    IEnumerator KeyActive()
    {
        yield return new WaitForSeconds(3f);
        Movement();
        //InputMovement();                      <<<------ uncomment this to make the cube rotate manually
        //keyPressed = true;
        Debug.Log("Start");
    }

    IEnumerator dir0()
    {
        //rb.AddTorque(Vector3.forward * torqueValue, ForceMode.Acceleration);
        rb.AddForceAtPosition(Vector3.forward * torqueValue, pos0.transform.position, ForceMode.Acceleration);
        Debug.Log("D");
        yield return new WaitForSeconds(waitTime);
        //pos0.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        Movement();
        //InputMovement();                      <<<------ uncomment this to make the cube rotate manually
        //InputMovement();
        //keyPressed = true;

    }

    IEnumerator dir1()
    {
        //rb.AddTorque(-Vector3.right * torqueValue, ForceMode.Acceleration);
        rb.AddForceAtPosition(-Vector3.right * torqueValue, pos1.transform.position, ForceMode.Acceleration);
        Debug.Log("W");
        yield return new WaitForSeconds(waitTime);
        //pos1.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        Movement();
        //InputMovement();                      <<<------ uncomment this to make the cube rotate manually
        //InputMovement();
        //keyPressed = true;

    }

    IEnumerator dir2()
    {
        //rb.AddTorque(-Vector3.forward * torqueValue, ForceMode.Acceleration);
        rb.AddForceAtPosition(-Vector3.forward * torqueValue, pos2.transform.position, ForceMode.Acceleration);
        Debug.Log("A");
        yield return new WaitForSeconds(waitTime);
        //pos2.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        Movement();
        //InputMovement();                      <<<------ uncomment this to make the cube rotate manually
        //keyPressed = true;

    }

    IEnumerator dir3()
    {
        //rb.AddTorque(Vector3.right * torqueValue, ForceMode.Acceleration);
        rb.AddForceAtPosition(Vector3.right * torqueValue, pos3.transform.position, ForceMode.Acceleration);
        Debug.Log("S");
        yield return new WaitForSeconds(waitTime);
        //pos3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        Movement();
        //InputMovement();                      <<<------ uncomment this to make the cube rotate manually
        //keyPressed = true;

    }
}
