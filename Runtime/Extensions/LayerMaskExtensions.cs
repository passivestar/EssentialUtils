using UnityEngine;

namespace EssentialUtils
{
    public static class LayerMaskExtensions
    {
        public static bool Has(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }

        public static LayerMask Inverted(this LayerMask mask)
        {
            return ~mask;
        }

        public static LayerMask With(this LayerMask mask, int layer)
        {
            mask |= 1 << layer;
            return mask;
        }

        public static LayerMask Without(this LayerMask mask, int layer)
        {
            return mask & ~(1 << layer);
        }
    }
}