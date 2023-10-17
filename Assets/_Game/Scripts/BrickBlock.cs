using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    private bool isCollect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.Player) && !isCollect)
        {
            other.GetComponent<Player>().AddBrick();
            isCollect = true;
            brick.SetActive(false);
        }
    }
}
