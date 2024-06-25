using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct TwitchSystem : ISystem
{
     [BurstCompile]
     public void OnUpdate(ref SystemState state)
     {
          foreach (var (transform, twitch) in
                   SystemAPI.Query<RefRW<LocalTransform>, RefRW<Twitch>>())
          {
               twitch.ValueRW.TimeCursor += SystemAPI.Time.DeltaTime;

               if (twitch.ValueRO.TimeCursor >= twitch.ValueRO.TimeMax)
               {
                    twitch.ValueRW.TimeCursor = 0f;
                    twitch.ValueRW.TimeMax = UnityEngine.Random.Range(twitch.ValueRO.TimeMinMax[0], twitch.ValueRO.TimeMinMax[1]);
                    
                    transform.ValueRW.Scale = UnityEngine.Random.Range(twitch.ValueRO.ScaleMinMax[0], twitch.ValueRO.ScaleMinMax[1]);
               }
          }
     }
     
}
