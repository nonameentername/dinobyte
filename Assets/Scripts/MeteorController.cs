using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject topLeft;
    public GameObject topRight;
    public GameObject bottomRight;
    public GameObject bottomLeft;

    public GameObject blast;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBlast", 1f, 1f);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void CreateBlast()
    {
        int random = Random.Range(0, 4);
        //int random = 0;

        switch(random)
        {
            case 0:
                CreateBlast(topLeft, topRight);
                break;
            case 1:
                CreateBlast(topRight, bottomRight);
                break;
            case 2:
                CreateBlast(bottomRight, bottomLeft);
                break;
            case 3:
                CreateBlast(bottomLeft, topLeft);
                break;
        }
    }

    void CreateBlast(GameObject first, GameObject second)
    {
        if(player.GetComponent<PlayerController>().isAlive)
        {
            Vector3 v = -(first.transform.position - second.transform.position);
            Vector3 target_position = first.transform.position + Random.value * v;

            GameObject blastInstance = Instantiate(blast, target_position, Quaternion.identity);

            float angle = AngleInRad(blastInstance.transform.position, player.transform.position);

            blastInstance.transform.RotateAroundLocal(new Vector3(0, 0, 1), angle);

            blastInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f * Mathf.Cos(angle), 50f * Mathf.Sin(angle)));
            Destroy(blastInstance, 5);
        }
    }

    public static float AngleInRad(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }

    //This returns the angle in degrees
    public static float AngleInDeg(Vector3 vec1, Vector3 vec2)
    {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
    }

}
