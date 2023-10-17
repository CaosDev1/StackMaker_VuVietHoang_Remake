using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbrickBlock : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    public bool isCollect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.Player) && !isCollect && other.GetComponent<Player>().brickList.Count != 0)
        {
            other.GetComponent<Player>().RemoveBrick();
            
            isCollect = true;
            brick.SetActive(true);
        }
    }
}
