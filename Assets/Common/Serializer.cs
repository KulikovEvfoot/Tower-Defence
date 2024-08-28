using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Common
{
    public static class Serializer
    {
        public static Result<T> Deserialize<T>(string json)
        {
            try
            {
                var item = JsonConvert.DeserializeObject<T>(json);
                return Result<T>.Success(item);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
            
            return Result<T>.Fail();
        }
    }
}