using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public enum BulletType {pusher, explosive, explodeOther};
    public BulletType bulletType;
    public GameObject owner;
    public float speed;
    public float power;
    public Rigidbody rb;
    public float lifeTime;
    public Actor hitActor;


    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != owner && collision.gameObject.name != gameObject.name)
        {
            // EFFECTS OF COLLISIONS DEPENDING ON BULLET TYPE
            if (collision.gameObject.GetComponent<Actor>() != null)
            {
                hitActor = collision.gameObject.GetComponent<Actor>();
                Debug.Log(hitActor.name + "was hit!");

                if (bulletType == BulletType.pusher)
                {
                    hitActor.rb.AddForce(gameObject.GetComponent<Rigidbody>().velocity.normalized * power);
                }
                else if (bulletType == BulletType.explodeOther)
                {
                    hitActor.Explode(gameObject);
                }
            }
                        
            if (bulletType == BulletType.explosive)
            {
                transform.Find("Explosion").gameObject.SetActive(true);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                Destroy(gameObject, 10);
                Debug.Log(collision.gameObject.name + "was hit!");
            }
                     
        }        
    }
}
