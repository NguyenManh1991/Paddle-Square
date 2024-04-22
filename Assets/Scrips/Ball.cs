using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField, Min(0f)] 
    float maxStartXSpeed = 2f,
          constantYSpeed = 10f, 
          extents = 0.5f, 
          maxXspeed = 20f;
    Vector2 position, velocity;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void UpdateVisualLization()
    {
        transform.localPosition= new Vector3(position.x,0f,position.y);
    }

    public void Move()
    {
        position += velocity * Time.deltaTime;
    }

    public void StartNewGame()
    {
        position=Vector2.zero;
        UpdateVisualLization();
        //velocity=new Vector2(maxStartXSpeed,-constantYSpeed);
        velocity.x = Random.Range(-maxStartXSpeed, maxStartXSpeed);
        velocity.y = -constantYSpeed;
        gameObject.SetActive(true);
    }
    public void EndGame()
    {
        position.x = 0f;
       gameObject.SetActive(false);
    }

    public void SetXPositionAndSpeed(float start, float speedFactor,float timeDeltatime)
    {
        velocity.x = maxXspeed * speedFactor;
        position.x = start + velocity.x * timeDeltatime;    
    }
    public Vector2 Velocity => velocity;
    public void BounceX(float boundary)
    {
        position.x =2f*boundary-position.x;
    }
    public void BounceY(float boundary)
    {
        position.y = 2f * boundary - position.y;
    }
    public float Extents => extents;
    public Vector2 Position => position;
}
