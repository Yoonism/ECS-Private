using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class TwitchAuthoring : MonoBehaviour
{
     public float2  scaleMinMax;
     public float2  timeMinMax;
     public float   timeCursor;
     public float   timeMax;

     class Baker : Baker<TwitchAuthoring>
     {
          public override void Bake(TwitchAuthoring authoring)
          {
               var entity = GetEntity(TransformUsageFlags.Dynamic | TransformUsageFlags.WorldSpace);
               AddComponent(entity, new Twitch
               {
                    ScaleMinMax    = authoring.scaleMinMax,
                    TimeMinMax     = authoring.timeMinMax,
                    TimeCursor     = authoring.timeCursor,
                    TimeMax        = authoring.timeMax
               });
          }
     }
}

public struct Twitch : IComponentData
{
     public float2  ScaleMinMax;
     public float2  TimeMinMax;
     public float   TimeCursor;
     public float   TimeMax;
}
