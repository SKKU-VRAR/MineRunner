public abstract class Values
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
}
