using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSim : MonoBehaviour
{
    public GameObject particlePrefab;
    public int boundingWidth;
    public int boundingHeight;
    public float gravity = 9.81f;
    public Vector2 velocity = new Vector2(0, 0);
    public float restitution = 0.5f;
    public GameObject particle;
    
    // Start is called before the first frame update
    void DrawBoundingBox()
    {
        Debug.DrawLine(new Vector3(-boundingWidth, -boundingHeight, 0), new Vector3(boundingWidth, -boundingHeight, 0), Color.green);
        Debug.DrawLine(new Vector3(-boundingWidth, boundingHeight, 0), new Vector3(boundingWidth, boundingHeight, 0), Color.green);
        Debug.DrawLine(new Vector3(-boundingWidth, -boundingHeight, 0), new Vector3(-boundingWidth, boundingHeight, 0), Color.green);
        Debug.DrawLine(new Vector3(boundingWidth, -boundingHeight, 0), new Vector3(boundingWidth, boundingHeight, 0), Color.green);
    }
    void EnforceBoundingBox()
    {
        Vector3 pos = this.particle.transform.position;
        float r = 0.5f;
        
        if (boundingWidth < pos.x+r || pos.x-r < -boundingWidth)
        {
            this.velocity.x = -this.velocity.x * this.restitution;
        } 
        
        if (boundingHeight < pos.y+r || pos.y-r < -boundingHeight)
        {
            this.velocity.y = -this.velocity.y * this.restitution;
        } 
        
    }
    void Start()
    {
        this.particle = Instantiate(particlePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log(this.particle.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        DrawBoundingBox();
        this.velocity.y -= this.gravity * Time.deltaTime;
        EnforceBoundingBox();
        this.particle.transform.position += new Vector3(this.velocity.x, this.velocity.y, 0) * Time.deltaTime;
    }
}
