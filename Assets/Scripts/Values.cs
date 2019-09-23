public static class Values
{
    public enum MazeComp {
        Empty = 0,
        Mine = 1,
    };

    // placeholders
    private const int _ = 0;
    private const int __ = 0;
    
    /// <summary>
    ///     격자로 이루어진 미로에 대해, 특정 칸에서 진행할 수 있는 방향을 나타내는 열거자입니다.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         이 열거자는 상(<see cref="up"/>), 하(<see cref="down"/>), 좌(<see cref="left"/>), 우(<see cref="right"/>)
    ///         4가지 방향을 의미하는 비트 플래그를 조합한 값들로 구성되어 있습니다.
    ///         각 플래그의 자릿값은 다음의 표를 참고하세요.
    ///     </para>
    ///     <list type="table">
    ///         <listheader>
    ///             <term>플래그</term>  
    ///             <description>10진수</description>  
    ///             <description>2진수</description>  
    ///         </listheader>
    ///         <item>
    ///             <term><see cref="right"/></term>
    ///             <description>1 (0001)</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="up"/></term>
    ///             <description>2 (0010)</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="left"/></term>
    ///             <description>4 (0100)</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="down"/></term>
    ///             <description>8 (1000)</description>
    ///         </item>
    ///     </list>
    ///     <para>
    ///         각 플래그는 1일 때 
    ///     </para>
    /// </remarks>
    public enum MazeWays {

        // 4방향 각각을 의미하는 플래그
        right           = 0b_0001,
        up              = 0b_0010,
        left            = 0b_0100,
        down            = 0b_1000,

        // 4방향을 조합한 값들
        all             = right | up | left | down ,
        none            =   _   | __ |  __  |  __  ,
        rightup         = right | up |  __  |  __  ,
        rightleft       = right | __ | left |  __  ,
        downright       = right | __ |  __  | down ,
        rightupleft     = right | up | left |  __  ,
        downrightup     = right | up |  __  | down ,
        leftdownright   = right | __ | left | down ,
        upleft          =   _   | up | left |  __  ,
        updown          =   _   | up |  __  | down ,
        upleftdown      =   _   | up | left | down ,
        leftdown        =   _   | __ | left | down 
    };

    /// <summary>
    ///     <paramref name="me"/>가 <paramref name="other"/>의 방향들을 포함하는지 조사합니다.
    /// </summary>
    /// <param name="me">
    ///     포함 여부를 조사할 <see cref="MazeWays"/> 값입니다.
    ///     <c>x.Contains(y)</c>에서 <c>x</c>에 해당됩니다.
    /// </param>
    /// <param name="other">
    ///     조사 대상 방향들이 포함된 <see cref="MazeWays"/> 값입니다.
    ///     <c>x.Contains(y)</c>에서 <c>y</c>에 해당됩니다.
    /// </param>
    /// <returns>
    ///     <paramref name="other"/>가 나타내는 방향들을 <paramref name="me"/>가 모두 포함하고 있으면 true를,
    ///     아니면 false를 반환합니다.
    ///     만약 <paramref name="other"/>가 <see cref="MazeWays.none"/>이면 항상 true를 반환합니다.
    /// </returns>
    /// <remarks>
    ///     <see cref="MazeWays"/>형 2차원 배열로 표현된 M x N 크기의 미로 A에 대해, 다음의 규칙이 성립해야 합니다.
    ///     <list type="table">
    ///         <listheader>
    ///             <term>규칙</term>  
    ///             <description>설명</description>  
    ///         </listheader>
    ///         <item>
    ///             <term>좌표 규칙</term>
    ///             <description>
    ///                 <c>(0, 0)</c>은 미로의 가장 왼쪽 위를 뜻합니다.
    ///                 그리고 <c>(x, y)</c> 위치에 대한 정보를 담는 <see cref="MazeWays"/>는 A[y, x]에 담깁니다.
    ///                 즉, 미로의 폭 W와 높이 H에 대해 A의 크기는 H x W가 됩니다.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>경계 규칙</term>
    ///             <description>
    ///                 경계에 인접한 항목에 대해, 행렬을 벗어나는 방향을 포함해서는 안됩니다.
    ///                 이를 수식으로 다음과 같이 표현할 수 있습니다.
    ///                 <list type="bullet">
    ///                     <item>
    ///                         <description>
    ///                             0 이상 M 미만의 임의의 정수 y에 대해,
    ///                             A[y, 0]은 <see cref="MazeWays.left"/>를 포함하지 않으며
    ///                             A[y, W-1]은 <see cref="MazeWays.right"/>를 포함하지 않습니다.
    ///                         </description>
    ///                     </item>
    ///                     <item>
    ///                         <description>
    ///                             0 이상 N 미만의 임의의 정수 x에 대해,
    ///                             A[0, x]는 <see cref="MazeWays.up"/>을 포함하지 않으며
    ///                             A[H-1, x]는 <see cref="MazeWays.down"/>을 포함하지 않습니다.
    ///                         </description>
    ///                     </item>
    ///                 </list>
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>인접 규칙</term>
    ///             <description>
    ///                 <para>
    ///                     서로 인접한 칸 P, Q에 대해 P에서 Q로 갈 수 있으면, Q에서 P로도 갈 수 있어야 합니다.
    ///                     또 P에서 Q로 갈 수 없으면, Q에서 P로도 갈 수 없어야 합니다.
    ///                 </para>
    ///
    ///                 <para>
    ///                     예를 들어, A[y, x]가 <see cref="MazeWays.left"/>를 포함하면
    ///                     A[y, x-1]은 <see cref="MazeWays.right"/>를 포함해야 하며,
    ///                 
    ///                     A[y, x]가 <see cref="MazeWays.down"/>을 포함하지 않으면
    ///                     A[y+1, x]은 <see cref="MazeWays.up"/>을 포함해선 안됩니다.
    ///                 </para>
    ///             </description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public static bool Contains(this MazeWays me, MazeWays other) => (me & other) == other;
}
