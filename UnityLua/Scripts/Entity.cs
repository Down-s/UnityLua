using UnityEngine;

namespace UnityLua
{
    public class Entity : MonoBehaviour
    {
        [HideInInspector]
        public int EntIndex;

        [Tooltip("The name used to reference this gameobject in Lua using Entity.Get('name')")]
        public string NameIndex;

        private void Awake()
        {
            EntIndex = LuaLibraries.Entities.Count;
            LuaLibraries.Entities.Add(this);

            if (!string.IsNullOrEmpty(NameIndex))
            {
                var IndexPair = new LuaLibraries.EntityIndexPair();
                IndexPair.ent = this;
                IndexPair.EntIndex = EntIndex;

                LuaLibraries.EntityLookup[NameIndex] = IndexPair;
            }
        }
    }
}