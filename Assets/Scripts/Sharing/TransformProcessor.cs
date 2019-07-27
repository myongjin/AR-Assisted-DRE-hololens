﻿using UnityEngine; using HoloToolkit.Sharing;  public class TransformProcessor : MonoBehaviour {      private Vector3 position;     public Vector3 Position     {         get         {             return position;         }          private set         {             position = value;             if (position != transform.localPosition)                 this.transform.localPosition = position;         }     }      private Quaternion rotation;     public Quaternion Rotation     {         get         {             return rotation;         }          private set         {             rotation = value;             this.transform.localRotation = rotation;         }     }      private void Start()     {      }      public void ProcessTransform(NetworkInMessage msg)     {         long userID = msg.ReadInt64();         Position = CustomMessages.Instance.ReadVector3(msg);         Rotation = CustomMessages.Instance.ReadQuaternion(msg);     } } 