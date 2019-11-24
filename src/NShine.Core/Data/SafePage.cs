using NShine.Core.Extensions;

namespace NShine.Core.Data
{
    /// <summary>
    /// 安全的分页信息。
    /// </summary>
    public class SafePage : IPage
    {
        private int _pageNumber;
        private int _pageSize;

        /// <summary>
        /// 初始化一个<see cref="SafePage"/>类型的新实例。
        /// </summary>
        public SafePage() : this(null)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="SafePage"/>类型的新实例（默认 页大小 20）。
        /// </summary>
        /// <param name="pageNumber">页码。</param>
        /// <param name="pageSize">页大小。</param>
        public SafePage(int? pageNumber, int? pageSize = 20)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        /// <summary>
        /// 获取 页码。
        /// </summary>
        public int? PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value.OrDefault();
                // 1 <= pageNumber
                if (_pageNumber <= 0)
                {
                    _pageNumber = 1;
                }
            }
        }



        /// <summary>
        /// 获取 页大小。
        /// </summary>
        public int? PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value.OrDefault();
                // 5 <= pageSize <= 200
                if (_pageSize < 5)
                {
                    _pageSize = 5;
                }
                if (_pageSize > 200)
                {
                    _pageSize = 200;
                }
            }
        }
    }
}
