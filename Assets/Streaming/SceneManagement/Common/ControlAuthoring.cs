using UnityEngine;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Entities;

public class ControlAuthoring : MonoBehaviour
{
     public float2  inputAxis;
     public float   speedMultipler;
     
     class Baker : Baker<ControlAuthoring>
     {
          public override void Bake(ControlAuthoring authoring)
          {
               var entity = GetEntity(TransformUsageFlags.Dynamic | TransformUsageFlags.WorldSpace);
               AddComponent(entity, new Control
               {
                    InputAxis      = authoring.inputAxis,
                    SpeedMultipler = authoring.speedMultipler
               });
          }
     }
}

public struct Control : IComponentData
{
     public float2  InputAxis;
     public float   SpeedMultipler;
}
