public abstract class Values
{
    public enum MazeComp {
        Empty = 0,
        Mine = 1,
    };

    public enum MazeWays {
        right = 1,
        up = 2,
        left = 4,
        down = 8,
        rightup = 3,
        upleft = 6,
        leftdown = 12,
        downright = 9,
        rightleft = 5,
        updown = 10,
        rightupleft = 7,
        upleftdown = 14,
        leftdownright = 13,
        downrightup = 11,
        all = 15,
        none = 0
    };
}
