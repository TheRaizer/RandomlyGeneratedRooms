using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsGenerator : MonoBehaviour
{
    [SerializeField] public GameObject closingRoomUp;
    [SerializeField] public GameObject closingRoomDown;
    [SerializeField] public GameObject closingRoomLeft;
    [SerializeField] public GameObject closingRoomRight;

    [SerializeField] public GameObject[] leftRooms;
    [SerializeField] public GameObject[] rightRooms;
    [SerializeField] public GameObject[] upRooms;
    [SerializeField] public GameObject[] downRooms;

    [field: SerializeField] public int MaxNumberOfRooms { get; private set; }

    [field: SerializeField]public int CurrentNumberOfRooms { get; set; }

    public bool[,] RoomPlacements { get; set; }

    public int length;

    public Dictionary<int, List<GameObject>> openings = new Dictionary<int, List<GameObject>>();

    public void AddToOpenings(int type, GameObject room)
    {
        if(!openings.ContainsKey(type))
        {
            openings.Add(type, new List<GameObject>());
            openings[type].Add(room);
        }
        else
        {
            openings[type].Add(room);
        }
    }

    private void Awake()
    {
        length = (int)Mathf.Sqrt(MaxNumberOfRooms) + 1;//+1 is temp
        RoomPlacements = new bool[length, length];
    }
}
