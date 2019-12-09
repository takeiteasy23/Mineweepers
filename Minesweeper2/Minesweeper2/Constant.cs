using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper2
{
    #region 常數
    /// <summary>
    /// 常數
    /// </summary>
    class Constant
    {
        public static readonly int PIC_SIZE = 20;   // 圖片大小
        public static readonly int MAX_X = 30;  // 允許 X 輸入最大值
        public static readonly int MAX_Y = 60;  // 允許 Y 輸入最大值
        public static readonly int MIN = 10;    // 允許 X、Y 輸入最小值
        public static readonly int MIN_MINE = 12;   // 允許 地雷 輸入最小值
        public static readonly int INI_X = 15;  // 圖片起始 X 座標
        public static readonly int INI_Y = 40;  // 圖片起始 Y 座標
    }
    #endregion
}
