using System;

public static class MissileTypeExtension
{
    public static char ToChar(this Missile.MissileType type)
    {
        switch (type)
        {
            case Missile.MissileType.False:
                return '0';
            case Missile.MissileType.True:
                return '1';
            default:
                throw new ArgumentOutOfRangeException("type", type, null);
        }
    }
}