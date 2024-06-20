
using UnityEngine;

public class Basket : MonoBehaviour
{
    public string acceptedTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == acceptedTag)
        {


            collision.GetComponent<DragDrop>().Correct(transform.GetChild(0).position);
            collision.GetComponent<DragDrop>().isLocked = true;
            GameManager.instance.totalBasket += 1;
            GameManager.instance.PlayParticle();
            GameManager.instance.PlaySound(true);
            
        
        }
        else
        {

            GameManager.instance.PlaySound(false);
            collision.GetComponent<DragDrop>().isLocked = false;
            
        }
    }
    
}
