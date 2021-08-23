using UnityEngine;

namespace Utils
{
    public static class AnimationTools
    {
        public static void MirrorBalls(GameObject balls)
        {
            balls.transform.Rotate(Vector3.forward, 180);
        }
        
        // private static void MirrorUpperBalls()
        // {
        //     var upperPosition = upperBalls.transform.position;
        //     upperBalls.transform.position = new Vector2(upperPosition.x == 0 ? XMirrorOffset : 0, upperPosition.y);
        // }
        //
        // private static void MirrorLowerBalls()
        // {
        //     var lowerPosition = lowerBalls.transform.position;
        //     lowerBalls.transform.position = new Vector2(lowerPosition.x == 0 ? -XMirrorOffset : 0, lowerPosition.y);
        // }
    }
}
