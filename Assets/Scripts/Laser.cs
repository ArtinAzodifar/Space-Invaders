using UnityEngine;

public interface Laser
{
    void Update();
    void OnTriggerEnter2D(Collider2D other);

}
