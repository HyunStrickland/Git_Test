using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private float healAmount = 20f;

    private Action<Item> onItemUsed = null;

    public void Init(Action<Item> onItemUsed)
    {
        this.onItemUsed = onItemUsed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();
        if (player == null)
        {
            return;
        }

        player.Heal(healAmount);
        onItemUsed?.Invoke(this);
        Destroy(gameObject);
    }
}
