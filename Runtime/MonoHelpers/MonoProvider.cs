using UnityEngine;
using Leopotam.EcsLite;
using System.Collections.Generic;

namespace Voody.UniLeo.Lite
{
    public abstract class MonoProvider<T> : BaseMonoProvider, IConvertToEntity where T : struct
    {
        [SerializeField] protected T value;

        protected abstract void Setup(int entity, EcsWorld world);

        void IConvertToEntity.Convert(int entity, EcsWorld world)
        {
            var pool = world.GetPool<T>();
            if (pool.Has(entity))
            {
                pool.Del(entity);
            }
            Setup(entity, world);
            pool.Add(entity) = value;
        }
    }
}
