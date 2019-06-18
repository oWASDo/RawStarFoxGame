using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public static class MaterialLibrary
    {
        private static Dictionary<string, Material> materials;

        static MaterialLibrary()
        {
            materials = new Dictionary<string, Material>();
        }

        public static void LoadMaterial(string materialName, Material material)
        {
            materials.Add(materialName,material);
        }

        public static Material GetMaterial(string materialName)
        {
            return materials[materialName];
        }
        public static void Clear()
        {
            materials.Clear();
        }
    }
}
