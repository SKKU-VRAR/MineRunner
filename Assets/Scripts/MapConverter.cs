using static Values;

public class MapConverter
{
    /// <summary>벽(지뢰)의 두께 기본값.</summary>
    private const int DefaultMineWidth = 1;

    /// <summary>통로(빈 공간)의 너비 기본값.</summary>
    private const int DefaultHallWidth = 2;

    /// <summary>
    ///     <see cref="MazeWays"/>형 2차원 배열로 표현된 미로를 <see cref="MazeComp"/>형 2차원 배열로 변환합니다.
    /// </summary>
    /// <param name="data"><see cref="MazeWays"/>로 구성된 미로 데이터입니다.</param>
    /// <param name="mineWidth">
    ///     미로에서 벽(지뢰)의 두께를 의미하는 정수입니다.
    ///     기본값은 <see cref="DefaultMineWidth"/>입니다.
    /// </param>
    /// <param name="hallWidth">
    ///     미로에서 통로(빈 공간)의 너비를 의미하는 정수입니다.
    ///     기본값은 <see cref="DefaultHallWidth"/>입니다.
    /// </param>
    /// <returns>
    ///     <see cref="MazeComp"/>로 변환된 미로 데이터입니다. 지뢰로 둘러싸인 사각형의 형태를 띱니다.
    /// </returns>
    public static MazeComp[,] GetMap (MazeWays[,] data, int mineWidth = DefaultMineWidth,
                                      int hallWidth = DefaultHallWidth)
    {
        // MazeWays로 표현된 미로의 높이/너비
        int dataH = data.GetLength(0);
        int dataW = data.GetLength(1);

        // MazeComp로 표현될 미로의 높이/너비
        int resultH = dataH * (hallWidth + mineWidth) + mineWidth;
        int resultW = dataW * (hallWidth + mineWidth) + mineWidth;

        MazeComp[,] result = new MazeComp[resultH, resultW];

        result.Fill(p => (p.x < mineWidth || p.y < mineWidth) ? MazeComp.Mine : MazeComp.Empty);

        int cellX = hallWidth + mineWidth;

        for (int x = 0; x < dataH; x ++, cellX += hallWidth + mineWidth)
        {
            // cellX = (x + 1) * (hallWidth + mineWidth);
            int cellY = hallWidth + mineWidth;

            for (int y = 0; y < dataW; y ++, cellY += hallWidth + mineWidth)
            {
                // cellY = (y + 1) * (hallWidth + mineWidth) + mineWidth;
                if (data[y, x].Contains(MazeWays.right))
                {
                    result.Fill(MazeComp.Mine,
                                (cellY - hallWidth, cellY),
                                (cellX, cellX + mineWidth));
                }

                if (data[y, x].Contains(MazeWays.down))
                {
                    result.Fill(MazeComp.Mine,
                                (cellY, cellY + mineWidth),
                                (cellX - hallWidth, cellX));
                }
            }
        }

        return result;
    }
}