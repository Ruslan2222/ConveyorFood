using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Destroyer : MonoBehaviour
{
    private SpawnFood _spawnFood;

    private void Start()
    {
        _spawnFood = FindObjectOfType<SpawnFood>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Orange>())
        {
            Destroy(other.gameObject);
            _spawnFood.FoodSpawner(2);
        }
        else if (other.gameObject.GetComponent<Pear>())
        {
            Destroy(other.gameObject);
            _spawnFood.FoodSpawner(2);
        }
        else if (other.gameObject.GetComponent<Pineapple>())
        {
            Destroy(other.gameObject);
            _spawnFood.FoodSpawner(2);
        }
    }
}
