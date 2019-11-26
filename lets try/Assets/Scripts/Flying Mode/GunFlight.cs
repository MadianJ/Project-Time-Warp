using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlight : MonoBehaviour
{
    public float horiz1;
    public float horiz2;
    public float coolDownPeriodInSeconds;
    public LayerMask shoot;
    public Transform shootingPoint;
    public LineRenderer lineRenderer;
    // Update is called once per frame
    void Update()
    {
      
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);


        if (direction.x > horiz1 && direction.x < horiz2 && direction.y > 0)
        {
            transform.up = -direction;
          
           
                if (Input.GetButtonDown("Fire1"))
                {


                StartCoroutine("pewpew", direction);
                 
                }
            
        }
    }

    IEnumerable pewpew(Vector2 direction)
    {
     //   Debug.Log("ooga");
        RaycastHit2D fire = Physics2D.Raycast(shootingPoint.position, direction, 6f, shoot);
        if (fire)
        {
            EnemyFly enemy = fire.transform.GetComponent<EnemyFly>();
            enemy.loseHP();

            lineRenderer.SetPosition(0, shootingPoint.position);
            lineRenderer.SetPosition(1, fire.point);
        }
        else
        {
            lineRenderer.SetPosition(0, shootingPoint.position);
            lineRenderer.SetPosition(1, shootingPoint.position + shootingPoint.up *200);
        }

        lineRenderer.enabled = true;

      //  wait one frame
        yield return new WaitForSeconds(coolDownPeriodInSeconds);
        lineRenderer.enabled = false;
    }

}
