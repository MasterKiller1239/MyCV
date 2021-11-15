using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    protected Vector3 spawnPoint;
    public GameObject ProjectModel;
    public List<GameObject> BodyParts = new List<GameObject>();
    public float Gap;
    public int startSpawnTime = 1;
    public int spawnTime = 2;
    [SerializeField, Range(0f, 10f)]
    public float outline=5;
    public bool switcher = false;
    public bool Zswitch = false;
    // Use this for initialization
    void Start()
    {
     
        if(Zswitch==false)
        {
            Gap = this.ProjectModel.GetComponent<Renderer>().bounds.size.y;
        } 
        else
        {
            Gap = this.ProjectModel.GetComponent<Renderer>().bounds.size.z;
        }
       // InvokeRepeating("Spawn", startSpawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void Switchero()
    {
        //if (switcher == true)
        //{
        //    foreach (var body in BodyParts)
        //    {
        //        body.GetComponent<Outline>().outlineWidth = outline;
        //    }

        //}
        //else
        //{
        //    foreach (var body in BodyParts)
        //    {
        //        body.GetComponent<Outline>().outlineWidth = 0;
        //    }
        //}
        foreach (var body in BodyParts)
        {
            body.GetComponent<Outline>().outlineWidth = outline;
        }
        LeanTween.delayedCall(30000f, () =>
        {
            foreach (var body in BodyParts)
            {
                body.GetComponent<Outline>().outlineWidth = 0;
            }
        });
    }
    public void Spawn(int number)
    {

        for(int i=0;i<number;i++)
        {
            spawnPoint = this.transform.position;
            if (Zswitch == false)
                spawnPoint.y += Gap * BodyParts.Count;
            else
                spawnPoint.z += Gap * BodyParts.Count;
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            GameObject project = Instantiate(this.ProjectModel, this.spawnPoint, this.transform.rotation);
            project.transform.SetParent(this.transform);

            BodyParts.Add(project);
        }
      
    }
}
