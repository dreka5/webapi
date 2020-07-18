using System;
using System.Collections.Generic;
using System.Text;

namespace WebLib.Entity
{
    /// <summary>
    /// статут записи активна/удалена/....
    /// </summary>
    public static class RecordState
    {
        public const int ACTIVE = 1;
        public const int DELETED = 2;  // хм...а если -1
    }
}
