
using UnityEngine;

public class Basket : MonoBehaviour
{
    public string acceptedTag;
    private float threashold;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == acceptedTag)
        {

            SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingLayerName = "Bg";
                spriteRenderer.sortingOrder = -1;
            }

            Vector3 newvec = transform.GetChild(0).position;
            collision.GetComponent<DragDrop>().Correct(new Vector2(newvec.x + threashold, newvec.y));
            threashold += 0.3f;
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
