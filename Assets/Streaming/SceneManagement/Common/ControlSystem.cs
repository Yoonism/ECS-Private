using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct ControlSystem : ISystem
{
     [BurstCompile]
     public void OnUpdate(ref SystemState state)
     {
          float2 inputs;
          float2 inputsNormalized;
          inputs.x = Input.GetAxis("Horizontal");
          inputs.y = Input.GetAxis("Vertical");
          inputsNormalized = math.normalizesafe(inputs);
          
          foreach (var (transform, control) in
                   SystemAPI.Query<RefRW<LocalTransform>, RefRW<Control>>())
          {
               var multiplier = control.ValueRO.SpeedMultipler * SystemAPI.Time.DeltaTime;
               //control.ValueRW.InputAxis.x = Input.GetAxis("Horizontal");
               //control.ValueRW.InputAxis.y = Input.GetAxis("Vertical");

               //inputs = math.normalize(control.ValueRO.InputAxis);

               transform.ValueRW.Position.x += inputsNormalized.x * multiplier;
               transform.ValueRW.Position.z += inputsNormalized.y * multiplier;
          }
     }
}
